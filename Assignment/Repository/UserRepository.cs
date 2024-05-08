using Assignment.Dto;
using Assignment.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserDemoDbContext _dbContext;

        public UserRepository(IMapper mapper,UserDemoDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = _dbContext.User.Find(userId);
            if(user != null)
            {
                _dbContext.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Incorrect User Id.");
            }
        }
        public async Task<List<UserDto>> GetUsers()
        {
            var users = await _dbContext.User.ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await _dbContext.User.FindAsync(userId);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }


        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            var existingUser = await _dbContext.User.FindAsync(userDto.Id);
            if (existingUser == null)
            {
                return null;
            }

            _mapper.Map(userDto, existingUser);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(existingUser);
        }
    }
}
