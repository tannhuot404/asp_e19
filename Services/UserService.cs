using api_demo_e19.DTO;
using api_demo_e19.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_demo_e19.Services
{
    public class UserService(UserManager<AppUser> _userManger, IConfiguration _config) : IUserService
    {
        public async Task<BaseResponse<UserResponseDTO>> Login(UserRequestDTO userDTO)
        {
            var user = await _userManger.FindByEmailAsync(userDTO.Email);

            if (user == null) {
                return BaseResponse<UserResponseDTO>.Failure("Invalid Credentials.");
            }

            var isPwdVerified = await _userManger.CheckPasswordAsync(user, userDTO.Password);

            if (!isPwdVerified)
            {
                return BaseResponse<UserResponseDTO>.Failure("Invalid Credentials.");
            }

            // Login Success
            var keyBytes = Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"] ?? throw new InvalidOperationException("JWT Secret Key is missing."));
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256);

            var issuer = _config["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT Issuer is missing.");
            var audience = _config["Jwt:Audience"] ?? throw new InvalidOperationException("JWT Audience is missing.");

            // 2. Define the User's Claims (The payload)
            var roles = await _userManger.GetRolesAsync(user);
            var userRole = roles.FirstOrDefault() ?? "User";

            var claims = new List<Claim>
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, userRole), // Assigning a role! 
                new Claim("MyValue", "value")
            };

            // 3. Create the Token Descriptor 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = credentials
            };

            // 4. Generate and return the string token 
            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);

            var data = new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = userDTO.Email,
                Token = token
            };
            return BaseResponse<UserResponseDTO>.Sucess(data);
        }

        public async Task<BaseResponse<UserResponseDTO>> Register(UserRequestDTO userDTO)
        {
            var newUser = new AppUser
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                UserName = userDTO.Username
            };

            var result = await _userManger.CreateAsync(newUser, userDTO.Password);

            if (result.Succeeded)
            {
                var data = new UserResponseDTO
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                };
                return BaseResponse<UserResponseDTO>.Sucess(data);
            }
            
            var error = string.Join("\n", result.Errors.Select(e => e.Description));
            Console.WriteLine($"Error: {error}");
            return BaseResponse<UserResponseDTO>.Failure(error);
        }
    }
}
