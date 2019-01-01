namespace Metro2036.Web
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using AutoMapper;
    using Metro2036.Data;
    using Metro2036.Web.Infrastructure.Extensions;
    using Metro2036.Models;
    using Metro2036.Services.Implementations;
    using Metro2036.Services.Interfaces;

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

            // From Identity Configuration
            services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<Metro2036DbContext>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddDefaultTokenProviders();

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

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // Automatically perform database migration
            //services.BuildServiceProvider().GetService<Metro2036DbContext>().Database.Migrate();

            //Enforce lowercase routing
            //services.AddRouting(options => options.LowercaseUrls = true);

            //Application Services Dependency Injection
            ConfigureMetro2036Services(services);

            //AutoMapper
            Mapper.Initialize(cfg => cfg.AddProfile<MetroProfile>());
            services.AddAutoMapper(typeof(Startup));

            // Auto Mapper to be
            //services.AddAutoMapper();

            services
                .AddMvc(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                })
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/Home/Index", "/");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            //Prevent CSRF in ASP.NET Core
            services.AddMvc(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static void ConfigureMetro2036Services(IServiceCollection services)
        {
            //Dependency Injection Section
            // Point Service
            services.AddScoped<IPointService, PointService>();
            //Route Service
            services.AddScoped<IRouteService, RouteService>();
            //Station Service
            services.AddScoped<IStationService, StationService>();
            //Train Service
            services.AddScoped<ITrainService, TrainService>();
            //User Service
            services.AddScoped<IUserService, UserService>();
            //Timing Services
            services.AddScoped<ITimingService, TimingService>();
            //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseMvcWithDefaultRoute();

            //Seed Database!
            app.SeedDatabase();
        }
    }
}