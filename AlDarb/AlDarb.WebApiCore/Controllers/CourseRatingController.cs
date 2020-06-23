using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class CourseRatingController : BaseApiController
    {
        private readonly ICourseRatingService courseRatingService;

        public CourseRatingController(ICourseRatingService courseRatingService)
        {
            this.courseRatingService = courseRatingService;
        }

        // GET: api/CourseRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseRatingDTO>>> GetCourseRating([FromQuery] int? userId, [FromQuery] int? courseId, bool includeDeleted)
        {
            var courseRatingsDto = await courseRatingService.GetList(userId, courseId, includeDeleted);
            return Ok(courseRatingsDto);
        }

        // GET: api/CourseRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseRatingDTO>> GetCourseRating(int id, bool includeDeleted)
        {
            var courseRating = await courseRatingService.GetById(id, includeDeleted);

            if (courseRating == null)
            {
                return NotFound();
            }

            return Ok(courseRating);
        }

        // PUT: api/CourseRatings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseRating(CourseRatingDTO courseRatingDto)
        {
            var courseRating = await courseRatingService.Edit(courseRatingDto);

            if (courseRating == null)
                return BadRequest();

            return Ok(courseRating);
        }



        // POST: api/CourseRatings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CourseRatingDTO>> PostCourseRating(CourseRatingDTO courseRatingDto)
        {
            var courseRating = await courseRatingService.Edit(courseRatingDto);

            if (courseRating == null)
                return BadRequest();

            return Ok(courseRating);
        }

        // DELETE: api/CourseRatings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourseRating(int id)
        {
            var deleted = await courseRatingService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
