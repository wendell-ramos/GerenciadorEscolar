using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEscolarAPP.Data
{
    public static class DbHelper
    {
        public static EscolaContext CriarContexto()
        {
            var options = new DbContextOptionsBuilder<EscolaContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GerenciamentoEscolarDB;Trusted_Connection=True;");
            return new EscolaContext();
        }
    }
}
