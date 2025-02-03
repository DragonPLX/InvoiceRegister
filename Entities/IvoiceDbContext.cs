using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Entities
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) 
            : base(options) { }

        public DbSet<SubjectEntity> Subjects { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<ProductOrServiceEntity> ProductsOrServices { get; set; }
        public DbSet<DocumentTypeEnumEntity> DocumentTypes { get; set; }
        public DbSet<InvoiceTypeEnumEntity> InvoiceTypes { get; set; }
        public DbSet<PaymentTypeEnumEntity> PaymentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvoiceEntity>()
                .HasOne(i => i.Issuer)
                .WithMany()
                .HasForeignKey(i => i.IssuerNip)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceEntity>()
                .HasOne(p => p.Purchase)
                .WithMany()
                .HasForeignKey(p => p.PurchaseNip)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
