using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;
using System;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class ApplicationForSessionsController : BaseApiController
    {
        private readonly IApplicationForSessionService applicationForSessionService;

        public ApplicationForSessionsController(IApplicationForSessionService applicationForSessionService)
        {
            this.applicationForSessionService = applicationForSessionService;
        }

        // GET: api/ApplicationForSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationForSessionDTO>>> GetApplicationForSession([FromQuery] int? userId, [FromQuery] int? sessionId, [FromQuery] DateTime? date, bool includeDeleted)
        {
            var applicationForSessionsDto = await applicationForSessionService.GetList(userId, sessionId, date, includeDeleted);
            return Ok(applicationForSessionsDto);
        }

        // GET: api/ApplicationForSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationForSessionDTO>> GetApplicationForSession(int id, bool includeDeleted)
        {
            var applicationForSession = await applicationForSessionService.GetById(id, includeDeleted);

            if (applicationForSession == null)
            {
                return NotFound();
            }

            return Ok(applicationForSession);
        }

        // PUT: api/ApplicationForSessions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationForSession(ApplicationForSessionDTO applicationForSessionDto)
        {
            var applicationForSession = await applicationForSessionService.Edit(applicationForSessionDto);

            if (applicationForSession == null)
                return BadRequest();

            return Ok(applicationForSession);
        }



        // POST: api/ApplicationForSessions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ApplicationForSessionDTO>> PostApplicationForSession(ApplicationForSessionDTO applicationForSessionDto)
        {
            var applicationForSession = await applicationForSessionService.Edit(applicationForSessionDto);

            if (applicationForSession == null)
                return BadRequest();

            return Ok(applicationForSession);
        }

        // DELETE: api/ApplicationForSessions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApplicationForSession(int id)
        {
            var deleted = await applicationForSessionService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
