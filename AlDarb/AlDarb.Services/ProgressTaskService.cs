using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class ProgressTaskService<TProgressTask> : BaseService, IProgressTaskService where TProgressTask : ProgressTask, new()
    {
        protected readonly IProgressTaskRepository<TProgressTask> progressTaskRepository;
        public ProgressTaskService(ICurrentContextProvider contextProvider, IProgressTaskRepository<TProgressTask> progressTaskRepository) : base(contextProvider)
        {
            this.progressTaskRepository = progressTaskRepository;
        }

        public async Task<IEnumerable<ProgressTaskDTO>> GetList(int? taskId, int? userId, bool includeDeleted = false)
        {
            var entitiy = await progressTaskRepository.GetList(taskId, userId, Session, includeDeleted);
            return entitiy.MapTo<IEnumerable<ProgressTaskDTO>>();
        }

        public async Task<bool> Delete(int id)
        {
            await progressTaskRepository.Delete(id, Session);
            return true;
        }

        public async Task<ProgressTaskDTO> Edit(ProgressTaskDTO dto)
        {
            var progressTask = dto.MapTo<TProgressTask>();
            await progressTaskRepository.Edit(progressTask, Session);
            return progressTask.MapTo<ProgressTaskDTO>();
        }

        public async Task<ProgressTaskDTO> GetById(int id, bool includeDeleted = false)
        {
            var progressTask = await progressTaskRepository.Get(id, Session, includeDeleted);
            return progressTask.MapTo<ProgressTaskDTO>();
        }

        public async Task<ProgressTaskDTO> GetByTaskId(int taskId, bool includeDeleted = false)
        {
            var progressTask = await progressTaskRepository.GetByTaskId(taskId, Session, includeDeleted);
            return progressTask.MapTo<ProgressTaskDTO>();
        }

        public async Task<ProgressTaskDTO> GetByUserId(int userId, bool includeDeleted = false)
        {
            var progressTask = await progressTaskRepository.GetByUserId(userId, Session, includeDeleted);
            return progressTask.MapTo<ProgressTaskDTO>();
        }
    }
}
