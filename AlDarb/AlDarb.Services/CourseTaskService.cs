using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Utils;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class CourseTaskService<TCourseTask> : BaseService, ICourseTaskService where TCourseTask : CourseTask, new()
    {
        protected readonly ICourseTaskRepository<TCourseTask> courseTaskRepository;
        public CourseTaskService(ICurrentContextProvider contextProvider, ICourseTaskRepository<TCourseTask> courseTaskRepository) : base(contextProvider)
        {
            this.courseTaskRepository = courseTaskRepository;
        }

        public async Task<bool> Delete(int id)
        {
            await courseTaskRepository.Delete(id, Session);
            return true;
        }

        public async Task<CourseTaskDTO> Edit(CourseTaskDTO dto)
        {
            var courseTask = dto.MapTo<TCourseTask>();
            await courseTaskRepository.Edit(courseTask, Session);
            return courseTask.MapTo<CourseTaskDTO>();
        }

        public async Task<CourseTaskDTO> GetByCourseId(int courseId, bool includeDeleted = false)
        {
            var courseTask = await courseTaskRepository.GetByCourseId(courseId, Session, includeDeleted);
            return courseTask.MapTo<CourseTaskDTO>();
        }

        public async Task<CourseTaskDTO> GetById(int id, bool includeDeleted = false)
        {
            var courseTask = await courseTaskRepository.Get(id, Session, includeDeleted);
            return courseTask.MapTo<CourseTaskDTO>();
        }

        public async Task<CourseTaskDTO> GetByTitle(string title, bool includeDeleted = false)
        {
            var courseTask = await courseTaskRepository.GetByTitle(title, Session, includeDeleted);
            return courseTask.MapTo<CourseTaskDTO>();
        }
    }
}
