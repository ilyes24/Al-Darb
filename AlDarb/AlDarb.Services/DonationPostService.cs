using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class DonationPostService<TDonationPost> : BaseService, IDonationPostService where TDonationPost : DonationPost, new()
    {
        protected readonly IDonationPostRepository<TDonationPost> donationPostRepository;
        public DonationPostService(ICurrentContextProvider contextProvider, IDonationPostRepository<TDonationPost> donationPostRepository) : base(contextProvider)
        {
            this.donationPostRepository = donationPostRepository;
        }

        public async Task<IEnumerable<DonationPostDTO>> GetList(int? userId, int? fieldId, bool includeDeleted = false)
        {
            var entitiy = await donationPostRepository.GetList(userId, fieldId, Session, includeDeleted);
            return entitiy.MapTo<IEnumerable<DonationPostDTO>>();
        }

        public async Task<bool> Delete(int id)
        {
            await donationPostRepository.Delete(id, Session);
            return true;
        }

        public async Task<DonationPostDTO> Edit(DonationPostDTO dto)
        {
            dto.UserId = Session.UserId;
            var donationPost = dto.MapTo<TDonationPost>();
            await donationPostRepository.Edit(donationPost, Session);
            return donationPost.MapTo<DonationPostDTO>();
        }

        public async Task<DonationPostDTO> GetById(int id, bool includeDeleted = false)
        {
            var donationPost = await donationPostRepository.Get(id, Session, includeDeleted);
            return donationPost.MapTo<DonationPostDTO>();
        }

        public async Task<IEnumerable<DonationPostDTO>> GetByUserId(int userId, bool includeDeleted = false)
        {
            var donationPost = await donationPostRepository.GetByUserId(userId, Session, includeDeleted);
            return donationPost.MapTo<IEnumerable<DonationPostDTO>>();
        }
        
        public async Task<IEnumerable<DonationPostDTO>> GetByFieldId(int fieldId, bool includeDeleted = false)
        {
            var donationPost = await donationPostRepository.GetByFieldId(fieldId, Session, includeDeleted);
            return donationPost.MapTo<IEnumerable<DonationPostDTO>>();
        }
    }
}
