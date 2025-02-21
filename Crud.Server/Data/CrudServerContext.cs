using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crud.Server.Models;

namespace Crud.Server.Data
{
    public class CrudServerContext : DbContext
    {
        public CrudServerContext (DbContextOptions<CrudServerContext> options)
            : base(options)
        {
        }

        public DbSet<Crud.Server.Models.Item> Item { get; set; } = default!;
    }
}
