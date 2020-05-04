using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook.Core.Models.Entities;

namespace PhoneBook.Data
{
    public sealed class PhoneBookDataContext : DbContext
    {
        private readonly string _connectionString;

        public PhoneBookDataContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("phoneBookDb");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString, builder => { builder.EnableRetryOnFailure(10); });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBookEntity>().HasData(new List<PhoneBookEntity>
            {
                new PhoneBookEntity { Id = Guid.Parse("3033d814-096d-41ad-9756-1651181392c7"), Name = "SampleUser1" }
            });
        }

        public DbSet<PhoneBookEntity> PhoneBooks { get; set; }
        public DbSet<EntryEntity> Entries { get; set; }
    }
}
