using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tadas_SOA_Repeat_CA.Data;
using Tadas_SOA_Repeat_CA.Models;
using Tadas_SOA_Repeat_CA.Models.Dto;

namespace Tadas_SOA_Repeat_CA.Controllers
{
    [Route("api/TadasAPI/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly ApplicationDbContext _context;
        public GameController(ILogger<GameController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GameDTO>> GetGames()
        {
            _logger.LogInformation("Getting All Games");

            var games = _context.Games
                                .Include(g => g.Developer)
                                .Include(g => g.Publisher)
                                .ToList();

            var gameDTOs = games.Select(g => g.ToDTO()).ToList();

            return Ok(gameDTOs);
        }

        [HttpGet("{id:int}", Name = "GetGame")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GameDTO> GetGame(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Get Game Error with ID: " + id);
                return BadRequest();
            }
            var game = _context.Games.FirstOrDefault(u => u.Id == id);
            if (game == null)
            {
                return NotFound($"Game with ID {id} not found.");
            }
            return Ok(game.ToDTO());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GameDTO>> CreateGame([FromBody] GameDTO gameDTO)
        {
            if (gameDTO == null)
                return BadRequest();

            if (await _context.Games.AnyAsync(g => g.Name.ToLower() == gameDTO.Name.ToLower()))
            {
                ModelState.AddModelError("AlreadyExists", "Game with this Name already exists");
                return BadRequest(ModelState);
            }

            // Handle developer
            var developer = await _context.Developers.FirstOrDefaultAsync(d => d.Name.ToLower() == gameDTO.Developer.ToLower());
            if (developer == null)
            {
                developer = new Developer
                {
                    Name = gameDTO.Developer
                    // Add other properties if you have them in the DTO
                };

                await _context.Developers.AddAsync(developer);
                await _context.SaveChangesAsync();
            }

            var publisher = await _context.Publishers.FirstOrDefaultAsync(d => d.Name.ToLower() == gameDTO.Publisher.ToLower());
            if (publisher == null)
            {
                publisher = new Publisher
                {
                    Name = gameDTO.Publisher
                    // Add other properties if you have them in the DTO
                };

                await _context.Publishers.AddAsync(publisher);
                await _context.SaveChangesAsync();
            }

            // Create game with categories from DTO
            var game = new Game
            {
                Name = gameDTO.Name,
                Categories = gameDTO.Categories, // Directly assigning categories from DTO
                PublisherId = publisher.Id,
                DeveloperId = developer.Id,
                ReleaseDate = gameDTO.ReleaseDate,
                Owned = gameDTO.Owned,
                RecordCreationDate = DateTime.Now
            };

            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();

            gameDTO.Id = game.Id;

            return CreatedAtRoute("GetGame", new { id = gameDTO.Id }, gameDTO);
        }

        // IActionResult allows us to complete the Request without returning a GameDTO object
        [HttpDelete("{id:int}", Name = "RemoveGame")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoveGame(int id)
        {
            if (id <= 0)
            {
                _logger.LogError("Delete Game Error with ID: " + id);
                return BadRequest();
            }

            var game = _context.Games.FirstOrDefault(u => u.Id == id);
            if (game == null)
            {
                return NotFound($"Game with ID {id} not found.");
            }

            _context.Games.Remove(game);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] GameDTO gameInfoFromRequest)
        {
            if (gameInfoFromRequest == null || id != gameInfoFromRequest.Id)
                return BadRequest();

            var game = await _context.Games
                                     .Include(g => g.Developer)
                                     .Include(g => g.Publisher)
                                     .FirstOrDefaultAsync(u => u.Id == id);

            if (game == null)
                return NotFound($"Game with ID {id} not found.");

            if (gameInfoFromRequest.Name != "string"
                && gameInfoFromRequest.Developer != "string"
                && gameInfoFromRequest.Publisher != "string")
            {
                // Update basic properties
                game.Name = gameInfoFromRequest.Name;
                game.Owned = gameInfoFromRequest.Owned;

                // Handle developer
                var developer = await _context.Developers.FirstOrDefaultAsync(d => d.Name.ToLower() == gameInfoFromRequest.Developer.ToLower());
                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameInfoFromRequest.Developer
                        // Add other properties if you have them in the DTO
                    };
                    await _context.Developers.AddAsync(developer);
                    await _context.SaveChangesAsync();  // Save the developer immediately to get an ID
                }
                game.DeveloperId = developer.Id;

                var publisher = await _context.Publishers.FirstOrDefaultAsync(d => d.Name.ToLower() == gameInfoFromRequest.Publisher.ToLower());
                if (publisher == null)
                {
                    publisher = new Publisher
                    {
                        Name = gameInfoFromRequest.Publisher
                        // Add other properties if you have them in the DTO
                    };
                    await _context.Publishers.AddAsync(publisher);
                    await _context.SaveChangesAsync();  
                }
                game.PublisherId = publisher.Id;

                // Categories
                game.Categories = gameInfoFromRequest.Categories ?? new List<string>();

                await _context.SaveChangesAsync();

                return NoContent();
            }

            ModelState.AddModelError("", "Invalid Parameter value 'string'");
            return BadRequest(ModelState);
        }

        /*
        NOTE: Old Patch Route with local storage
        NOTE: Cannot figure out how to convert to use ApplicationDbContext
        
        [HttpPatch("{id:int}", Name = "UpdatePartialGame")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialGame(int id, JsonPatchDocument<GameDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
                return BadRequest();

            var game = GameStore.gameList.FirstOrDefault(u=>u.Id == id);
            if (game == null)
                return BadRequest();
            patchDTO.ApplyTo(game, ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return NoContent(); 

        }*/
    }
}
