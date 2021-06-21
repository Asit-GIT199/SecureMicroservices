﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movies.Client.ApiServices;

namespace Movies.Client
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
            services.AddControllersWithViews();         

            services.AddScoped<IMovieApiService, MovieApiService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = "https://localhost:5005";

                    options.ClientId = "movies_mvc_client";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    //options.Scope.Add("address");
                    //options.Scope.Add("email");
                    //options.Scope.Add("roles");

                    //options.ClaimActions.DeleteClaim("sid");
                    //options.ClaimActions.DeleteClaim("idp");
                    //options.ClaimActions.DeleteClaim("s_hash");
                    //options.ClaimActions.DeleteClaim("auth_time");
                    //options.ClaimActions.MapUniqueJsonKey("role", "role");

                    //options.Scope.Add("movieAPI");

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    //options.TokenValidationParameters = new TokenValidationParameters
                    //{
                    //    NameClaimType = JwtClaimTypes.GivenName,
                    //    RoleClaimType = JwtClaimTypes.Role
                    //};
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
