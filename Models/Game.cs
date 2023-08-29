using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tadas_SOA_Repeat_CA.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoriesJson { get; set; }

        // Allows bypass of creating a many to many relationship tables
        [NotMapped]
        public List<string> Categories
        {
            get
            {
                return string.IsNullOrEmpty(CategoriesJson)
                    ? new List<string>()
                    : JsonConvert.DeserializeObject<List<string>>(CategoriesJson);
            }
            set
            {
                CategoriesJson = JsonConvert.SerializeObject(value);
            }
        }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public bool Owned { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime RecordCreationDate { get; set; }
    }

    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
