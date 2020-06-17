/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AlDarb.DTO;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure
{
    public interface IUserService
    {
        Task<UserDTO> GetById(int id, bool includeDeleted = false);
        Task<UserDTO> GetByLogin(string login, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<UserDTO> Edit(UserDTO dto);
    }
}