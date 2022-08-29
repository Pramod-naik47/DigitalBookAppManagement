using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseBookApp.Models
{
    public partial class DigitalBookManagementContext : DbContext
    {
        public DigitalBookManagementContext()
        {
        }

        public DigitalBookManagementContext(DbContextOptions<DigitalBookManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;

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
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedDate");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("paymentDate");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
