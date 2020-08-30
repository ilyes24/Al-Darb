using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface ICourseSessionService
    {
        Task<IEnumerable<CourseSessionDTO>> GetList(int? courseId, DateTime? startDate, DateTime? endDate, bool includeDeleted = false);
        Task<CourseSessionDTO> GetById(int id, bool includeDeleted = false);
        Task<IEnumerable<CourseSessionDTO>> GetByCourseId(int courseId, bool includeDeleted = false);
        Task<IEnumerable<CourseSessionDTO>> GetByStartDate(DateTime startDate, bool includeDeleted = false);
        Task<IEnumerable<CourseSessionDTO>> GetByEndDate(DateTime endDate, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<CourseSessionDTO> Edit(CourseSessionDTO dto);
        Task<bool> ClearToSession(int courseId, DateTime start, DateTime end, bool includeDeleted = false);
        Task<int> NumberOfApplications(int sessionId, bool includeDeleted = false);
    }
}
