using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface IDonationPostFieldService
    {
        Task<IEnumerable<DonationPostFieldDTO>> GetList(int? donationPostId, bool includeDeleted = false);
        Task<DonationPostFieldDTO> GetById(int id, bool includeDeleted = false);
        Task<IEnumerable<DonationPostFieldDTO>> GetByDonationPostId(int donationPostId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<DonationPostFieldDTO> Edit(DonationPostFieldDTO dto);
    }
}
