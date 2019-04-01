﻿// <auto-generated />
using System;
using FeedbackUs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FeedbackUs.Migrations
{
    [DbContext(typeof(FeedUSContext))]
    [Migration("20190329095829_add one more thing")]
    partial class addonemorething
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FeedbackUs.Models.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsNotNegative");

                    b.Property<string>("Name");

                    b.Property<int?>("RatingId");

                    b.HasKey("Id");

                    b.HasIndex("RatingId");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("FeedbackUs.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<string>("RDURL");

                    b.HasKey("Id");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("FeedbackUs.Models.Content", b =>
                {
                    b.HasOne("FeedbackUs.Models.Rating")
                        .WithMany("Contents")
                        .HasForeignKey("RatingId");
                });
#pragma warning restore 612, 618
        }
    }
}
