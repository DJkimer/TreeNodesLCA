﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreesAPI.Data;

namespace TreesAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("TreesAPI.Models.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LeftId");

                    b.Property<int?>("RightId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("LeftId")
                        .IsUnique();

                    b.HasIndex("RightId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("TreesAPI.Models.Node", b =>
                {
                    b.HasOne("TreesAPI.Models.Node", "Left")
                        .WithOne()
                        .HasForeignKey("TreesAPI.Models.Node", "LeftId");

                    b.HasOne("TreesAPI.Models.Node", "Right")
                        .WithMany()
                        .HasForeignKey("RightId");
                });
#pragma warning restore 612, 618
        }
    }
}
