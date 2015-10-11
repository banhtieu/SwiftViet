using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;

namespace SwiftTalkAPI
{
    public class Startup
    {
        /// Start up the application
        /// <param name="service">the environment
        public Startup(IHostingEnvironment env)
        {
        }

        ///
        /// Configure services for the application
        /// <param name="services">the list of services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseDefaultFiles(new Microsoft.AspNet.StaticFiles.DefaultFilesOptions() { DefaultFileNames = new[] { "index.html" } });
            app.UseStaticFiles();            
            app.UseMvc();
        }
    }
}
