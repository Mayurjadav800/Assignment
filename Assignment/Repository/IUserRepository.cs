using Assignment.Dto;

namespace Assignment.Repository
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetUsers(); 
        Task<UserDto> GetUserById(int userId);
        Task<UserDto> CreateUser(UserDto userDto);
        Task<UserDto> UpdateUser(UserDto userDto);
        Task<Boolean> DeleteUser(int userId);
    }
}
