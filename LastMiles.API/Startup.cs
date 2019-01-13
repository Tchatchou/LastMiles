using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
/* 
using LastMiles.API.BusinessLogic.Communication;
using LastMiles.API.Repositories_UnitOfWork.UnitOfWorks;
using LastMiles.API.BusinessLogic.Identity; 
using LastMiles.API.DataBase;
*/
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using LastMiles.API.Helpers;
using Data_Base;
using Data_Base.DB_Identity_Management;
using Infrastructure.Communication.EmailSendgrid;
using Infrastructure.Communication.OrangeSMS;
using Data_Access_Layer.UnitOfWorks;
using Business_Layer.Identity;

namespace LastMiles.API
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
        {   //
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);

            builder.AddEntityFrameworkStores<DataContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,// ==> for prod istead of "Super secret key"
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddCors();
            services.AddSwaggerGen(c =>
                                    {
                                        c.SwaggerDoc("v1", new Info { Title = "Distribution api", Version = "v1" });
                                        c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                                                                                            {
                                                                                                Name = "Authorization",
                                                                                                In = "header",
                                                                                                Type = "apiKey",
                                                                                            });
                                        c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                                                                                {
                                                                                    { "Bearer", new string[] { } }
                                                                                });
                                  });
            services.AddMemoryCache();

            Mapper.Reset();
            services.AddAutoMapper();
            services.AddTransient<Seed>();


            services.AddScoped<IEmail, Email>(); // inject per new request done
            services.AddScoped<IOrangeSMSProvider, OrangeSMSProvider>();

        
            // unit of work injection
            services.AddScoped<IUnitOfWork_ReferenceData, UnitOfWork_ReferenceData>(); 
            services.AddScoped<IUnitOfWork_Identity, UnitOfWork_Identity>();

            services.AddScoped<IAccount_Creation, Account_Creation>();    
            services.AddScoped<IAccount_Queries, Account_Queries>();    
            services.AddScoped<IAccount_Update, Account_Update>();    
            services.AddScoped<IUser_Management, User_Management>();    
              
            services.AddScoped<IAuthentication, Authentication>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                                                       Seed seeder, ILoggerFactory loggerFactory)
        {
            //https://stackoverflow.com/questions/45022693/using-application-insights-with-iloggerfactory
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                /*   app.UseExceptionHandler(builder=>{
                      builder.Run(async context => {
                          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                         var error = context.Features.Get<IExceptionHandlerFeature>();

                        if(error!=null)
                        {
                           context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                      });
                  }); */
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //  app.UseHsts();
            }
            seeder.DataBaseSeeding();
            //   app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


           // app.UseStaticFiles(); //=> to create folder and customize ui
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
                //To serve the Swagger UI at the app's root (http://localhost:<port>/), set the RoutePrefix property to an empty string:
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();

            //https://stackoverflow.com/questions/11830338/web-api-creating-api-keys

            //https://developer.okta.com/blog/2018/02/01/secure-aspnetcore-webapi-token-auth
        }
    }
}
