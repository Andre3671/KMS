using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreApi.Models;

namespace CoreApi.Data
{
    public class CoreApiContext : DbContext
    {
        public CoreApiContext (DbContextOptions<CoreApiContext> options)
            : base(options)
        {
        }

        public DbSet<CoreApi.Models.Order> Order { get; set; }
        public DbSet<CoreApi.Models.Part> Part { get; set; }
    }
}
