﻿using CILantro.Tools.WebAPI.Entities;
using System.Data.Entity;

namespace CILantro.Tools.WebAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }

        static ApplicationDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new ApplicationDbInitializer(true));
        }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // categories

            modelBuilder.Entity<CategoryEntity>()
                .ToTable("Categories")
                .HasKey(x => x.Id);
        }
    }
}