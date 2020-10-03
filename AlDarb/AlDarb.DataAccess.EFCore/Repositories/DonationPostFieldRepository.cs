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
    public class DonationPostFieldRepository : BaseDeletableRepository<DonationPostField, DataContext>, IDonationPostFieldRepository<DonationPostField>
    {
        public DonationPostFieldRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DonationPostField>> GetByDonationPostId(int donationPostId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.DonationPostId == donationPostId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DonationPostField>> GetList(int? donationPostId, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            if (donationPostId != null)
                entity = entity.Where(obj => obj.DonationPostId == donationPostId);

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
