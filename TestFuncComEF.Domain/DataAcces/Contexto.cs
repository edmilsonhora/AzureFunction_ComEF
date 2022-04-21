using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFuncComEF.Domain.Models;

namespace TestFuncComEF.Domain.DataAcces
{
    public class Contexto : DbContext
    {
                

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyTesteDb.db");
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Contato> Contatos { get; set; }
    }

}