﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayerApp.DAL_.EF;

#nullable disable

namespace NLayerApp.DAL_.Migrations
{
    [DbContext(typeof(MazeDbContext))]
    [Migration("20220215161024_AddingBasicEntities")]
    partial class AddingBasicEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NLayerApp.DAL_.Entities.Cell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CordinateX")
                        .HasColumnType("int");

                    b.Property<int>("CordinateY")
                        .HasColumnType("int");

                    b.Property<int>("MazeId")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MazeId");

                    b.ToTable("Cell");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("Stamina")
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HeroId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.Maze", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreaterId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("HeroId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreaterId");

                    b.HasIndex("HeroId");

                    b.ToTable("Mazes");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.Cell", b =>
                {
                    b.HasOne("NLayerApp.DAL_.Entities.Maze", "Maze")
                        .WithMany("Cells")
                        .HasForeignKey("MazeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maze");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.Item", b =>
                {
                    b.HasOne("NLayerApp.DAL_.Entities.Hero", "Hero")
                        .WithMany("Inventory")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.Maze", b =>
                {
                    b.HasOne("NLayerApp.DAL_.Entities.User", "Creater")
                        .WithMany("Mazes")
                        .HasForeignKey("CreaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NLayerApp.DAL_.Entities.Hero", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creater");

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.Hero", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.Maze", b =>
                {
                    b.Navigation("Cells");
                });

            modelBuilder.Entity("NLayerApp.DAL_.Entities.User", b =>
                {
                    b.Navigation("Mazes");
                });
#pragma warning restore 612, 618
        }
    }
}
