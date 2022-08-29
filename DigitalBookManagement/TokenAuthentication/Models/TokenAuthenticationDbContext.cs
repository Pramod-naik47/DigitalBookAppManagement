using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TokenAuthentication.Models;

namespace TokenAuthentication.Models
{
    public partial class TokenAuthenticationDbContext : DbContext
    {
        public TokenAuthenticationDbContext()
        {
        }

        public TokenAuthenticationDbContext(DbContextOptions<TokenAuthenticationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:digitalbookmanagement.database.windows.net,1433;Initial Catalog=DigitalBookManagementdb;Persist Security Info=False;User ID=pramod;Password=prmd@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UserType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
