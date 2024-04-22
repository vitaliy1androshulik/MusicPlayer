﻿// <auto-generated />
using ClientApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientApp.Migrations
{
    [DbContext(typeof(MusicPlayerDbContext))]
    [Migration("20240420142903_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientApp.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Autors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastName = "Anatolyevich",
                            Name = "Oleg",
                            Nationality = "Ukraine",
                            SurName = "Vinnik"
                        },
                        new
                        {
                            Id = 2,
                            LastName = "Rodriguez",
                            Name = "Luis",
                            Nationality = "Puerto Rico",
                            SurName = "Fonsi"
                        },
                        new
                        {
                            Id = 3,
                            LastName = "Bohlen",
                            Name = "Dieter",
                            Nationality = "Germany",
                            SurName = "Gunter"
                        });
                });

            modelBuilder.Entity("ClientApp.PlayList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountOfTracks")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PlayLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountOfTracks = 3,
                            Genre = "to my taste",
                            Name = "My"
                        });
                });

            modelBuilder.Entity("ClientApp.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Genre = "pop",
                            Language = "Ukrainian",
                            Name = "she-wolf",
                            Year = 2013
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Genre = "Latin pop",
                            Language = "Spanish",
                            Name = "Despacito",
                            Year = 2017
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Genre = "Pop",
                            Language = "English",
                            Name = "Cheri Cheri Lady",
                            Year = 1985
                        });
                });

            modelBuilder.Entity("PlayListTrack", b =>
                {
                    b.Property<int>("PlayListsId")
                        .HasColumnType("int");

                    b.Property<int>("TracksId")
                        .HasColumnType("int");

                    b.HasKey("PlayListsId", "TracksId");

                    b.HasIndex("TracksId");

                    b.ToTable("PlayListTrack");
                });

            modelBuilder.Entity("ClientApp.Track", b =>
                {
                    b.HasOne("ClientApp.Author", "Author")
                        .WithMany("Tracks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PlayListTrack", b =>
                {
                    b.HasOne("ClientApp.PlayList", null)
                        .WithMany()
                        .HasForeignKey("PlayListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientApp.Track", null)
                        .WithMany()
                        .HasForeignKey("TracksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClientApp.Author", b =>
                {
                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
