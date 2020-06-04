using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class CoursesController : BaseApiController
    {

        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourse(bool includeDeleted)
        {
            var coursesDto = await courseService.GetList(includeDeleted);
            return Ok(coursesDto);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourse(int id, bool includeDeleted)
        {
            var course = await courseService.GetById(id, includeDeleted);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpGet("ByUserId/{id}")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCoursesByUserId(int id, bool includeDeleted)
        {
            var course = await courseService.GetByUserId(id, includeDeleted);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCoursesByName(string name, bool includeDeleted)
        {
            var course = await courseService.GetByName(name, includeDeleted);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(CourseDTO courseDto)
        {
            var course = await courseService.Edit(courseDto);
            
            if(course == null)
                return BadRequest();

            return Ok(course);
        }



        // POST: api/Courses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CourseDTO>> PostCourse(CourseDTO courseDto)
        {
            var course = await courseService.Edit(courseDto);
            
            if (course == null)
                return BadRequest();

            return Ok(course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var deleted = await courseService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
