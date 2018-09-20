using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankslip.Models
{
    /// <summary>
    /// Classe do DBContext para o Entityframework.
    /// No metodo OnConfiguring, é onde está conexão do arquivo de banco de dados.
    /// Banco: SQLite.
    /// </summary>
    public class DataBase : DbContext
    {
        public DbSet<bankslip> Bankslip { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
       
    }
}
