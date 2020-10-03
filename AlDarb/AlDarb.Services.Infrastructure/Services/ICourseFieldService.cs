using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface ICourseFieldService
    {
        Task<IEnumerable<CourseFieldDTO>> GetList(int? courseId, bool includeDeleted = false);
        Task<CourseFieldDTO> GetById(int id, bool includeDeleted = false);
        Task<IEnumerable<CourseFieldDTO>> GetByCourseId(int courseId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<CourseFieldDTO> Edit(CourseFieldDTO dto);
    }
}
