﻿// <auto-generated />
using System;
using ChessTournament.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChessTournament.DAL.Migrations
{
    [DbContext(typeof(ChessTournamentContext))]
    partial class ChessTournamentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChessTournament.DL.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ChessTournament.DL.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ChessTournament.DL.Entities.Matchup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlackId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<Guid>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WhiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlackId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("WhiteId");

                    b.ToTable("Matchups");
                });

            modelBuilder.Entity("ChessTournament.DL.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<double>("Elo")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid>("Salt")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ChessTournament.DL.Entities.Tournament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentRound")
                        .HasColumnType("int");

                    b.Property<int?>("EloMax")
                        .HasColumnType("int");

                    b.Property<int?>("EloMin")
                        .HasColumnType("int");

                    b.Property<bool>("IsWomen")
                        .HasColumnType("bit");

                    b.Property<int>("MaxPlayer")
                        .HasColumnType("int");

                    b.Property<int>("MinPlayer")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegisterationDeadLine")
                        .HasColumnType("datetime2");

                    b.Property<int>("TournamentCategorie")
                        .HasColumnType("int");

                    b.Property<int>("TournamentStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("MemberTournament", b =>
                {
                    b.Property<Guid>("MembersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TournamentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MembersId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("MemberTournament");
                });

            modelBuilder.Entity("ChessTournament.DL.Entities.Address", b =>
                {
                    b.HasOne("ChessTournament.DL.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ChessTournament.DL.Entities.Matchup", b =>
                {
                    b.HasOne("ChessTournament.DL.Entities.Member", "Black")
                        .WithMany()
                        .HasForeignKey("BlackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChessTournament.DL.Entities.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChessTournament.DL.Entities.Member", "White")
                        .WithMany()
                        .HasForeignKey("WhiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Black");

                    b.Navigation("Tournament");

                    b.Navigation("White");
                });

            modelBuilder.Entity("ChessTournament.DL.Entities.Tournament", b =>
                {
                    b.HasOne("ChessTournament.DL.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MemberTournament", b =>
                {
                    b.HasOne("ChessTournament.DL.Entities.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChessTournament.DL.Entities.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}