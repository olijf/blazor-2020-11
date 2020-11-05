using DemoProject.Backend.DataAccess;
using DemoProject.Backend.Repositories;
using DemoProject.Backend.Services;
using IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoProject.Backend
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			// dependency injection en globale instellingen
			services.AddDbContext<FrameworkDbContext>(options =>
			{
				options.UseSqlServer("Server=.; Database=frameworkdb; Integrated Security=true;");
			});

			services.AddScoped<IFrameworkRepository, FrameworkEntityRepository>();

			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", builder =>
				{
					builder.WithOrigins("https://localhost:5001")
						.AllowAnyHeader()
						.AllowCredentials()
						.AllowAnyHeader()
						.AllowAnyMethod();
				});
			});

			services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
			{
				options.Authority = "https://localhost:5999";
				options.TokenValidationParameters.NameClaimType = JwtClaimTypes.Name;
				options.Audience = "demoprojectbackend";
			});
			services.AddAuthorization(options =>
			{
				options.AddPolicy("onlybob", builder =>
				{
					builder.RequireClaim(JwtClaimTypes.Name, "Bob Smith");
				});
			});





			services.AddGrpc();

			// ASP.NET Core 3.0 - System.Text.Json
			services.AddControllers().AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
			});
			//services.AddControllers().AddJsonOptions(options =>
			//{
			//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
			//});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// iedere HTTP request

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseCors("AllowAll");

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseGrpcWeb();

			

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<FrameworkGrpcService>().EnableGrpcWeb().RequireCors("AllowAll");

				endpoints.MapControllers();
			});
		}
	}
}
