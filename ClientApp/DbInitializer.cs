using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
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
                AuthorId = 1
            },
            new Track
            {
                Id = 2,
                Name = "Despacito",
                Year = 2017,
                Genre = "Latin pop",
                Language = "Spanish",
                AuthorId = 2
            },
            new Track
            {
                Id = 3,
                Name = "Cheri Cheri Lady",
                Year = 1985,
                Genre = "Pop",
                Language = "English",
                AuthorId = 3
            }


            }) ;
        }
        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
            new Author
            {
                Id = 1,
                Name = "Oleg",
                SurName = "Vinnik",
                LastName = "Anatolyevich",
                Nationality = "Ukraine",
            },
            new Author
            {
                Id = 2,
                Name = "Luis",
                SurName = "Fonsi",
                LastName = "Rodriguez",
                Nationality = "Puerto Rico",
            },

            new Author
            {
                Id = 3,
                Name = "Dieter",
                SurName = "Gunter",
                LastName = "Bohlen",
                Nationality = "Germany",
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
