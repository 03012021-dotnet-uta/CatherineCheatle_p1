using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using BusinessLogic;

namespace PrintStoreWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Set up connection string for connecting to database
            string connectionString = Configuration.GetConnectionString("PrintConnection");

            // add the db context
            services.AddDbContext<PrintStoreContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //Dependent resources that need to be called then disposed
            services.AddScoped<UserMethods>();

            //For abstraction of repo layer to add interface
            //services.AddScoped<PrintStoreRepoLayer>();

            services.AddScoped<PrintStoreRepoLayer>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PrintStoreWebApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrintStoreWebApp v1"));
            }

            // allows to use the static JS pages
            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            // use this to  redirect to the index HTML for any random path
            app.UseRewriter(new RewriteOptions()
                .AddRedirect("^$", "index.html"));

            // use the .js static files (find out what 'static' means)
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
