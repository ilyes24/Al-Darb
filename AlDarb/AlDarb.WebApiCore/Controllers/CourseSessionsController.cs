using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;
using System;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class CourseSessionsController : BaseApiController
    {
        private readonly ICourseSessionService courseSessionService;

        public CourseSessionsController(ICourseSessionService courseSessionService)
        {
            this.courseSessionService = courseSessionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseSessionDTO>>> GetCourseSessions([FromQuery] int? courseId, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, bool includeDeleted = false)
        {
            var courseSessionsDto = await courseSessionService.GetList(courseId, startDate, endDate, includeDeleted);
            return Ok(courseSessionsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseSessionDTO>> GetCourseSession(int id, bool includeDeleted)
        {
            var courseSession = await courseSessionService.GetById(id, includeDeleted);

            if (courseSession == null)
            {
                return NotFound();
            }

            return Ok(courseSession);
        }

        [HttpGet("applications")]
        public async Task<ActionResult<CourseSessionDTO>> GetSessionApplications([FromQuery] int sessionId, bool includeDeleted)
        {
            var courseSession = await courseSessionService.NumberOfApplications(sessionId, includeDeleted);

            /*if (courseSession == null)
            {
                return NotFound();
            }*/

            return Ok(courseSession);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseSession(CourseSessionDTO courseSessionDto)
        {
            var courseSession = await courseSessionService.Edit(courseSessionDto);

            if (courseSession == null)
                return BadRequest();

            return Ok(courseSession);
        }

        [HttpPost]
        public async Task<ActionResult<CourseSessionDTO>> PostCourseSession(CourseSessionDTO courseSessionDTO)
        {
            if (await courseSessionService.ClearToSession(courseSessionDTO.CourseId, courseSessionDTO.StartDate, courseSessionDTO.EndDate))
            {
                var courseSession = await courseSessionService.Edit(courseSessionDTO);

                if (courseSession == null)
                    return BadRequest("ghi hak");

                return Ok(courseSession);
            }

            return BadRequest("change interval");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourseSession(int id)
        {
            var deleted = await courseSessionService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
