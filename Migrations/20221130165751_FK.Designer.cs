﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreFrontAPI.Model;

#nullable disable

namespace StoreFrontAPI.Migrations
{
    [DbContext(typeof(ClothContext))]
    [Migration("20221130165751_FK")]
    partial class FK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreFrontAPI.Model.AvailableSize", b =>
                {
                    b.Property<int>("SizeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeID"));

                    b.Property<string>("SizeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SizeID");

                    b.ToTable("availableSizes");
                });

            modelBuilder.Entity("StoreFrontAPI.Model.Clothes", b =>
                {
                    b.Property<int>("ClothId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClothId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClothId");

                    b.ToTable("clothes");
                });

            modelBuilder.Entity("StoreFrontAPI.Model.ClothesAndSize", b =>
                {
                    b.Property<int>("SizeID")
                        .HasColumnType("int");

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.HasKey("SizeID", "ClothId");

                    b.HasIndex("ClothId");

                    b.ToTable("clothesAndSizes");
                });

            modelBuilder.Entity("StoreFrontAPI.Model.KidsClothes", b =>
                {
                    b.Property<int>("KidClothID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KidClothID"));

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.Property<string>("KidClothName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KidClothType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clothesClothId")
                        .HasColumnType("int");

                    b.HasKey("KidClothID");

                    b.HasIndex("clothesClothId");

                    b.ToTable("kidsclothes");
                });

            modelBuilder.Entity("StoreFrontAPI.Model.ClothesAndSize", b =>
                {
                    b.HasOne("StoreFrontAPI.Model.Clothes", "clothes")
                        .WithMany("clothesAndSizes")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreFrontAPI.Model.AvailableSize", "availabesizes")
                        .WithMany("clothesAndSizes")
                        .HasForeignKey("SizeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("availabesizes");

                    b.Navigation("clothes");
                });

            modelBuilder.Entity("StoreFrontAPI.Model.KidsClothes", b =>
                {
                    b.HasOne("StoreFrontAPI.Model.Clothes", "clothes")
                        .WithMany("kidsClothes")
                        .HasForeignKey("clothesClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clothes");
                });

            modelBuilder.Entity("StoreFrontAPI.Model.AvailableSize", b =>
                {
                    b.Navigation("clothesAndSizes");
                });

            modelBuilder.Entity("StoreFrontAPI.Model.Clothes", b =>
                {
                    b.Navigation("clothesAndSizes");

                    b.Navigation("kidsClothes");
                });
#pragma warning restore 612, 618
        }
    }
}
