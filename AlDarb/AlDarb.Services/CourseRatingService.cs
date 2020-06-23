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
    public class CourseRatingService<TCourseRating> : BaseService, ICourseRatingService where TCourseRating : CourseRating, new()
    {
        protected readonly ICourseRatingRepository<TCourseRating> courseRatingRepository;

        public CourseRatingService(ICurrentContextProvider contextProvider, ICourseRatingRepository<TCourseRating> courseRatingRepository) : base(contextProvider)
        {
            this.courseRatingRepository = courseRatingRepository;
        }

        public async Task<IEnumerable<CourseRatingDTO>> GetList(int? userId, int? courseId, bool includeDeleted = false)
        {
            var entitiy = await courseRatingRepository.GetList(userId, courseId, Session, includeDeleted);
            return entitiy.MapTo<IEnumerable<CourseRatingDTO>>();
        }

        public async Task<bool> Delete(int id)
        {
            await courseRatingRepository.Delete(id, Session);
            return true;
        }

        public async Task<CourseRatingDTO> Edit(CourseRatingDTO dto)
        {
            dto.UserId = Session.UserId;
            var courseRating = dto.MapTo<TCourseRating>();
            await courseRatingRepository.Edit(courseRating, Session);
            return courseRating.MapTo<CourseRatingDTO>();
        }

        public async Task<CourseRatingDTO> GetById(int id, bool includeDeleted = false)
        {
            var courseRating = await courseRatingRepository.Get(id, Session, includeDeleted);
            return courseRating.MapTo<CourseRatingDTO>();
        }
    }
}
