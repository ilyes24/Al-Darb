using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface IFieldRepository<TField> where TField : Field
    {
        Task<IEnumerable<TField>> GetList(ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<TField> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TField> Edit(TField field, ContextSession session);
    }
}
