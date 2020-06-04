using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class ApplicationForSessionService<TApplicationForSession> : BaseService, IApplicationForSessionService where TApplicationForSession : ApplicationForSession, new()
    {
        protected readonly IApplicationForSessionRepository<TApplicationForSession> applicationForSessionRepository;
        public ApplicationForSessionService(ICurrentContextProvider contextProvider, IApplicationForSessionRepository<TApplicationForSession> applicationForSessionRepository) : base(contextProvider)
        {
            this.applicationForSessionRepository = applicationForSessionRepository;
        }

        public async Task<IEnumerable<ApplicationForSessionDTO>> GetList(int? userId, int? sessionId, DateTime? date, bool includeDeleted = false)
        {
            var entitiy = await applicationForSessionRepository.GetList(userId, sessionId, date, Session, includeDeleted);
            return  entitiy.MapTo<IEnumerable<ApplicationForSessionDTO>>();
        }

        public async Task<bool> Delete(int id)
        {
            await applicationForSessionRepository.Delete(id, Session);
            return true;
        }

        public async Task<ApplicationForSessionDTO> Edit(ApplicationForSessionDTO dto)
        {
            var applicationForSession = dto.MapTo<TApplicationForSession>();
            await applicationForSessionRepository.Edit(applicationForSession, Session);
            return applicationForSession.MapTo<ApplicationForSessionDTO>();
        }

        public async Task<ApplicationForSessionDTO> GetByApplicationDate(DateTime applicationDate, bool includeDeleted = false)
        {
            var applicationForSession = await applicationForSessionRepository.GetByApplicationDate(applicationDate, Session, includeDeleted);
            return applicationForSession.MapTo<ApplicationForSessionDTO>();
        }

        public async Task<ApplicationForSessionDTO> GetByCourseSessionId(int courseSessionId, bool includeDeleted = false)
        {
            var applicationForSession = await applicationForSessionRepository.GetByCourseSessionId(courseSessionId, Session, includeDeleted);
            return applicationForSession.MapTo<ApplicationForSessionDTO>();
        }

        public async Task<ApplicationForSessionDTO> GetById(int id, bool includeDeleted = false)
        {
            var applicationForSession = await applicationForSessionRepository.Get(id, Session, includeDeleted);
            return applicationForSession.MapTo<ApplicationForSessionDTO>();
        }

        public async Task<ApplicationForSessionDTO> GetByUserId(int userId, bool includeDeleted = false)
        {
            var applicationForSession = await applicationForSessionRepository.GetByUserId(userId, Session, includeDeleted);
            return applicationForSession.MapTo<ApplicationForSessionDTO>();
        }
    }
}
