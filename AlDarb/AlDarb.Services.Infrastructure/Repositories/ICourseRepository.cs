
using AlDarb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface ICourseRepository<TCourse> where TCourse : Course
    {
        Task<IEnumerable<TCourse>> GetList(ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<IEnumerable<TCourse>> GetByName(string name, ContextSession session, bool includeDeleted = false);
        Task<IEnumerable<TCourse>> GetByUserId(int userId, ContextSession session, bool includeDeleted = false);
        Task<TCourse> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TCourse> Edit(TCourse course, ContextSession session);
    }
}
