using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlDarb.DTO;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface ICourseService
    {
        Task<CourseDTO> GetById(int id, bool includeDeleted = false);
        Task<CourseDTO> GetByName(string name, bool includeDeleted = false);
        Task<CourseDTO> GetByUserId(int userId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<CourseDTO> Edit(CourseDTO dto);
    }
}
