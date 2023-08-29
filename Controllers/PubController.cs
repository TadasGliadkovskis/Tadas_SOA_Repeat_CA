using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tadas_SOA_Repeat_CA.Data;
using Tadas_SOA_Repeat_CA.Models;
using Tadas_SOA_Repeat_CA.Models.Dto;

namespace Tadas_SOA_Repeat_CA.Controllers
{
    [Route("api/TadasAPI/publishers")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly ILogger<PublisherController> _logger;
        private readonly ApplicationDbContext _context;
        public PublisherController(ILogger<PublisherController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name ="GetAllPublishers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PubDTO>>> GetPublishers()
        {
            _logger.LogInformation("Getting All Publishers");

            var publishers = await _context.Publishers
                                .ToListAsync();

            var pubDTO = publishers.Select(p => p.ToDTO()).ToList();

            return Ok(pubDTO);
        }

        [HttpGet("{id:int}", Name = "GetPublisher")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PubDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PubDTO>> GetPublisher(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Get Publisher Error with ID: " + id);
                return BadRequest();
            }
            var publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Id == id);
            if (publisher == null)
            {
                return NotFound($"Publisher with ID {id} not found.");
            }
            return Ok(publisher.ToDTO());
        }

        [HttpPost("createpub/{name}", Name = "CreatePublisher")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PubDTO>> CreatePublisher(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Invalid publisher name.");

            var existingPublisher = await _context.Publishers.FirstOrDefaultAsync(d => d.Name.ToLower() == name.ToLower());
            if (existingPublisher != null)
            {
                ModelState.AddModelError("AlreadyExists", "Publisher with this name already exists.");
                return BadRequest(ModelState);
            }

            var newPublisher = new Publisher
            {
                Name = name
            };

            await _context.Publishers.AddAsync(newPublisher);
            await _context.SaveChangesAsync();

            // Create a DTO to return
            var pubDTO = new PubDTO
            {
                Id = newPublisher.Id,
                Name = newPublisher.Name
            };

            return CreatedAtRoute("GetPublisher", new { id = pubDTO.Id }, pubDTO);
        }

        [HttpDelete("{id:int}", Name = "DeletePublisher")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"Delete Publisher Error: Invalid ID {id}");
                return BadRequest();
            }

            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound($"Publisher with ID {id} not found.");
            }

            var gamesWithPublisher = _context.Games.Where(g => g.PublisherId == id).ToList();

            if (gamesWithPublisher.Any())
            {
                _context.Games.RemoveRange(gamesWithPublisher);
                await _context.SaveChangesAsync();
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
