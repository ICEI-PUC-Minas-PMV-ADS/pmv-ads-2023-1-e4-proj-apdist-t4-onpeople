using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnPeople.Application.Dtos.Users;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Domain.Models.Users;
using OnPeople.Persistence.Interfaces.Contracts.Users;

namespace OnPeople.Application.Services.Implementations.Users
{
    public class UsersServices : IUsersServices
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUsersPersistence _usersPersistence;

        public UsersServices(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            IUsersPersistence usersPersistence
        )
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _usersPersistence = usersPersistence;
            _userManager = userManager;
        }
        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password)
        {
            try
            {
                var user = await _userManager
                    .Users
                    .SingleOrDefaultAsync(
                        user => user.UserName.ToLower() == userUpdateDto.UserName.ToLower()
                    );

                return await _signInManager.CheckPasswordSignInAsync(user, password, false);
            }
            catch (Exception e)
            {
                
                throw new Exception($"Falha ao validar Conta e Senha. Erro: {e.Message}");
            }
        }

        public async Task<UserUpdateDto> CreateUsersAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                var userCreated = await _userManager.CreateAsync(user, userDto.Password);

                if (userCreated.Succeeded) {
                    return _mapper.Map<UserUpdateDto>(user);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception($"Falha ao criar a Conta. Erro: {e.Message}");
            }
        }
        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _usersPersistence.GetUserByIdAsync(userId);

                if (user == null) return null;

                return _mapper.Map<UserDto>(user);
            }
            catch (Exception e)
            {
                
                throw new Exception($"Falha ao recuperar Contas por Id da conta. Erro: {e.Message}");
            }
        }

        public async Task<UserUpdateDto> GetUserByUserNameAsync(string userName)
        {
            try
            {
                var user = await _usersPersistence.GetUserByUserNameAsync(userName);

                if (user == null) return null;

                return _mapper.Map<UserUpdateDto>(user);
            }
            catch (Exception e)
            {
                
                throw new Exception($"Falha ao recuperar Contas. Erro: {e.Message}");
            }
        }

        public async Task<UserUpdateDto> UpdateUserTokenAsync(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _usersPersistence.GetUserByUserNameAsync(userUpdateDto.UserName);

                if (user == null) return null;

                _mapper.Map(userUpdateDto, user);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                Console.WriteLine("=-=-=-=-=-=-=-=-=-Update Reset Token " + user.UserName + " =-= " + token + " =-= " + userUpdateDto.Password );
                await _userManager.ResetPasswordAsync(user, token, userUpdateDto.Password);

                _usersPersistence.Update<User>(user);

                if (await _usersPersistence.SaveChangesAsync()) {
                    var userRetorno = await _usersPersistence.GetUserByUserNameAsync(user.UserName);
                    return _mapper.Map<UserUpdateDto>(userRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception($"Falha ao alterar Contas e token. Erro: {e.Message}");
            }
        }

        public async Task<UserVisaoDto> UpdateUserVisaoAsync(UserVisaoDto userVisaoDto)
        {
            try
            {
                var user = await _usersPersistence.GetUserByIdAsync(userVisaoDto.Id);

                if (user == null) return null;

                _mapper.Map(userVisaoDto, user);

                var change = await _usersPersistence.SaveChangesAsync();

                Console.WriteLine("=-=-=-=-=-=-=-=-=-UpdateUserVisaoAsync " + userVisaoDto.UserName + " =-= " + user.UserName +  " =-= " + change );
                if (change) {

                    var userRetorno = await _usersPersistence.GetUserByIdAsync(user.Id);
                    return _mapper.Map<UserVisaoDto>(userRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception($"Falha ao recuperar Contas ativas. Erro: {e.Message}");
            }
        }

        public async Task<bool> VerifyUserExistsAsync(string userName)
        {
            try
            {
                return await _userManager
                    .Users
                    .AnyAsync(user => user.UserName.ToLower() == userName.ToLower());
            }
            catch (Exception e)
            {
                
                throw new Exception($"Falha ao verificar se a conta existe. Erro: {e.Message}");
            }
        }
    }
}