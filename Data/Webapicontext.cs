using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechchallengeNoticias.Models;
using Webapiaspnet.Models;

namespace Webapiaspnet.Data
{
    public class WebapiContext : IdentityDbContext<Usuario>
    {
        public WebapiContext(DbContextOptions<WebapiContext> opts)
            : base(opts)
        {
                
        }
        public DbSet<Noticia> Noticia { get; set; }
    }
}