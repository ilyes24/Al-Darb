/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Utils;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class UserService<TUser> : BaseService, IUserService where TUser : User, new()
    {
        protected readonly IUserRepository<TUser> userRepository;

        public UserService(ICurrentContextProvider contextProvider, IUserRepository<TUser> userRepository) : base(contextProvider)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Delete(int id)
        {
            await userRepository.Delete(id, Session);
            return true;
        }

        public async Task<UserDTO> Edit(UserDTO dto)
        {
            var user = dto.MapTo<TUser>();
            await userRepository.Edit(user, Session);
            return user.MapTo<UserDTO>();
        }

        public async Task<UserDTO> GetById(int id, bool includeDeleted = false)
        {
            var user = await userRepository.Get(id, Session, includeDeleted);
            return user.MapTo<UserDTO>();
        }

        public async Task<UserDTO> GetByLogin(string login, bool includeDeleted = false)
        {
            var user = await userRepository.GetByLogin(login, Session, includeDeleted);
            return user.MapTo<UserDTO>();
        }
    }
}