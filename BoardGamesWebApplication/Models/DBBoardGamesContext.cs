using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BoardGamesWebApplication.Models
{
    public partial class DBBoardGamesContext : DbContext
    {
        public DBBoardGamesContext()
        {
        }

        public DBBoardGamesContext(DbContextOptions<DBBoardGamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgeCategory> AgeCategories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<NopCategory> NopCategories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<TypeGame> TypeGames { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=isttp1;Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeCategory>(entity =>
            {
                entity.ToTable("age_categories");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Nopid).HasColumnName("NOPId");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Age)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.AgeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("games_AgeId_fkey");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("games_GroupId_fkey");

                entity.HasOne(d => d.Nop)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.Nopid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("games_NOPId_fkey");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("groups");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("items_GameId_fkey");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("items_OrderId_fkey");
            });

            modelBuilder.Entity<NopCategory>(entity =>
            {
                entity.ToTable("nop_categories");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.DateTime).HasColumnType("timestamp without time zone");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("orders_CustomerId_fkey");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("orders_StateId_fkey");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("states");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("types");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeGame>(entity =>
            {
                entity.ToTable("type_game");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.TypeGames)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("type_game_GameId_fkey");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TypeGames)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("type_game_TypeId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
