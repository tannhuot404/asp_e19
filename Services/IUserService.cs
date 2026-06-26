using api_demo_e19.DTO;

namespace api_demo_e19.Services
{
    public interface IUserService
    {
        Task<BaseResponse<UserResponseDTO>> Register(UserRequestDTO userDTO);
        Task<BaseResponse<UserResponseDTO>> Login(UserRequestDTO userDTO);

    }
}
