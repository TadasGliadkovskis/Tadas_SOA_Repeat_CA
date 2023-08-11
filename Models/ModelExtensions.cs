using Tadas_SOA_Repeat_CA.Models;
using Tadas_SOA_Repeat_CA.Models.Dto;
using System.Linq;

public static class ModelExtensions
{
    /*
    This extension was introduced to fix a bug when fetching all games with the api.
    Before the result for getAllGames was:
    {
    "id": 1,
    "name": "Super Mario Bros.",
    "categories": null,
    "publisher": "Nintendo",
    "developerId": 1,
    "developer": null,
    "owned": true,
    "releaseDate": "1985-09-13T00:00:00",
    "recordCreationDate": "2023-08-11T08:07:04.0309726",
    "gameCategories": null
  },
    to fix the nulls we create an extension of the SQL model and map it to the DTO
    so the client has a better result
     */

    public static GameDTO ToDTO(this Game game)
    {
        if (game == null) return null;

        return new GameDTO
        {
            Id = game.Id,
            Name = game.Name,
            Publisher = game.Publisher,
            Developer = game.Developer?.Name,
            ReleaseDate = game.ReleaseDate,
            Owned = game.Owned,
            Categories = game.Categories ?? new List<string>()
        };
    }

}

