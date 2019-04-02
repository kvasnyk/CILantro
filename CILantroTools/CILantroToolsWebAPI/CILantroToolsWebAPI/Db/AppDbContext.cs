using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Models.Tests.InputOutput;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CILantroToolsWebAPI.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Subcategory> Subcategories { get; set; }

        public DbSet<TestInputOutputExample> TestInputOutputExamples { get; set; }

        public DbSet<Run> Runs { get; set; }

        public DbSet<TestRun> TestRuns { get; set; }

        public DbSet<TestRunStepInfo> TestRunSteps { get; set; }

        public DbSet<TestRunStepItem> TestRunStepItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Test
            modelBuilder.Entity<Test>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Test>()
                .Property(t => t.IntId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Test>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tests)
                .HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Test>()
                .HasOne(t => t.Subcategory)
                .WithMany(s => s.Tests)
                .HasForeignKey(t => t.SubcategoryId);
            modelBuilder.Entity<Test>()
                .Property(t => t.Output)
                .HasConversion(
                    o => JsonConvert.SerializeObject(o, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() } ),
                    o => JsonConvert.DeserializeObject<InputOutput>(o, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() })
                );

            // Category
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            // Subcategory
            modelBuilder.Entity<Subcategory>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Subcategory>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(s => s.CategoryId);

            // TestInputOutputExample
            modelBuilder.Entity<TestInputOutputExample>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<TestInputOutputExample>()
                .HasOne(e => e.Test)
                .WithMany(t => t.IoExamples)
                .HasForeignKey(e => e.TestId);

            // Run
            modelBuilder.Entity<Run>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Run>()
                .Property(r => r.IntId)
                .ValueGeneratedOnAdd();

            // TestRun
            modelBuilder.Entity<TestRun>()
                .HasKey(tr => tr.Id);
            modelBuilder.Entity<TestRun>()
                .HasOne(tr => tr.Test)
                .WithMany()
                .HasForeignKey(tr => tr.TestId);
            modelBuilder.Entity<TestRun>()
                .HasOne(tr => tr.Run)
                .WithMany(r => r.TestRuns)
                .HasForeignKey(tr => tr.RunId);

            // TestRunStepInfo
            modelBuilder.Entity<TestRunStepInfo>()
                .HasKey(trsi => trsi.Id);
            modelBuilder.Entity<TestRunStepInfo>()
                .HasOne(trsi => trsi.TestRun)
                .WithMany(tr => tr.Steps)
                .HasForeignKey(trsi => trsi.TestRunId);

            // TestRunStepItem
            modelBuilder.Entity<TestRunStepItem>()
                .HasKey(trsi => trsi.Id);
            modelBuilder.Entity<TestRunStepItem>()
                .HasOne(trsi => trsi.Step)
                .WithMany(trsi => trsi.Items)
                .HasForeignKey(trsi => trsi.StepId);
        }
    }
}