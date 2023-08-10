using Microsoft.AspNetCore.Mvc;
using Tadas_SOA_Repeat_CA.Data;
using Tadas_SOA_Repeat_CA.Models;
using Tadas_SOA_Repeat_CA.Models.Dto;

namespace Tadas_SOA_Repeat_CA.Controllers
{
    [Route("api/GamesAPI")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<GameDTO> GetGames()
        {
            return GameStore.gameList;
        }
        [HttpGet]
        public GameDTO GetGame(int id)
        {
            return GameStore.gameList.FirstOrDefault(u=u.Id==id);
        }
    }
}
