using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountSearchAndPayment.Models.Data
{
    public interface IInvoiceDbContext : IDisposable
    {
        IDbSet<Invoice> Invoice { get; }
        IDbSet<PaymentTransaction> PaymentTransaction { get; set; }
        int SaveChanges();
    }
}
