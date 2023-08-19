using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tadas_SOA_Repeat_CA.Data;
using Tadas_SOA_Repeat_CA.Models;
using Tadas_SOA_Repeat_CA.Models.Dto;

namespace Tadas_SOA_Repeat_CA.Controllers
{
    [Route("api/TadasAPI/developers")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly ILogger<DeveloperController> _logger;
        private readonly ApplicationDbContext _context;
        public DeveloperController(ILogger<DeveloperController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name= "GetAllDevelopers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<DevDTO>> GetDevelopers()
        {
            _logger.LogInformation("Getting All Developers");

            var developers = _context.Developers
                                .ToList();

            var devDTOs = developers.Select(d => d.ToDTO()).ToList();

            return Ok(devDTOs);
        }

        [HttpGet("{id:int}", Name = "GetDeveloper")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DevDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DevDTO> GetDeveloper(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Get Developer Error with ID: " + id);
                return BadRequest();
            }
            var developer = _context.Developers.FirstOrDefault(d => d.Id == id);
            if (developer == null)
            {
                return NotFound($"Developer with ID {id} not found.");
            }
            return Ok(developer.ToDTO());
        }

        [HttpPost("createdev/{name}", Name = "CreateDeveloper")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DevDTO>> CreateDeveloper(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Invalid developer name.");

            // Check if developer already exists
            var existingDeveloper = await _context.Developers.FirstOrDefaultAsync(d => d.Name.ToLower() == name.ToLower());
            if (existingDeveloper != null)
            {
                ModelState.AddModelError("AlreadyExists", "Developer with this name already exists.");
                return BadRequest(ModelState);
            }

            // Create new developer entity
            var newDeveloper = new Developer
            {
                Name = name
                // Add other properties if the Developer entity has more fields
            };

            // Add to context and save
            await _context.Developers.AddAsync(newDeveloper);
            await _context.SaveChangesAsync();

            // Create a DTO to return
            var devDTO = new DevDTO
            {
                Id = newDeveloper.Id,
                Name = newDeveloper.Name
            };

            return CreatedAtRoute("GetDeveloper", new { id = devDTO.Id }, devDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteDeveloper")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"Delete Developer Error: Invalid ID {id}");
                return BadRequest("Invalid ID provided.");
            }

            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return NotFound($"Developer with ID {id} not found.");
            }

            var gamesWithDeveloper = _context.Games.Where(g => g.DeveloperId == id).ToList();

            if (gamesWithDeveloper.Any())
            {
                _context.Games.RemoveRange(gamesWithDeveloper);
                await _context.SaveChangesAsync();
            }

            // Delete the developer
            _context.Developers.Remove(developer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }


}
