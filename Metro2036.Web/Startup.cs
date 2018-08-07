﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Metro2036.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metro2036.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Metro2036.Data;
    using Metro2036.Web.Infrastructure.Extensions;
    using AutoMapper;
    using System;
    using Metro2036.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Dependency Injection Container!
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Use SQL Database if in Azure, otherwise, use Local SQL
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                    services.AddDbContext<Metro2036DbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("Metro2036Az")));
            else
                services.AddDbContext<Metro2036DbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Metro2036.Data")));

            //NO
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<Metro2036DbContext>();

            // From Lections
            services
                .AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<Metro2036DbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 4,
                    RequiredUniqueChars = 1,
                    RequireLowercase = false,
                    RequireDigit = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };

                // options.SignIn.RequireConfirmedEmail = true;
            });

            // Automatically perform database migration
            //services.BuildServiceProvider().GetService<Metro2036DbContext>().Database.Migrate();

            //Enforce lowercase routing
            //services.AddRouting(options => options.LowercaseUrls = true);

            //AutoMapper
            Mapper.Initialize(cfg => cfg.AddProfile<MetroProfile>());
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //TODO: Move Default to /Home?
            //services
            //    .AddMvc(options =>
            //    {
            //        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            //    })
            //    .AddRazorPagesOptions(options =>
            //    {
            //        options.Conventions.AddPageRoute("/Home/Index", "/");
            //    })
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                         name: "areaRoute",
                         template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                
                // default route for non-areas
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseMvcWithDefaultRoute();

            //TODO: Seed Database!
            app.SeedDatabase();
        }
    }
}
