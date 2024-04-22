using Database.Entities;
using Database.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClientApp
{
    public class MusicPlayerDbContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Author> Autors { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"workstation id=MusicPlayer.mssql.somee.com;
                                        packet size=4096;
                                        user id=VitaliySuper_SQLLogin_1;
                                        pwd=idx9uudiec;
                                        data source=MusicPlayer.mssql.somee.com;
                                        persist security info=False;
                                        initial catalog=MusicPlayer;
                                        TrustServerCertificate=True");
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
