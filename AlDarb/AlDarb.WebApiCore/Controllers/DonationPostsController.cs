using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;
using System;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class DonationPostsController : BaseApiController
    {
        private readonly IDonationPostService donationPostService;

        public DonationPostsController(IDonationPostService donationPostService)
        {
            this.donationPostService = donationPostService;
        }

        // GET: api/DonationPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationPostDTO>>> GetDonationPost([FromQuery] int? userId, int? fieldId, bool includeDeleted)
        {
            var donationPostsDto = await donationPostService.GetList(userId, fieldId, includeDeleted);
            return Ok(donationPostsDto);
        }

        // GET: api/DonationPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationPostDTO>> GetDonationPost(int id, bool includeDeleted)
        {
            var donationPost = await donationPostService.GetById(id, includeDeleted);

            if (donationPost == null)
            {
                return NotFound();
            }

            return Ok(donationPost);
        }

        // PUT: api/DonationPosts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonationPost(DonationPostDTO donationPostDto)
        {
            var donationPost = await donationPostService.Edit(donationPostDto);

            if (donationPost == null)
                return BadRequest();

            return Ok(donationPost);
        }



        // POST: api/DonationPosts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DonationPostDTO>> PostDonationPost(DonationPostDTO donationPostDto)
        {
            try
            {
                var ilyes = donationPostDto;
                int i = 10;
                var donationPost = await donationPostService.Edit(donationPostDto);
                i = 20;
                return Ok(donationPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/DonationPosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDonationPost(int id)
        {
            var deleted = await donationPostService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
