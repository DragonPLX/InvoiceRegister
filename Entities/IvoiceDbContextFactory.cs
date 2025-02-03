using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Entities
{
    public class IvoiceDbContextFactory : IDesignTimeDbContextFactory<InvoiceDbContext>
    {
        public InvoiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InvoiceDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-S4PLRCE\\SRVINVOICE;Database=InvoiceDB;User Id=InvoiceUser;Password=InvoiceUser;TrustServerCertificate=True;");

            return new InvoiceDbContext(optionsBuilder.Options);
        }
    }
}
