using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string SurName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, MaxLength(100)]
        public string Nationality { get; set; }

        public ICollection<Track> Tracks { get; set; }

    }
}
