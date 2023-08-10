using Tadas_SOA_Repeat_CA.Models.Dto;

namespace Tadas_SOA_Repeat_CA.Data
{
    public static class GameStore
    {
        public static List<GameDTO> gameList = new List<GameDTO>
            {
                new GameDTO{Id=1, Name="Doom"},
                new GameDTO{Id=2, Name="Animal Crossing"}
            };        
    }
}
