using Invoice_Service.Data;
using Invoice_Service.Interfaces;
using Invoice_Service.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Invoice_Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Method called by the runtime adds services to the container.
        //Cross-origin resource sharing (CORS) 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
    //        services.AddAuthentication(options => {
    //            options.DefaultAuthenticateScheme = "JwtBearer";
    //            options.DefaultChallengeScheme = "JwtBearer";
    //        })
    //.AddJwtBearer("JwtBearer", jwtBearerOptions =>
    //{
    //    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
    //    {
    //        ValidateIssuerSigningKey = true,
    //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your secret goes here")),

    //        ValidateIssuer = true,
    //        ValidIssuer = "Invoice_Service",

    //        ValidateAudience = true,
    //        ValidAudience = "The name of the audience",

    //        ValidateLifetime = true, //validate the expiration and not before values in the token

    //        ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
    //    };
    //});


            services.AddMvc();

            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
        // To access Invoice Repository using DI model
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
        }
        
        // Method called by the runtime to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
