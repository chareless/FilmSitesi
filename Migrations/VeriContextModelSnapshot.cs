﻿// <auto-generated />
using System;
using FilmSitesi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmSitesi.Migrations
{
    [DbContext(typeof(VeriContext))]
    partial class VeriContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FilmSitesi.Models.Anime", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("anime");
                });

            modelBuilder.Entity("FilmSitesi.Models.Movies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("movie");
                });

            modelBuilder.Entity("FilmSitesi.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("hakkında")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kategori")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("skor")
                        .HasColumnType("int");

                    b.Property<string>("süre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("yapımcı")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("FilmSitesi.Models.Series", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("serie");
                });

            modelBuilder.Entity("FilmSitesi.Models.Slider", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("FilmSitesi.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("cinsiyet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dogumTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sifre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("FilmSitesi.Models.Yorum", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.Property<string>("icerik")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("yorum");
                });

            modelBuilder.Entity("FilmSitesi.Models.Anime", b =>
                {
                    b.HasOne("FilmSitesi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FilmSitesi.Models.Movies", b =>
                {
                    b.HasOne("FilmSitesi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FilmSitesi.Models.Series", b =>
                {
                    b.HasOne("FilmSitesi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FilmSitesi.Models.Slider", b =>
                {
                    b.HasOne("FilmSitesi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FilmSitesi.Models.Yorum", b =>
                {
                    b.HasOne("FilmSitesi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
