using Microsoft.EntityFrameworkCore;
using CarWash.Models;
using System.Collections.Generic;

namespace CarWash.Data
{
    public class CarWashDbContext : DbContext
    {
        public CarWashDbContext(DbContextOptions<CarWashDbContext> options) : base(options)
        {
        }

        public DbSet<CarWashModel> CarWash { get; set; }
    }
}
