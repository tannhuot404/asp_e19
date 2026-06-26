using api_demo_e19.DTO;
using api_demo_e19.Models;
using Microsoft.AspNetCore.Identity;

namespace api_demo_e19.Services
{
    public class UserService(UserManager<AppUser> _userManger) : IUserService
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

            var data = new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = userDTO.Email
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
