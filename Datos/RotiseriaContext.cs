using Datos.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RotiseriaContext : DbContext

    {
        public RotiseriaContext() : base("RotiseriaContextDesktop")
        {
            Database.SetInitializer<RotiseriaContext>
                (new MigrateDatabaseToLatestVersion<RotiseriaContext, Configuration>());

        }



        public DbSet<Categoria> Categorias { get; set; }
    }
}
