using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CILantroToolsWebAPI.Migrations
{
    public static class MigrationsHelper
    {
        public static void MigrateAndSeed(IHostingEnvironment env, IApplicationBuilder app)
        {
            // TODO: migrating here causes errors while using Add-Migration
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                AppDbContext context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();

                // seed categories & subcategories

                if (env.IsDevelopment())
                {
                    var categoriesSeed = Enumerable.Range(1, 25).Select(i => new Category
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Category {i}",
                        Subcategories = Enumerable.Range(1, 25).Select(j => new Subcategory
                        {
                            Id = Guid.NewGuid(),
                            Name = $"Subcategory {i} {j}"
                        }).ToList()
                    });

                    foreach (var category in categoriesSeed)
                    {
                        var existingCategory = context.Categories.SingleOrDefault(c => c.Name == category.Name);
                        if (existingCategory == null)
                        {
                            context.Categories.Add(category);
                        }
                    }

                    context.SaveChanges();
                }

                // seed tests

                if (env.IsDevelopment())
                {
                    var testsSeed = new List<Test>
                    {
                        new Test
                        {
                            Id = Guid.NewGuid(),
                            Name = "CSF_Basics_HelloWorld",
                            Path = @"\CILantroTests_CSharpFeatures\CSF_Basics_HelloWorld\bin\Release\CSF_Basics_HelloWorld.exe"
                        },
                        new Test
                        {
                            Id = Guid.NewGuid(),
                            Name = "CSF_Basics_Hello",
                            Path = @"\CILantroTests_CSharpFeatures\CSF_Basics_Hello\bin\Release\CSF_Basics_Hello.exe"
                        }
                    };

                    foreach (var test in testsSeed)
                    {
                        var existingTest = context.Tests.SingleOrDefault(t => t.Name == test.Name && t.Path == test.Path);
                        if (existingTest == null)
                        {
                            context.Tests.Add(test);
                        }
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}