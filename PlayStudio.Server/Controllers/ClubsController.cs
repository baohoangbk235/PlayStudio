using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayStudio.Server.Context;
using PlayStudio.Server.Model;
using System.Net.Mime;

namespace PlayStudio.Server.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class ClubsController : ControllerBase
      {
            private readonly ILogger<ClubsController> _logger;
            private readonly PlayStudioContext _dbContext;

            public ClubsController(ILogger<ClubsController> logger, PlayStudioContext dbContext)
            {
                  _logger = logger;
                  _dbContext = dbContext;
            }

            [HttpGet()]
            public async IAsyncEnumerable<GameClub> GetAllClubsAsync()
            {
                  await foreach (var club in _dbContext.Clubs.AsAsyncEnumerable())
                  {
                        yield return club;
                  }
            }

            [HttpPost()]
            [Consumes(MediaTypeNames.Application.Json)]
            [ProducesResponseType(StatusCodes.Status201Created)]
            public async Task<IActionResult> CreateNewClubAsync([FromBody] CreateClubModel model)
            {
                  var newClub = new GameClub
                  {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Description = model.Description,
                  };
                  _dbContext.Clubs.Add(newClub);
                  await _dbContext.SaveChangesAsync();
                  return CreatedAtAction("CreateNewClub", new { id = newClub.Id }, newClub);
            }

            [HttpGet("search")]
            public async IAsyncEnumerable<GameClub> GetClubsByParamsAsync([FromQuery] string? param)
            {
                  param = param?.ToLower();
                  await foreach (var club in _dbContext.Clubs.AsAsyncEnumerable())
                  {
                        if (string.IsNullOrEmpty(param) || club.Name.ToLower().Contains(param) || club.Description.ToLower().Contains(param))
                        {
                              yield return club;
                        }
                  }
            }

            [HttpGet("{clubId}/events")]
            public async IAsyncEnumerable<ClubEvent> GetClubEventsByClubAsync([FromRoute] Guid clubId)
            {
                  var events = _dbContext.Events.Where(e => e.ClubId == clubId).AsAsyncEnumerable();
                  await foreach (var e in events)
                  {
                        yield return e;
                  }
            }

            [HttpPost("{clubId}/events")]
            [Consumes(MediaTypeNames.Application.Json)]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> CreateClubEventsByClubAsync([FromBody] CreateEventModel model, [FromRoute] Guid clubId)
            {
                  if (!DateTime.TryParse(model.ScheduledDateTime, out DateTime dateTime))
                  {
                        return BadRequest("Schedule date time is not in valid format");
                  }

                  var club = await _dbContext.Clubs.FindAsync(clubId);

                  if (club == null)
                  {
                        return NotFound($"Not found game club with Id {clubId}");
                  }

                  var newEvent = new ClubEvent
                  {
                        Id = Guid.NewGuid(),
                        Title = model.Title,
                        Description = model.Description,
                        ScheduledDateTime = dateTime,
                        Club = club,
                        ClubId = club.Id
                  };

                  _dbContext.Events.Add(newEvent);

                  await _dbContext.SaveChangesAsync();

                  return CreatedAtAction("CreateClubEventsByClub", new { id = newEvent.Id }, newEvent);
            }
      }
}
