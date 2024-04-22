using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class PlayList
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public int CountOfTracks { get; set; }
        [Required, MaxLength(100)]
        public string Genre { get; set; }


        public ICollection<Track> Tracks { get; set; }


    }
}
