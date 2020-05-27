using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface ICourseRepository<TCourse> where TCourse : Course
    {
        Task Delete(int id, ContextSession session);
        Task<TCourse> GetByName(string name, ContextSession session, bool includeDeleted = false);
        Task<TCourse> GetByUserId(int userId, ContextSession session, bool includeDeleted = false);
        Task<TCourse> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TCourse> Edit(TCourse course, ContextSession session);
    }
}
