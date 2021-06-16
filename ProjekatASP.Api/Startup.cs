using System;
using System.Collections.Generic;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProjekatASP.Api.Core;
using ProjekatASP.Application;
using ProjekatASP.Application.Interfaces.Email;
using ProjekatASP.EfDataAccess;
using ProjekatASP.Implementation.Commands;
using ProjekatASP.Implementation.Email;
using ProjekatASP.Implementation.Logging;
using ProjekatASP.Implementation.Queries;
using ProjekatASP.Implementation.Validators;

namespace ProjekatASP.Api
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
            var appSettings = new AppSettings();

            Configuration.Bind(appSettings);

            services.AddControllers();
            services.AddDbContext<ProjekatASPContext>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<GetBeansQuery>();
            services.AddTransient<CreateBeanCommand>();
            services.AddTransient<CreateBeanValidator>();
            services.AddTransient<UpdateBeanCommand>();
            services.AddTransient<UpdateBeanValidator>();
            services.AddTransient<DeleteBeanCommand>();
            services.AddTransient<GetOriginsQuery>();
            services.AddTransient<CreateOriginCommand>();
            services.AddTransient<CreateOriginValidator>();
            services.AddTransient<UpdateOriginCommand>();
            services.AddTransient<UpdateOriginValidator>();
            services.AddTransient<DeleteOriginCommand>();
            services.AddTransient<GetAmountsQuery>();
            services.AddTransient<CreateAmountCommand>();
            services.AddTransient<CreateAmountValidator>();
            services.AddTransient<UpdateAmountCommand>();
            services.AddTransient<UpdateAmountValidator>();
            services.AddTransient<DeleteAmountCommand>();
            services.AddTransient<GetCoffeesQuery>();
            services.AddTransient<CreateCoffeeCommand>();
            services.AddTransient<CreateCoffeeValidator>();
            services.AddTransient<UpdateCoffeeCommand>();
            services.AddTransient<UpdateCoffeeValidator>();
            services.AddTransient<DeleteCoffeeCommand>();
            services.AddTransient<GetOrdersQuery>();
            services.AddTransient<CreateOrderCommand>();
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<DeleteOrderCommand>();
            services.AddTransient<GetUseCaseLogsQuery>();
            services.AddTransient<CreateUserCommand>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<IEmailSender>(x => new SmtpEmailSender(appSettings.EmailFrom, appSettings.EmailPassword));
            services.AddAutoMapper(typeof(GetOriginsQuery).Assembly);
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x => 
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if(user.FindFirst("UserData") == null)
                {
                    return new UnregisteredActor();
                }

                var userString = user.FindFirst("UserData").Value;
                var userJwt = JsonConvert.DeserializeObject<JwtUser>(userString);

                return userJwt;
            });

            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<ProjekatASPContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseRouting();

            app.UseStaticFiles();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
