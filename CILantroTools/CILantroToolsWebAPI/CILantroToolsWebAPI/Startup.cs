﻿using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Hubs;
using CILantroToolsWebAPI.Middlewares;
using CILantroToolsWebAPI.Migrations;
using CILantroToolsWebAPI.ReadModels;
using CILantroToolsWebAPI.ReadModels.Categories;
using CILantroToolsWebAPI.ReadModels.Runs;
using CILantroToolsWebAPI.ReadModels.Tests;
using CILantroToolsWebAPI.Search;
using CILantroToolsWebAPI.Search.Mappers;
using CILantroToolsWebAPI.Services;
using CILantroToolsWebAPI.Settings;
using CILantroToolsWebAPI.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddSignalR();
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowEverything",
                    builder => builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(host => true)
                        .AllowCredentials()
                );
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDatabase")));

            services.AddScoped<AppKeyRepository<Category>>();
            services.AddScoped<AppKeyRepository<Test>>();
            services.AddScoped<AppKeyRepository<Subcategory>>();
            services.AddScoped<AppKeyRepository<TestInputOutputExample>>();
            services.AddScoped<AppKeyRepository<Run>>();
            services.AddScoped<AppKeyRepository<TestRun>>();
            services.AddScoped<AppKeyRepository<TestRunStepInfo>>();
            services.AddScoped<AppKeyRepository<TestRunStepItem>>();

            services.AddScoped<CategoriesService>();
            services.AddScoped<TestsService>();
            services.AddScoped<RunsService>();

            services.AddSingleton<HubExeRunner>();
            services.AddSingleton<HubRunRunner>();

            services.AddSingleton<TestsHelper>();

            services.AddSingleton<Paths>();

            services.AddSingleton<SearchMapper<TestReadModel>, TestSearchMapper>();
            services.AddSingleton<SearchMapper<CategoryReadModel>, CategorySearchMapper>();
            services.AddSingleton<SearchMapper<RunReadModel>, RunSearchMapper>();
            services.AddSingleton<SearchMapper<TestRunReadModel>, TestRunSearchMapper>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowEverything");
            app.UseMiddleware<ExceptionMiddleware>();

            MigrationsHelper.MigrateAndSeed(env, app);

            app.UseSignalR(options =>
            {
                options.MapHub<ExecuteTestHub>("/hubs/execute-test");
                options.MapHub<RunningRunHub>("/hubs/running-run");
            });
            app.UseMvc();

            ReadModelMappingsFactory.RegisterMappings();
        }
    }
}