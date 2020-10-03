using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class CourseFieldService<TCourseField> : BaseService, ICourseFieldService where TCourseField : CourseField, new()
    {
        protected readonly ICourseFieldRepository<TCourseField> courseFieldRepository;

        public CourseFieldService(ICurrentContextProvider contextProvider, ICourseFieldRepository<TCourseField> courseFieldRepository) : base(contextProvider)
        {
            this.courseFieldRepository = courseFieldRepository;
        }

        public async Task<IEnumerable<CourseFieldDTO>> GetList(int? courseId, bool includeDeleted = false)
        {
            var entitiy = await courseFieldRepository.GetList(courseId, Session, includeDeleted);
            return entitiy.MapTo<IEnumerable<CourseFieldDTO>>();
        }

        public async Task<bool> Delete(int id)
        {
            await courseFieldRepository.Delete(id, Session);
            return true;
        }

        public async Task<CourseFieldDTO> Edit(CourseFieldDTO dto)
        {
            var courseField = dto.MapTo<TCourseField>();
            await courseFieldRepository.Edit(courseField, Session);
            return courseField.MapTo<CourseFieldDTO>();
        }

        public async Task<CourseFieldDTO> GetById(int id, bool includeDeleted = false)
        {
            var courseField = await courseFieldRepository.Get(id, Session, includeDeleted);
            return courseField.MapTo<CourseFieldDTO>();
        }

        public async Task<IEnumerable<CourseFieldDTO>> GetByCourseId(int courseId, bool includeDeleted = false)
        {
            var courseField = await courseFieldRepository.GetByCourseId(courseId, Session, includeDeleted);
            return courseField.MapTo<IEnumerable<CourseFieldDTO>>();
        }
    }
}
