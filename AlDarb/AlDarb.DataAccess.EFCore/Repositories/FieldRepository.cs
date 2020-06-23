using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.DataAccess.EFCore.Repositories
{
    public class FieldRepository : BaseDeletableRepository<Field, DataContext>, IFieldRepository<Field>
    {
        public FieldRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Field>> GetList(ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
