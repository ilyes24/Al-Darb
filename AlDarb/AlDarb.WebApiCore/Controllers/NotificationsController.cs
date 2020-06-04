using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.DTO;
using System;

namespace AlDarb.WebApiCore.Controllers
{
    [Route("[controller]")]
    public class NotificationsController : BaseApiController
    {
        private readonly INotificationService notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        // GET: api/Notifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationDTO>>> GetNotification([FromQuery] int? userId, [FromQuery] DateTime? date, bool includeDeleted)
        {
            var notificationsDto = await notificationService.GetList(userId, date, includeDeleted);
            return Ok(notificationsDto);
        }

        // GET: api/Notifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationDTO>> GetNotification(int id, bool includeDeleted)
        {
            var notification = await notificationService.GetById(id, includeDeleted);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        // PUT: api/Notifications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotification(NotificationDTO notificationDto)
        {
            var notification = await notificationService.Edit(notificationDto);

            if (notification == null)
                return BadRequest();

            return Ok(notification);
        }



        // POST: api/Notifications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NotificationDTO>> PostNotification(NotificationDTO notificationDto)
        {
            var notification = await notificationService.Edit(notificationDto);

            if (notification == null)
                return BadRequest();

            return Ok(notification);
        }

        // DELETE: api/Notifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNotification(int id)
        {
            var deleted = await notificationService.Delete(id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
