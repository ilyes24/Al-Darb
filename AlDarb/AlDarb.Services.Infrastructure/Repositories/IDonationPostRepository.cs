using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface IDonationPostRepository<TDonationPost> where TDonationPost : DonationPost
    {
        Task<IEnumerable<TDonationPost>> GetList(int? userId, int? fieldId, ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<IEnumerable<TDonationPost>> GetByUserId(int userId, ContextSession session, bool includeDeleted = false);
        Task<IEnumerable<TDonationPost>> GetByFieldId(int fieldId, ContextSession session, bool includeDeleted = false);
        Task<TDonationPost> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TDonationPost> Edit(TDonationPost course, ContextSession session);
    }
}
