using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface IDonationPostService
    {
        Task<IEnumerable<DonationPostDTO>> GetList(int? userId, int? fieldId, bool includeDeleted = false);
        Task<DonationPostDTO> GetById(int id, bool includeDeleted = false);
        Task<IEnumerable<DonationPostDTO>> GetByUserId(int userId, bool includeDeleted = false);
        Task<IEnumerable<DonationPostDTO>> GetByFieldId(int fieldId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<DonationPostDTO> Edit(DonationPostDTO dto);
    }
}
