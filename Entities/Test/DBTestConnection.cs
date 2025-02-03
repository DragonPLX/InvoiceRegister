using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.Entities.Test
{
    public class DBTestConnection
    {
        private InvoiceDbContext? appDbContext;
        public DBTestConnection(ServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                appDbContext = scope.ServiceProvider.GetService<InvoiceDbContext>();
                TestConnection();
            }
        }

        public void TestConnection()
        {
            if (appDbContext != null)
            {
                try
                {
                    if (appDbContext.Database.CanConnect())
                    {
                        Debug.WriteLine("Połaczenie do bazy danych jest prawidłowe");
                    }
                    else
                    {
                        Debug.WriteLine("Błąd połaczenia do bazy danych");
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

            }
            else
            {
                Debug.WriteLine("Brak rejestracji IvoiceDbContext");
            }
        }


    }
}
