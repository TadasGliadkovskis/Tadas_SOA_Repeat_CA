﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tadas_SOA_Repeat_CA.Data;

#nullable disable

namespace Tadas_SOA_Repeat_CA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tadas_SOA_Repeat_CA.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Platform"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sandbox"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Survival"
                        });
                });

            modelBuilder.Entity("Tadas_SOA_Repeat_CA.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nintendo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mojang Studios"
                        });
                });

            modelBuilder.Entity("Tadas_SOA_Repeat_CA.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoriesJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Owned")
                        .HasColumnType("bit");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriesJson = "[\"Platform\",\"Action\"]",
                            DeveloperId = 1,
                            Name = "Super Mario Bros.",
                            Owned = true,
                            PublisherId = 1,
                            RecordCreationDate = new DateTime(2023, 8, 15, 21, 54, 22, 102, DateTimeKind.Local).AddTicks(6059),
                            ReleaseDate = new DateTime(1985, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CategoriesJson = "[\"Adventure\",\"Action\"]",
                            DeveloperId = 1,
                            Name = "The Legend of Zelda: Breath of the Wild",
                            Owned = true,
                            PublisherId = 1,
                            RecordCreationDate = new DateTime(2023, 8, 15, 21, 54, 22, 102, DateTimeKind.Local).AddTicks(6120),
                            ReleaseDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CategoriesJson = "[\"Sandbox\",\"Survival\"]",
                            DeveloperId = 2,
                            Name = "Minecraft",
                            Owned = false,
                            PublisherId = 2,
                            RecordCreationDate = new DateTime(2023, 8, 15, 21, 54, 22, 102, DateTimeKind.Local).AddTicks(6135),
                            ReleaseDate = new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Tadas_SOA_Repeat_CA.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nintendo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mojang"
                        });
                });

            modelBuilder.Entity("Tadas_SOA_Repeat_CA.Models.Game", b =>
                {
                    b.HasOne("Tadas_SOA_Repeat_CA.Models.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tadas_SOA_Repeat_CA.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Publisher");
                });
#pragma warning restore 612, 618
        }
    }
}
