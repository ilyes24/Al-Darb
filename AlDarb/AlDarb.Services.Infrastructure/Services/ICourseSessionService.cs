using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface ICourseSessionService
    {
        Task<CourseSessionDTO> GetById(int id, bool includeDeleted = false);
        Task<CourseSessionDTO> GetByCourseId(int courseId, bool includeDeleted = false);
        Task<CourseSessionDTO> GetByStartDate(DateTime startDate, bool includeDeleted = false);
        Task<CourseSessionDTO> GetByEndDate(DateTime endDate, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<CourseSessionDTO> Edit(CourseSessionDTO dto);
    }
}
