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
    public class SessionTaskDateService<TSessionTaskDate> : BaseService, ISessionTaskDateService where TSessionTaskDate : SessionTaskDate, new()
    {
        protected readonly ISessionTaskDateRepository<TSessionTaskDate> sessionTaskDateRepository;

        public SessionTaskDateService(ICurrentContextProvider contextProvider, ISessionTaskDateRepository<TSessionTaskDate> sessionTaskDateRepository) : base(contextProvider)
        {
            this.sessionTaskDateRepository = sessionTaskDateRepository;
        }

        public async Task<bool> Delete(int id)
        {
            await sessionTaskDateRepository.Delete(id, Session);
            return true;
        }

        public async Task<SessionTaskDateDTO> Edit(SessionTaskDateDTO dto)
        {
            var entity = dto.MapTo<TSessionTaskDate>();
            await sessionTaskDateRepository.Edit(entity, Session);
            return entity.MapTo<SessionTaskDateDTO>();
        }

        public async Task<SessionTaskDateDTO> GetById(int id, bool includeDeleted = false)
        {
            var entity = await this.sessionTaskDateRepository.Get(id, Session, includeDeleted);
            return entity.MapTo<SessionTaskDateDTO>();
        }

        public async Task<IEnumerable<SessionTaskDateDTO>> GetBySessionId(int sessionId, bool includeDeleted = false)
        {
            var entity = await this.sessionTaskDateRepository.GetBySessionId(sessionId, Session, includeDeleted);
            return entity.MapTo<IEnumerable<SessionTaskDateDTO>>();
        }

        public async Task<IEnumerable<SessionTaskDateDTO>> GetByTaskId(int taskId, bool includeDeleted = false)
        {
            var entity = await this.sessionTaskDateRepository.GetByTaskId(taskId, Session, includeDeleted);
            return entity.MapTo<IEnumerable<SessionTaskDateDTO>>();
        }

        public async Task<IEnumerable<SessionTaskDateDTO>> GetList(int? sessionId, int? taskId, bool includeDeleted = false)
        {
            var entity = await this.sessionTaskDateRepository.GetList(sessionId, taskId, Session, includeDeleted);
            return entity.MapTo<IEnumerable<SessionTaskDateDTO>>();
        }
    }
}
