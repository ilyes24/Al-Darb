using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AlDarb.DTO;
using AlDarb.Entities;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetList(bool includeDeleted = false);
        Task<CourseDTO> GetById(int id, bool includeDeleted = false);
        Task<IEnumerable<CourseDTO>> GetByName(string name, bool includeDeleted = false);
        Task<IEnumerable<CourseDTO>> GetByUserId(int userId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<CourseDTO> Edit(CourseDTO dto);
    }
}
