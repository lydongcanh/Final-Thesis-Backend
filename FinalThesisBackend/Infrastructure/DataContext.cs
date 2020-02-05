using System;
using FinalThesisBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalThesisBackend.Infrastructure
{
    public class DataContext: DbContext
    {
        public DbSet<Category> Categories { get; protected set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
