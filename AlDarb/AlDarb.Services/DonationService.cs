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
    public class DonationService<TDonation> : BaseService, IDonationService where TDonation : Donation, new()
    {
        protected readonly IDonationRepository<TDonation> donationRepository;
        public DonationService(ICurrentContextProvider contextProvider, IDonationRepository<TDonation> donationRepository) : base(contextProvider)
        {
            this.donationRepository = donationRepository;
        }

        public async Task<IEnumerable<DonationDTO>> GetList(int? userId, int? postId, bool includeDeleted = false)
        {
            var entitiy = await donationRepository.GetList(userId, postId, Session, includeDeleted);
            return entitiy.MapTo<IEnumerable<DonationDTO>>();
        }

        public async Task<bool> Delete(int id)
        {
            await donationRepository.Delete(id, Session);
            return true;
        }

        public async Task<DonationDTO> Edit(DonationDTO dto)
        {
            dto.UserId = Session.UserId;
            var donation = dto.MapTo<TDonation>();
            await donationRepository.Edit(donation, Session);
            return donation.MapTo<DonationDTO>();
        }

        public async Task<DonationDTO> GetById(int id, bool includeDeleted = false)
        {
            var donation = await donationRepository.Get(id, Session, includeDeleted);
            return donation.MapTo<DonationDTO>();
        }

        public async Task<IEnumerable<DonationDTO>> GetByPostId(int? postId, bool includeDeleted = false)
        {
            var donation = await donationRepository.GetByPostId(postId, Session, includeDeleted);
            return donation.MapTo<IEnumerable<DonationDTO>>();
        }

        public async Task<IEnumerable<DonationDTO>> GetByUserId(int userId, bool includeDeleted = false)
        {
            var donation = await donationRepository.GetByUserId(userId, Session, includeDeleted);
            return donation.MapTo<IEnumerable<DonationDTO>>();
        }
    }
}
