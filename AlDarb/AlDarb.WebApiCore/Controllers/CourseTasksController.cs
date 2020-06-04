using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;
using System;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class CourseTasksController : BaseApiController
    {
        private readonly ICourseTaskService courseTaskService;

        public CourseTasksController(ICourseTaskService courseTaskService)
        {
            this.courseTaskService = courseTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseTaskDTO>>> GetCourseTasks([FromQuery] int? courseId, [FromQuery] string title, bool includeDeleted = false)
        {
            var courseTasksDto = await courseTaskService.GetList(courseId, title, includeDeleted);
            return Ok(courseTasksDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseTaskDTO>> GetCourseTask(int id, bool includeDeleted)
        {
            var courseTask = await courseTaskService.GetById(id, includeDeleted);

            if (courseTask == null)
            {
                return NotFound();
            }

            return Ok(courseTask);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(CourseTaskDTO courseTaskDto)
        {
            var courseTask = await courseTaskService.Edit(courseTaskDto);

            if (courseTask == null)
                return BadRequest();

            return Ok(courseTask);
        }

        [HttpPost]
        public async Task<ActionResult<CourseTaskDTO>> PostCourse(CourseTaskDTO courseTaskDTO)
        {
            var courseTask = await courseTaskService.Edit(courseTaskDTO);

            if (courseTask == null)
                return BadRequest();

            return Ok(courseTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var deleted = await courseTaskService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
