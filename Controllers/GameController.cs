using Microsoft.AspNetCore.Mvc;
using Tadas_SOA_Repeat_CA.Models;

namespace Tadas_SOA_Repeat_CA.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            return new List<Game>
            {
                new Game{Id=1, Name="Doom"},
                new Game{Id=2, Name="Animal Crossing"}
            };
        }
    }
}
