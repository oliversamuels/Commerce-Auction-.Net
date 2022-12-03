﻿// <auto-generated />
using System;
using Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Commerce.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221201102555_Watchlist")]
    partial class Watchlist
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Commerce.Models.Bid", b =>
                {
                    b.Property<long>("BidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<long>("ListingId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId1")
                        .HasColumnType("varchar(255)");

                    b.HasKey("BidId");

                    b.HasIndex("UserId1");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("Commerce.Models.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("ListingId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("comments")
                        .HasColumnType("bigint");

                    b.HasKey("CommentId");

                    b.HasIndex("comments");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Commerce.Models.Listing", b =>
                {
                    b.Property<long>("ListingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("ActiveStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("StartAmount")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("WatchListId")
                        .HasColumnType("bigint");

                    b.Property<long?>("bids")
                        .HasColumnType("bigint");

                    b.HasKey("ListingId");

                    b.HasIndex("WatchListId");

                    b.HasIndex("bids")
                        .IsUnique();

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("Commerce.Models.WatchList", b =>
                {
                    b.Property<long>("WatchListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ListingId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("WatchListId");

                    b.ToTable("WatchLists");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("Commerce.Models.Bid", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Commerce.Models.Comment", b =>
                {
                    b.HasOne("Commerce.Models.Listing", "Listing")
                        .WithMany("Comments")
                        .HasForeignKey("comments");

                    b.Navigation("Listing");
                });

            modelBuilder.Entity("Commerce.Models.Listing", b =>
                {
                    b.HasOne("Commerce.Models.WatchList", null)
                        .WithMany("Listing")
                        .HasForeignKey("WatchListId");

                    b.HasOne("Commerce.Models.Bid", "Bids")
                        .WithOne("Listing")
                        .HasForeignKey("Commerce.Models.Listing", "bids");

                    b.Navigation("Bids");
                });

            modelBuilder.Entity("Commerce.Models.Bid", b =>
                {
                    b.Navigation("Listing");
                });

            modelBuilder.Entity("Commerce.Models.Listing", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Commerce.Models.WatchList", b =>
                {
                    b.Navigation("Listing");
                });
#pragma warning restore 612, 618
        }
    }
}
