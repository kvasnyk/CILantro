﻿using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.ReadModels;
using CILantroToolsWebAPI.Services;
using CILantroToolsWebAPI.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CILantroToolsWebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowEverything",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDatabase")));

            services.AddScoped<AppKeyRepository<Category>>();
            services.AddScoped<AppKeyRepository<Test>>();
            services.AddScoped<AppKeyRepository<Subcategory>>();

            services.AddScoped<CategoriesService>();
            services.AddScoped<TestsService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                AppDbContext context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();

                #region seed

                // seed categories

                var categoriesSeed = Enumerable.Range(1, 25).Select(i => new Category
                {
                    Id = Guid.NewGuid(),
                    Name = $"Category {i}"
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

                #endregion
            }

            app.UseMvc();

            ReadModelMappingsFactory.RegisterMappings();
        }
    }
}