using System;
using CoreTvShowCall.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace CoreTvShowCall
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            Console.WriteLine("Context created");
        }

        public DbSet<ShowStore> ShowStores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Console.WriteLine("OnModelCreating");
        }
    }
}