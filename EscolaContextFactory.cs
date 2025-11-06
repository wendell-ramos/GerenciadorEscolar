using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEscolarAPP.Data
{
    public class EscolaContextFactory : IDesignTimeDbContextFactory<EscolaContext>
    {
        public EscolaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EscolaContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GerenciamentoEscolarDB;Trusted_Connection=True;");
            return new EscolaContext(optionsBuilder.Options);
        }
    }
}
