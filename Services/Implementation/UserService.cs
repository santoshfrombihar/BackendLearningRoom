using AutoMapper;
using MyLearningRoomBackend.DbContextFile;
using MyLearningRoomBackend.Dto;
using MyLearningRoomBackend.Models;
using MyLearningRoomBackend.Services.Interfaces;

namespace MyLearningRoomBackend.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly LearningRoomDbContext _dbContext;
        public UserService(IMapper mapper, LearningRoomDbContext dbContext) 
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<UserDto> ValidateUser(LoginDto login)
        {
            try
            {
                var user =  _dbContext.Users.FirstOrDefault(u =>
                u.Email == login.Password && u.Password == login.Password);

                var userDetails = _mapper.Map<UserDto>(user);
                return userDetails;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDto> SaveData(UserDto user)
        {
            try
            {
                var userDetails = _mapper.Map<UserModel>(user);
                _dbContext.Add(userDetails);
                await _dbContext.SaveChangesAsync();
                var savedUserDetails = _mapper.Map<UserDto>(userDetails);
                return savedUserDetails;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
