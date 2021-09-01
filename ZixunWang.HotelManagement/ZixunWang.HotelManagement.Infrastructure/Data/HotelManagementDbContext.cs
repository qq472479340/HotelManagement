using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Entities;

namespace ZixunWang.HotelManagement.Infrastructure.Data
{
    public class HotelManagementDbContext: DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options): base(options)
        {

        }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomType>(ConfigureRoomType);
            modelBuilder.Entity<Room>(ConfigureRoom);
            modelBuilder.Entity<Service>(ConfigureService);
            modelBuilder.Entity<Customer>(ConfigureCustomer);
        }

        private void ConfigureRoomType(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("RoomTypes");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RTDESC).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(r => r.Rent).HasColumnType("money");
        }

        private void ConfigureRoom(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Status).HasColumnType("bit").HasColumnName("STATUS");
            builder.Property(r => r.RoomTypeId).HasColumnName("RTCODE");
        }

        private void ConfigureService(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SDESC).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(s => s.Amount).HasColumnType("money").HasColumnName("AMOUNT");
            builder.Property(s => s.RoomId).HasColumnName("ROOMNO");
            builder.Property(s => s.ServiceDate).HasColumnType("datetime");
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.RoomId).HasColumnName("ROOMNO");
            builder.Property(c => c.CName).HasColumnType("varchar").HasMaxLength(20).HasColumnName("CNAME");
            builder.Property(c => c.Address).HasColumnType("varchar").HasMaxLength(100).HasColumnName("ADDRESS");
            builder.Property(c => c.Phone).HasColumnType("varchar").HasMaxLength(20).HasColumnName("PHONE");
            builder.Property(c => c.Email).HasColumnType("varchar").HasMaxLength(40).HasColumnName("EMAIL");
            builder.Property(c => c.CheckIn).HasColumnType("datetime").HasColumnName("CHECKIN");
            builder.Property(c => c.TotalPersons).HasColumnName("TotalPERSONS");
            builder.Property(c => c.Advance).HasColumnType("money").HasColumnName("ADVANCE");
        }

    }
}
