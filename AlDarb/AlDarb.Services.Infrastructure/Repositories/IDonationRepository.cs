using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface IDonationRepository<TDonation> where TDonation : Donation
    {
        Task<IEnumerable<TDonation>> GetList(int? userId, int? postId, ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<IEnumerable<TDonation>> GetByPostId(int? postId, ContextSession session, bool includeDeleted = false);
        Task<IEnumerable<TDonation>> GetByUserId(int userId, ContextSession session, bool includeDeleted = false);
        Task<TDonation> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TDonation> Edit(TDonation course, ContextSession session);
    }
}
