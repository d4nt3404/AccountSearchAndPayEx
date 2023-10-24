using AcountSearchAndPayment.Models;
using System.Data.Entity;

namespace SearchAccountEx.Models.Data
{
    public class InvoiceDbContext : DbContext
    {
        // DbSet properties
        public InvoiceDbContext() : base("InvoiceDbContext") { }

        // Define las propiedades DbSet para las entidades
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<PaymentTransaction> PaymentTransaction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
           .ToTable("Invoice");
            modelBuilder.Entity<PaymentTransaction>()
                .ToTable("PaymentTransaction");

            // Configure primary key for Invoice and PaymentTransaction
            modelBuilder.Entity<Invoice>().HasKey(i => i.InvoiceId);
            modelBuilder.Entity<PaymentTransaction>().HasKey(i => i.TransactionId);

            // Configure relation
            modelBuilder.Entity<PaymentTransaction>()
                .HasRequired(pt => pt.Invoice)
                .WithMany(i => i.PaymentTransactions)
                .HasForeignKey(pt => pt.InvoiceId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
