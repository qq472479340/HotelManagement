﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZixunWang.HotelManagement.Infrastructure.Data;

namespace ZixunWang.HotelManagement.Infrastructure.Migrations
{
    [DbContext(typeof(HotelManagementDbContext))]
    [Migration("20210830162035_CreatingRoomTypes")]
    partial class CreatingRoomTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZixunWang.HotelManagement.ApplicationCore.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RTDESC")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal?>("Rent")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
