using System;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain.Identity;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserPersist _userPersist;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _SignInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserPersist userPersist)
        {
            _SignInManager = signInManager;
            _mapper = mapper;
            _userPersist = userPersist;
            _userManager = userManager;
        }
         
        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password)
        {
            try
            {
                var user = await _userManager.Users
                    .SingleOrDefaultAsync(user => user.UserName == userUpdateDto.UserName.ToLower());

                return await _SignInManager.CheckPasswordSignInAsync(user, password, false);
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");
            }
        }

        public async Task<UserDto> CreateAccountAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserDto>(userDto);
                    return userToReturn;
                }

                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Erro ao tentar crisr usuario. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDto> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _userPersist.GetUserByUserNameAsync(userName);

                if (user == null) return null;

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar pegar usuario pelo nome. Erro: {ex.Message}");
            }
        }

        public Task<UserUpdateDto> UpdateAccountAsync(UserUpdateDto userUpdateDto)
        {
            try
            {

            }
            catch (System.Exception)
            {
                throw new Exception($"Erro ao tentar atulizar usuario. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string username)
        {
            try
            {
                return await _userManager
            }
            catch (System.Exception)
            {
                
                throw new Exception($"Erro ao tentar verificar usuario. Erro: {ex.Message}");
            }
        }
    }
}