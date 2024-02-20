using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_data.Models
{
    public class ServiceAppDbContext : DbContext
    {
        public ServiceAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }
    }
}
