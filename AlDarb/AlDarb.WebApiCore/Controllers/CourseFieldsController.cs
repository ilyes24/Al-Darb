using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;
using System;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class CourseFieldsController : BaseApiController
    {

        private readonly ICourseFieldService courseFieldService;

        public CourseFieldsController(ICourseFieldService courseFieldService)
        {
            this.courseFieldService = courseFieldService;
        }

        // GET: api/CourseFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseFieldDTO>>> GetCourseField([FromQuery] int? courseId, bool includeDeleted)
        {
            var courseFieldsDto = await courseFieldService.GetList(courseId, includeDeleted);
            return Ok(courseFieldsDto);
        }

        // GET: api/CourseFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseFieldDTO>> GetCourseField(int id, bool includeDeleted)
        {
            var courseField = await courseFieldService.GetById(id, includeDeleted);

            if (courseField == null)
            {
                return NotFound();
            }

            return Ok(courseField);
        }

        // PUT: api/CourseFields/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseField(CourseFieldDTO courseFieldDto)
        {
            var courseField = await courseFieldService.Edit(courseFieldDto);

            if (courseField == null)
                return BadRequest();

            return Ok(courseField);
        }



        // POST: api/CourseFields
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CourseFieldDTO>> PostCourseField(CourseFieldDTO courseFieldDto)
        {
            try
            {
                var courseField = await courseFieldService.Edit(courseFieldDto);
                return Ok(courseField);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/CourseFields/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourseField(int id)
        {
            var deleted = await courseFieldService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
