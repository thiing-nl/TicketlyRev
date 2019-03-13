using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Screend.Data;
using Screend.Exceptions;
using Screend.Repositories;
using Screend.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Screend
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Repositories
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<ITheaterRepository, TheaterRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Services
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<ITheaterService, TheaterService>();
            services.AddTransient<IUserService, UserService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(Configuration["secret"]);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            
            // Register the DatabaseContext
            services.AddDbContext<DatabaseContext>(
                options => options
                    .UseLazyLoadingProxies()
                    .UseMySql(Configuration.GetConnectionString("defaultConnection"))
            );
            
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
            });
            services.AddAutoMapper();
            
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    In = "header", 
                    Description = "Please insert JWT with Bearer into field", 
                    Name = "Authorization", 
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsDevelopment()) {
                app.UseHsts();
            }
            
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    if (context.Response.HasStarted)
                    {
                        throw;
                    }
                    
                    context.Response.ContentType = "application/json";
                    
                    switch (ex)
                    {
                        case NotFoundException nfe:
                            context.Response.StatusCode = (int) nfe.StatusCode;
                            break;
                        case BadRequestException bre:
                            context.Response.StatusCode = (int) bre.StatusCode;
                            break;
                        case ForbiddenException fe:
                            context.Response.StatusCode = (int) fe.StatusCode;
                            break;
                        default:
                            context.Response.StatusCode = 500;
                            break;
                    }
                    
                    try
                    {
                        var json = JToken.FromObject(ex);
                        await context.Response.WriteAsync(json.ToString());
                    }
                    catch (JsonSerializationException exception)
                    {
                        Debug.WriteLine(exception.Message);
                        var json = JToken.FromObject(new
                        {
                            ex.Message
                        });
                        await context.Response.WriteAsync(json.ToString());
                    }
                }
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticketly API");
            });

            // Use Auth
            app.UseAuthentication();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }
    }
}
