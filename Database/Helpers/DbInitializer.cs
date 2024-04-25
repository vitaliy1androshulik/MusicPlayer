using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Helpers
{
    public static class DbInitializer
    {
        public static void SeedTracks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>().HasData(new Track[]
            {
            new Track
            {
                Id = 1,
                Name = "she-wolf",
                Year = 2013,
                Genre = "pop",
                Language = "Ukrainian",
                Author = "Oleg Vinnik",
                FilePath = "wolf.wav"

            },
            new Track
            {
                Id = 2,
                Name = "Despacito",
                Year = 2017,
                Genre = "Latin pop",
                Language = "Spanish",
                Author = "Luis Fonsi",
                FilePath = "Despacito.wav"
            },
            new Track
            {
                Id = 3,
                Name = "Cheri Cheri Lady",
                Year = 1985,
                Genre = "Pop",
                Language = "English",
                Author = "Modern Talking",
                FilePath = "CheriCheriLady.wav"
            }
            });
        }
        public static void SeedPlayLists(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayList>().HasData(new PlayList[]
            {
            new PlayList
            {
                Id= 1,
                Name = "My",
                Genre = "to my taste",
                CountOfTracks = 3,
            }
            });
        }
    }
}
