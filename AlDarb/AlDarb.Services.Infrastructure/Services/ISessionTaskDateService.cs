using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface ISessionTaskDateService
    {
        Task<IEnumerable<SessionTaskDateDTO>> GetList(int? sessionId, int? taskId, bool includeDeleted = false);
        Task<SessionTaskDateDTO> GetById(int id, bool includeDeleted = false);
        Task<IEnumerable<SessionTaskDateDTO>> GetByTaskId(int taskId, bool includeDeleted = false);
        Task<IEnumerable<SessionTaskDateDTO>> GetBySessionId(int sessionId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<SessionTaskDateDTO> Edit(SessionTaskDateDTO dto);
    }
}
