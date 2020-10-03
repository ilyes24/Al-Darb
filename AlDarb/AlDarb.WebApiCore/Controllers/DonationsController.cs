using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;
using System;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class DonationsController : BaseApiController
    {
        private readonly IDonationService donationService;

        public DonationsController(IDonationService donationService)
        {
            this.donationService = donationService;
        }

        // GET: api/Donations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationDTO>>> GetDonation([FromQuery] int? userId, [FromQuery] int? postId, bool includeDeleted)
        {
            var donationsDto = await donationService.GetList(userId, postId, includeDeleted);
            return Ok(donationsDto);
        }

        // GET: api/Donations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationDTO>> GetDonation(int id, bool includeDeleted)
        {
            var donation = await donationService.GetById(id, includeDeleted);

            if (donation == null)
            {
                return NotFound();
            }

            return Ok(donation);
        }

        // PUT: api/Donations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonation(DonationDTO donationDto)
        {
            var donation = await donationService.Edit(donationDto);

            if (donation == null)
                return BadRequest();

            return Ok(donation);
        }



        // POST: api/Donations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DonationDTO>> PostDonation(DonationDTO donationDto)
        {
            try
            {
                var ilyes = donationDto;
                int i = 10;
                var donation = await donationService.Edit(donationDto);
                i = 20;
                return Ok(donation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Donations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDonation(int id)
        {
            var deleted = await donationService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
