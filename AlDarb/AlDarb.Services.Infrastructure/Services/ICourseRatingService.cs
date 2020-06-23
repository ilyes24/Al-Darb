using System.Collections.Generic;
using System.Threading.Tasks;
using AlDarb.DTO;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface ICourseRatingService
    {
        Task<IEnumerable<CourseRatingDTO>> GetList(int? userId, int? courseId, bool includeDeleted = false);
        Task<CourseRatingDTO> GetById(int id, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<CourseRatingDTO> Edit(CourseRatingDTO dto);
    }
}
