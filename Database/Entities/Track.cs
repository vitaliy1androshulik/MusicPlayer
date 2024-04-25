using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Track
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string FilePath { get; set; }
        public int Year { get; set; }
        [Required, MaxLength(100)]
        public string Genre { get; set; }
        [Required, MaxLength(100)]
        public string Language { get; set; }

        public string Author { get; set; }

        public ICollection<PlayList> PlayLists { get; set; }

    }
}
