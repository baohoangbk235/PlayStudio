using Microsoft.AspNetCore.Mvc;
using PlayStudio.Server.Context;
using PlayStudio.Server.Model;
using System.Reflection.Metadata;

namespace PlayStudio.Server.Controllers
{
      [ApiController]
      [Route("[controller]")]
      public class GameClubController : ControllerBase
      {
            private readonly ILogger<GameClubController> _logger;
            private readonly PlayStudioContext _dbContext;

            public GameClubController(ILogger<GameClubController> logger, PlayStudioContext dbContext)
            {
                  _logger = logger;
                  _dbContext = dbContext;
            }

            [HttpGet("Clubs")]
            public IEnumerable<GameClub> GetAllClubs()
            {
                  return _dbContext.Clubs;
            }

            [HttpPost("Clubs")]
            public async Task<IActionResult> CreateNewClub([FromBody] CreateClubModel model)
            {
                  _dbContext.Add(new GameClub
                  {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Description = model.Description,
                  });
                  await _dbContext.SaveChangesAsync();
                  return Created();
            }

            [HttpPost("Clubs/search")]
            public IEnumerable<GameClub> GetClubsByParams([FromBody] SearchClubModel model)
            {
                  if (!string.IsNullOrEmpty(model.Param))
                  {
                        return _dbContext.Clubs.Where(c => c.Name.Contains(model.Param) || c.Description!.Contains(model.Param));
                  }
                  return _dbContext.Clubs;
            }
      }
}
