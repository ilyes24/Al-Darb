using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Utils;
using System;
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
            var courseSession = dto.MapTo<TCourseSession>();
            await courseSessionRepository.Edit(courseSession, Session);
            return courseSession.MapTo<CourseSessionDTO>();
        }

        public async Task<CourseSessionDTO> GetByCourseId(int courseId, bool includeDeleted = false)
        {
            var courseSession = await courseSessionRepository.GetByCourseId(courseId, Session, includeDeleted);
            return courseSession.MapTo<CourseSessionDTO>();
        }

        public async Task<CourseSessionDTO> GetByEndDate(DateTime endDate, bool includeDeleted = false)
        {
            var courseSession = await courseSessionRepository.GetByEndDate(endDate, Session, includeDeleted);
            return courseSession.MapTo<CourseSessionDTO>();
        }

        public async Task<CourseSessionDTO> GetById(int id, bool includeDeleted = false)
        {
            var courseSession = await courseSessionRepository.Get(id, Session, includeDeleted);
            return courseSession.MapTo<CourseSessionDTO>();
        }

        public async Task<CourseSessionDTO> GetByStartDate(DateTime startDate, bool includeDeleted = false)
        {
            var courseSession = await courseSessionRepository.GetByStartDate(startDate, Session, includeDeleted);
            return courseSession.MapTo<CourseSessionDTO>();
        }
    }
}
