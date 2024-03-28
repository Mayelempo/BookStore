using AutoMapper;
using BookStore.BusinessLogic.Dtos.Users;
using BookStore.BusinessLogic.Exceptions;
using BookStore.BusinessLogic.Interfaces;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BookStore.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager; 
        private readonly IMapper _mapper;
        private ISaveChangesRepository _saveChangesRepository;
        private ILoggerManager _loggerManager;

        public UserService(UserManager<User> userManager,
            IMapper mapper,
            ISaveChangesRepository saveChangesRepository,
            ILoggerManager loggerManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _saveChangesRepository = saveChangesRepository;
            _loggerManager = loggerManager;
        }

        public async Task<UserCreateDto> CreateAsync(UserCreateDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            using (_userManager)
            {
                var checkedUser = await _userManager.FindByEmailAsync(mappedUser.Email);
                if (checkedUser != null)
                {
                    _loggerManager.LogError("Error occured while crating a user");
                    throw new AlreadyExistException("This user already exist");
                }
                 await _userManager.CreateAsync(mappedUser, mappedUser.Password);
                 await _saveChangesRepository.SaveChangesAsync();
                //don't forget to add role later

                return user;
            }
        }

        public async Task<UserReadDto> DeleteUserAsync(string id)
        {
                UserReadDto user = new UserReadDto();
                var mappedUser = _mapper.Map<User>(user);
                using (_userManager)
                {
                    var checkedUser = await _userManager.FindByEmailAsync(mappedUser.Email);
                    if (checkedUser != null)
                    {
                        _loggerManager.LogError("Error occured while processing the delete request");
                        throw new NotFoundException("The user was not found");
                    }
                    await _userManager.DeleteAsync(checkedUser);
                    await _saveChangesRepository.SaveChangesAsync();
                return user;
                }
            }

        public async Task<List<UserReadDto>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var list = await _userManager.Users.ToListAsync(cancellationToken);
            if (list == null)
            {
                throw new NotFoundException("The users were not found");
            }
            var listDto = _mapper.Map<List<UserReadDto>>(list);
            return listDto;
        }

        public async Task<UserReadDto> GetByUserIdAsync(string id)
        {
            var checkedUser = await _userManager.FindByIdAsync(id);
            if (checkedUser == null)
            {
                throw new NotFoundException("The user was not found");
            }
            return _mapper.Map<UserReadDto>(checkedUser); 
        }

        public async Task<UserReadDto> GetByUserNameAsync(string name)
        {
            var checkedUser = await _userManager.FindByNameAsync(name);
            if (checkedUser == null)
            {
                throw new NotFoundException("The user was not found");
            }
            return _mapper.Map<UserReadDto>(checkedUser);
        }

        public async Task<UserReadDto> GetUserByEmailAsync(string email)
        {
            var checkedUser = await _userManager.FindByEmailAsync(email);
            if (checkedUser == null)
            {
                throw new NotFoundException("The user was not found");
            }
            return _mapper.Map<UserReadDto>(checkedUser);
        }

        public async Task<UserCreateDto> UpdateUserAsync(UserCreateDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            using (_userManager)
            {
                var checkedUser = await _userManager.FindByEmailAsync(mappedUser.Email);
                if (checkedUser == null)
                {
                    _loggerManager.LogError("Error while processing the request");
                    throw new NotFoundException("User not found");
                }
                checkedUser.Name = mappedUser.Name;
                checkedUser.LastName = mappedUser.LastName;
                checkedUser.UserName = mappedUser.UserName;
                checkedUser.Email = mappedUser.Email;
                checkedUser.Password = mappedUser.Password;
                checkedUser.PhoneNumber = mappedUser.PhoneNumber;

                 await _userManager.UpdateAsync(checkedUser);
                await _saveChangesRepository.SaveChangesAsync();
                return user;
            }
        }

    }
}
