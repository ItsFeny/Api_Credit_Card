using BackEndTarjetaCredito.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndTarjetaCredito
{
    public class ApplicationDbContext: DbContext
    {
        //importar el modelo & mapeo de modelo con la base de datos tarjetacreditodb es el nombre que tendra!
        public DbSet<CreditCard> TarjetaCreditoDB { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
