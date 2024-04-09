using MyLearningRoomBackend.Dto;

namespace MyLearningRoomBackend.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> SaveData(UserDto user);
        public Task<UserDto> ValidateUser(LoginDto login);
    }
}
