using AlDarb.DTO;
using AlDarb.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class SessionTaskDatesController : BaseApiController
    {
        private readonly ISessionTaskDateService sessionTaskDateService;

        public SessionTaskDatesController(ISessionTaskDateService sessionTaskDateService)
        {
            this.sessionTaskDateService = sessionTaskDateService;
        }

        // GET: api/SessionTaskDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionTaskDateDTO>>> GetSessionTaskDate([FromQuery] int? sessionId, [FromQuery] int? taskId, bool includeDeleted)
        {
            var sessionTaskDatesDto = await sessionTaskDateService.GetList(sessionId, taskId, includeDeleted);
            return Ok(sessionTaskDatesDto);
        }

        // GET: api/SessionTaskDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionTaskDateDTO>> GetSessionTaskDate(int id, bool includeDeleted)
        {
            var sessionTaskDate = await sessionTaskDateService.GetById(id, includeDeleted);

            if (sessionTaskDate == null)
            {
                return NotFound();
            }

            return Ok(sessionTaskDate);
        }

        // PUT: api/SessionTaskDates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessionTaskDate(SessionTaskDateDTO sessionTaskDateDto)
        {
            var sessionTaskDate = await sessionTaskDateService.Edit(sessionTaskDateDto);
            
            if(sessionTaskDate == null)
                return BadRequest();

            return Ok(sessionTaskDate);
        }



        // POST: api/SessionTaskDates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SessionTaskDateDTO>> PostSessionTaskDate(SessionTaskDateDTO sessionTaskDateDto)
        {
            try
            {
                var sessionTaskDate = await sessionTaskDateService.Edit(sessionTaskDateDto);
                return Ok(sessionTaskDate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // DELETE: api/SessionTaskDates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSessionTaskDate(int id)
        {
            var deleted = await sessionTaskDateService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
