using BookStore.BusinessLogic.Dtos.Users;
using BookStore.DataAccess.Entities;

namespace BookStore.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<UserCreateDto> CreateAsync(UserCreateDto user);
        Task<UserReadDto> GetByUserIdAsync(string id);
        Task<UserReadDto> GetByUserNameAsync(string name);
        Task<UserReadDto> GetUserByEmailAsync(string email);   
        Task <List<UserReadDto>> GetAllUsersAsync(CancellationToken cancellation); 
        Task <UserCreateDto> UpdateUserAsync(UserCreateDto user);
        Task<UserReadDto> DeleteUserAsync(string id); 
    }
}
