using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface IDonationPostFieldRepository<TDonationPostField> where TDonationPostField : DonationPostField
    {
        Task<IEnumerable<TDonationPostField>> GetList(int? donationPostId, ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<IEnumerable<TDonationPostField>> GetByDonationPostId(int donationPostId, ContextSession session, bool includeDeleted = false);
        Task<TDonationPostField> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TDonationPostField> Edit(TDonationPostField donationPost, ContextSession session);
    }
}
