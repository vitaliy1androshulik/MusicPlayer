using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClientApp
{
    public class Track
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public int Year { get; set; }
        [Required, MaxLength(100)]
        public string Genre { get; set; }
        [Required, MaxLength(100)]
        public string Language { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
        
        public ICollection<PlayList> PlayLists { get; set; }

    }

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
    public class MusicPlayerDbContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Author> Autors { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-L9K9OL7\SQLEXPRESS;
                                        Initial Catalog = MusicPlayer;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //one to one
            modelBuilder.Entity<Track>()
                .HasOne(f => f.Author)
                .WithMany(f => f.Tracks)
                .HasForeignKey(f => f.AuthorId);



            //many to many

            modelBuilder.Entity<Track>()
                .HasMany(f => f.PlayLists)
                .WithMany(c => c.Tracks);


            modelBuilder.SeedAuthors();
            modelBuilder.SeedPlayLists();
            modelBuilder.SeedTracks();





        }
    }
}
