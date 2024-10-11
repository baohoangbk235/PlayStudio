using Microsoft.AspNetCore.Mvc;
using PlayStudio.Server.Context;
using PlayStudio.Server.Model;

namespace PlayStudio.Server.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class EventClubController : ControllerBase
      {
            private readonly ILogger<EventClubController> _logger;
            private readonly PlayStudioContext _dbContext;

            public EventClubController(ILogger<EventClubController> logger, PlayStudioContext dbContext)
            {
                  _logger = logger;
                  _dbContext = dbContext;
            }

            [HttpGet("clubs/{clubId}/events")]
            public IEnumerable<ClubEvent> GetClubEventsByClub([FromRoute] Guid clubId)
            {
                  return _dbContext.Events.Where(e => e.ClubId == clubId);
            }

            [HttpPost("clubs/{clubId}/events")]
            public async Task<IActionResult> CreateClubEventsByClub([FromBody] CreateEventModel model, [FromRoute] Guid clubId)
            {
                  var club = await _dbContext.Clubs.FindAsync(clubId);

                  if (club == null)
                  {
                        return NotFound($"Not found game club with Id {clubId}");
                  }

                  _dbContext.Events.Add(new ClubEvent
                  {
                        Id = Guid.NewGuid(),
                        Title = model.Title,
                        Description = model.Description,
                        ScheduledDateTime = model.ScheduledDateTime,
                        Club = club,
                        ClubId = club.Id
                  });

                  await _dbContext.SaveChangesAsync();

                  return Created();
            }
      }
}
