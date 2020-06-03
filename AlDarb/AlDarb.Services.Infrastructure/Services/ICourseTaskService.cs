using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface ICourseTaskService
    {
        Task<IEnumerable<CourseTaskDTO>> GetList(bool includeDeleted = false);
        Task<CourseTaskDTO> GetById(int id, bool includeDeleted = false);
        Task<CourseTaskDTO> GetByCourseId(int courseId, bool includeDeleted = false);
        Task<CourseTaskDTO> GetByTitle(string title, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<CourseTaskDTO> Edit(CourseTaskDTO dto);
    }
}
