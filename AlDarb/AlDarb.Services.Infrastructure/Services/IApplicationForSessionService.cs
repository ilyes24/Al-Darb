using AlDarb.DTO;
using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface IApplicationForSessionService
    {
        Task<IEnumerable<ApplicationForSessionDTO>> GetList(bool includeDeleted = false);
        Task<ApplicationForSessionDTO> GetById(int id, bool includeDeleted = false);
        Task<ApplicationForSessionDTO> GetByApplicationDate(DateTime applicationDate, bool includeDeleted = false);
        Task<ApplicationForSessionDTO> GetByUserId(int userId, bool includeDeleted = false);
        Task<ApplicationForSessionDTO> GetByCourseSessionId(int courseSessionId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<ApplicationForSessionDTO> Edit(ApplicationForSessionDTO dto);
    }
}
