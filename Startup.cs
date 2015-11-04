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
