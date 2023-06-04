using Application.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Application.Persistence.DataSeeders;

namespace Application.Database
{
    public interface IApplicationDbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelsOfTour> HotelsOfTours { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<TourOperator> TourOperators { get; set; }

        public DbSet<Transport> Transports { get; set; }

        public DbSet<TransportOfTour> TransportOfTours { get; set; }


        public DbSet<User> Users { set; get; }
    }
    public partial class TourAgencyContext : DbContext, IApplicationDbContext
    {
        public TourAgencyContext()
        {

            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public TourAgencyContext(DbContextOptions<TourAgencyContext> options) : base(options)
        {}

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Hotel> Hotels { get; set; }

        public virtual DbSet<HotelsOfTour> HotelsOfTours { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Tour> Tours { get; set; }

        public virtual DbSet<TourOperator> TourOperators { get; set; }

        public virtual DbSet<Transport> Transports { get; set; }

        public virtual DbSet<TransportOfTour> TransportOfTours { get; set; }


        public virtual DbSet<User> Users { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TourAgency;Trusted_Connection=False;TrustServerCertificate=False;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.HotelName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.City).WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Hotels_Cities");
            });

            modelBuilder.Entity<HotelsOfTour>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_HotelsOfTours_1");

                entity.HasOne(d => d.Hotel).WithMany(p => p.HotelsOfTours)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelsOfTours_Hotels");

                entity.HasOne(d => d.Tour).WithMany(p => p.HotelsOfTours)
                    .HasForeignKey(d => d.TourId)
                    .HasConstraintName("FK_HotelsOfTours_Tours");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Orders_Users");

                entity.HasOne(d => d.Tour).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TourId)
                    .HasConstraintName("FK_Orders_Tours");

                entity.HasOne(d => d.ToutOperator).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ToutOperatorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_TourOperators");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.Duration)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Price).HasColumnType("money");
                entity.Property(e => e.TourName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TourOperator>(entity =>
            {
                entity.HasKey(e => e.OperatorId);

                entity.Property(e => e.Fio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FIO");
                entity.Property(e => e.Resume)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("Transport");

                entity.Property(e => e.TypeOfTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransportOfTour>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_TransportOfTour_1");

                entity.ToTable("TransportOfTour");

                entity.HasOne(d => d.Tour).WithMany(p => p.TransportOfTours)
                    .HasForeignKey(d => d.TourId)
                    .HasConstraintName("FK_TransportOfTour_Tours");

                entity.HasOne(d => d.Transport).WithMany(p => p.TransportOfTours)
                    .HasForeignKey(d => d.TransportId)
                    .HasConstraintName("FK_TransportOfTour_Transport");
            });
            OnModelCreatingPartial(modelBuilder);

            // Custom application mappings
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_User_1");
                entity.Property(e => e.Username).HasMaxLength(450).IsRequired();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.DateOfBirth).HasColumnType("date");
                entity.Property(e => e.Fio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FIO");
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
            modelBuilder = DataSeederUsers.SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}