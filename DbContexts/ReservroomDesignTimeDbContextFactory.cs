using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assetDevelopment.DbContexts
{
    public class ReservroomDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReservroomDbContext>
    {
        public ReservroomDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data source=reservroom.db").Options;
            return new ReservroomDbContext(options);
        }
    }
   
}
