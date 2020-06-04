using AlDarb.DTO;
using AlDarb.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller}")]
    public class CourseSessionsController : BaseApiController
    {
        private readonly ICourseSessionService courseSessionService;

        public CourseSessionsController (ICourseSessionService courseSessionService)
        {
            this.courseSessionService = courseSessionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseSessionDTO>>> GetCourseSession(bool includeDeleted = false)
        {
            var courseSessionsDto = await courseSessionService.GetList(includeDeleted);
            return Ok(courseSessionsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseSessionDTO>> GetCourse(int id, bool includeDeleted)
        {
            var courseSession = await courseSessionService.GetById(id, includeDeleted);

            if (courseSession == null)
            {
                return NotFound();
            }

            return Ok(courseSession);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(CourseSessionDTO courseSessionDto)
        {
            var courseSession = await courseSessionService.Edit(courseSessionDto);

            if (courseSession == null)
                return BadRequest();

            return Ok(courseSession);
        }

        [HttpPost]
        public async Task<ActionResult<CourseSessionDTO>> PostCourse(CourseSessionDTO courseSessionDTO)
        {
            var courseSession = await courseSessionService.Edit(courseSessionDTO);

            if (courseSession == null)
                return BadRequest();

            return Ok(courseSession);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var deleted = await courseSessionService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
