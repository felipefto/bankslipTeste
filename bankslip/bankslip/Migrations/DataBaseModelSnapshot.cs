﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bankslip.Models;

namespace bankslip.Migrations
{
    [DbContext(typeof(DataBase))]
    partial class DataBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("bankslip.Models.bankslip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("customer");

                    b.Property<DateTime>("due_date");

                    b.Property<decimal>("fine");

                    b.Property<DateTime>("payment_date");

                    b.Property<string>("status");

                    b.Property<decimal>("total_in_cents");

                    b.HasKey("Id");

                    b.ToTable("Bankslip");
                });
#pragma warning restore 612, 618
        }
    }
}