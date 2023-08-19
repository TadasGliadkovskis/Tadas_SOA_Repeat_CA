using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tadas_SOA_Repeat_CA.Models.Dto
{  
    public class GameDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public List<string> Categories { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Owned { get; set; }
    }

    public class DevDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PubDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
