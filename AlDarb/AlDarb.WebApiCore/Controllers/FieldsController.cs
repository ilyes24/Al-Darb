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
    public class FieldsController : BaseApiController
    {

        private readonly IFieldService fieldService;

        public FieldsController(IFieldService fieldService)
        {
            this.fieldService = fieldService;
        }

        // GET: api/Fields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldDTO>>> GetField(bool includeDeleted)
        {
            var fieldsDto = await fieldService.GetList(includeDeleted);
            return Ok(fieldsDto);
        }

        // GET: api/Fields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FieldDTO>> GetField(int id, bool includeDeleted)
        {
            var field = await fieldService.GetById(id, includeDeleted);

            if (field == null)
            {
                return NotFound();
            }

            return Ok(field);
        }

        // PUT: api/Fields/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutField(FieldDTO fieldDto)
        {
            var field = await fieldService.Edit(fieldDto);

            if (field == null)
                return BadRequest();

            return Ok(field);
        }



        // POST: api/Fields
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FieldDTO>> PostField(FieldDTO fieldDto)
        {
            var field = await fieldService.Edit(fieldDto);

            if (field == null)
                return BadRequest();

            return Ok(field);
        }

        // DELETE: api/Fields/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteField(int id)
        {
            var deleted = await fieldService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
