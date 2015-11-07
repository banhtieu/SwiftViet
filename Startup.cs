using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.StaticFiles;
using Microsoft.Framework.Configuration;
using Microsoft.Dnx.Runtime;

using System;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2;
using MongoDB.Driver;
using SwiftViet.Data.Models;
using SwiftViet.Data.Repository;
using SwiftViet.Data.Repository.Mongo;

namespace SwiftViet
{
    public class Startup
    {


        /// <summary>
        /// The Configuration
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Start up the application
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                    .AddJsonFile("config.json");

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// Configure Dependencies Injection
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddInstance(Configuration);

            // initialize youtube service
            services.AddTransient(CreateYoutubeService);
            services.AddInstance(GetMongoDatabase());

            services.AddTransient<IRepository<Video>>(
                provider => new MongoRepository<Video>(provider.GetService<IMongoDatabase>())
            );
        }


        /// <summary>
        /// Get the mongodatabase
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IMongoDatabase GetMongoDatabase()
        {
            var mongoClient = new MongoClient(Configuration["Data:MongoConnection"]);
            return mongoClient.GetDatabase(Configuration["Data:MongoDBName"]);
        }

        /// <summary>
        /// Create a Youtube Service with ApiKey
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public YouTubeService CreateYoutubeService(IServiceProvider services)
        {

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = Configuration["Data:GoogleAPIKey"]
            });

            return service;
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseDefaultFiles(new DefaultFilesOptions() 
                { 
                    DefaultFileNames = new[] { "index.html" } 
                });
            app.UseStaticFiles();            
            app.UseMvc();
        }
    }
}
