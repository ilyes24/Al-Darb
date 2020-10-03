using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;
using System;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class DonationPostFieldsController : BaseApiController
    {

        private readonly IDonationPostFieldService donationPostFieldService;

        public DonationPostFieldsController(IDonationPostFieldService donationPostFieldService)
        {
            this.donationPostFieldService = donationPostFieldService;
        }

        // GET: api/DonationPostFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationPostFieldDTO>>> GetDonationPostField([FromQuery] int? donationPostId, bool includeDeleted)
        {
            var donationPostFieldsDto = await donationPostFieldService.GetList(donationPostId, includeDeleted);
            return Ok(donationPostFieldsDto);
        }

        // GET: api/DonationPostFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationPostFieldDTO>> GetDonationPostField(int id, bool includeDeleted)
        {
            var donationPostField = await donationPostFieldService.GetById(id, includeDeleted);

            if (donationPostField == null)
            {
                return NotFound();
            }

            return Ok(donationPostField);
        }

        // PUT: api/DonationPostFields/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonationPostField(DonationPostFieldDTO donationPostFieldDto)
        {
            var donationPostField = await donationPostFieldService.Edit(donationPostFieldDto);

            if (donationPostField == null)
                return BadRequest();

            return Ok(donationPostField);
        }



        // POST: api/DonationPostFields
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DonationPostFieldDTO>> PostDonationPostField(DonationPostFieldDTO donationPostFieldDto)
        {
            try
            {
                var donationPostField = await donationPostFieldService.Edit(donationPostFieldDto);
                return Ok(donationPostField);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/DonationPostFields/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDonationPostField(int id)
        {
            var deleted = await donationPostFieldService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
