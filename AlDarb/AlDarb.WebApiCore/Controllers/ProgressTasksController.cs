using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;
using System;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class ProgressTasksController : BaseApiController
    {
        private readonly IProgressTaskService progressTaskService;

        public ProgressTasksController(IProgressTaskService progressTaskService)
        {
            this.progressTaskService = progressTaskService;
        }

        // GET: api/ProgressTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgressTaskDTO>>> GetProgressTask([FromQuery] int? userId, [FromQuery] int? taskId, bool includeDeleted)
        {
            var progressTasksDto = await progressTaskService.GetList(taskId, userId, includeDeleted);
            return Ok(progressTasksDto);
        }

        // GET: api/ProgressTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgressTaskDTO>> GetProgressTask(int id, bool includeDeleted)
        {
            var progressTask = await progressTaskService.GetById(id, includeDeleted);

            if (progressTask == null)
            {
                return NotFound();
            }

            return Ok(progressTask);
        }

        // PUT: api/ProgressTasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgressTask(ProgressTaskDTO progressTaskDto)
        {
            var progressTask = await progressTaskService.Edit(progressTaskDto);

            if (progressTask == null)
                return BadRequest();

            return Ok(progressTask);
        }



        // POST: api/ProgressTasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProgressTaskDTO>> PostProgressTask(ProgressTaskDTO progressTaskDto)
        {
            var progressTask = await progressTaskService.Edit(progressTaskDto);

            if (progressTask == null)
                return BadRequest();

            return Ok(progressTask);
        }

        // DELETE: api/ProgressTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProgressTask(int id)
        {
            var deleted = await progressTaskService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
