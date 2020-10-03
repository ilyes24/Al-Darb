using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface IDonationService
    {
        Task<IEnumerable<DonationDTO>> GetList(int? userId, int? postId, bool includeDeleted = false);
        Task<DonationDTO> GetById(int id, bool includeDeleted = false);
        Task<IEnumerable<DonationDTO>> GetByPostId(int? postId, bool includeDeleted = false);
        Task<IEnumerable<DonationDTO>> GetByUserId(int userId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<DonationDTO> Edit(DonationDTO dto);
    }
}
