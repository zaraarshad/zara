using Microsoft.EntityFrameworkCore;
using zara_099_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zara_099_web.DataDb
{
    public class StoreDb : DbContext
    {
        public StoreDb(DbContextOptions<StoreDb> options) : base(options)
        {

        }
        public DbSet<OrderModel> orders { get; set; }
    }
}
