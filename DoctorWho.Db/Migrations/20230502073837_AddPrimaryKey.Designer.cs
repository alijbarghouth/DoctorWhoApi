﻿// <auto-generated />
using System;
using DoctorWho.Db;
using DoctorWho.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorWho.Db.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230502073837_AddPrimaryKey")]
    partial class AddPrimaryKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoctorWho.Db.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Companion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhoPlayed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companions");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FirstEpisodeDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEpisodeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<string>("Episodetype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EpsodeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeriesNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.EpisodeCompanion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanionId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanionId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("EpisodeCompanions");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.EpisodeEnemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EnemyId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnemyId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("EpisodeEnemies");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Episode", b =>
                {
                    b.HasOne("DoctorWho.Db.Model.Author", "Author")
                        .WithMany("Episodes")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.Model.Doctor", "Doctor")
                        .WithMany("Episodes")
                        .HasForeignKey("DoctorId");

                    b.Navigation("Author");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.EpisodeCompanion", b =>
                {
                    b.HasOne("DoctorWho.Db.Model.Companion", "Companion")
                        .WithMany("EpisodeCompanions")
                        .HasForeignKey("CompanionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.Model.Episode", "Episode")
                        .WithMany("EpisodeCompanions")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companion");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.EpisodeEnemy", b =>
                {
                    b.HasOne("DoctorWho.Db.Model.Enemy", "Enemy")
                        .WithMany("EpisodeEnemies")
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.Db.Model.Episode", "Episode")
                        .WithMany("EpisodeEnemies")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enemy");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Author", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Companion", b =>
                {
                    b.Navigation("EpisodeCompanions");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Doctor", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Enemy", b =>
                {
                    b.Navigation("EpisodeEnemies");
                });

            modelBuilder.Entity("DoctorWho.Db.Model.Episode", b =>
                {
                    b.Navigation("EpisodeCompanions");

                    b.Navigation("EpisodeEnemies");
                });
#pragma warning restore 612, 618
        }
    }
}
