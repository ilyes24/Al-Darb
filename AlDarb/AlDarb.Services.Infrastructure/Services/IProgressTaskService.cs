using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface IProgressTaskService
    {
        Task<ProgressTaskDTO> GetById(int id, bool includeDeleted = false);
        Task<ProgressTaskDTO> GetByUserId(int userId, bool includeDeleted = false);
        Task<ProgressTaskDTO> GetByTaskId(int taskId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<ProgressTaskDTO> Edit(ProgressTaskDTO dto);
    }
}
