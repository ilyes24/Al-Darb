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
    public class CourseSessionService<TCourseSession> : BaseService, ICourseSessionService where TCourseSession : CourseSession, new()
    {
        protected readonly ICourseSessionRepository<TCourseSession> courseSessionRepository;
        public CourseSessionService(ICurrentContextProvider contextProvider, ICourseSessionRepository<TCourseSession> courseSessionRepository) : base(contextProvider)
        {
            this.courseSessionRepository = courseSessionRepository;
        }

        public async Task<bool> Delete(int id)
        {
            await courseSessionRepository.Delete(id, Session);
            return true;
        }

        public async Task<CourseSessionDTO> Edit(CourseSessionDTO dto)
        {
            dto.StartDate = dto.StartDate.AddDays(1);
            dto.EndDate = dto.EndDate.AddDays(1);
            var courseSession = dto.MapTo<TCourseSession>();
            await courseSessionRepository.Edit(courseSession, Session);
            return courseSession.MapTo<CourseSessionDTO>();
        }

        public async Task<IEnumerable<CourseSessionDTO>> GetByCourseId(int courseId, bool includeDeleted = false)
        {
            var entitiy = await courseSessionRepository.GetByCourseId(courseId, Session, includeDeleted);
            return entitiy.MapTo<IEnumerable<CourseSessionDTO>>();
        }

        public async Task<IEnumerable<CourseSessionDTO>> GetByEndDate(DateTime endDate, bool includeDeleted = false)
        {
            var entitiy = await courseSessionRepository.GetByEndDate(endDate, Session, includeDeleted);
            return entitiy.MapTo<IEnumerable<CourseSessionDTO>>();
        }

        public async Task<CourseSessionDTO> GetById(int id, bool includeDeleted = false)
        {
            var courseSession = await courseSessionRepository.Get(id, Session, includeDeleted);
            return courseSession.MapTo<CourseSessionDTO>();
        }

        public async Task<IEnumerable<CourseSessionDTO>> GetByStartDate(DateTime startDate, bool includeDeleted = false)
        {
            var entitiy = await courseSessionRepository.GetByStartDate(startDate, Session, includeDeleted);
            return entitiy.MapTo<IEnumerable<CourseSessionDTO>>();
        }

        public async Task<IEnumerable<CourseSessionDTO>> GetList(int? courseId, DateTime? startDate, DateTime? endDate, bool includeDeleted = false)
        {
            var entity = await courseSessionRepository.GetList(courseId, startDate, endDate, Session, includeDeleted);
            return entity.MapTo<IEnumerable<CourseSessionDTO>>();
        }

        public async Task<bool> ClearToSession(int courseId, DateTime start, DateTime end, bool includeDeleted = false)
        {
            var entity = await courseSessionRepository.ClearToSession(courseId, start, end, Session, includeDeleted);
            return entity;
        }

        public async Task<int> NumberOfApplications(int sessionId, bool includeDeleted = false)
        {
            var entity = await courseSessionRepository.NumberOfApplications(sessionId, Session, includeDeleted);
            return entity;
        }
    }
}
