using System.Text;
using FluentValidation.AspNetCore;
using LinguisticsAPI.Application.Mapping;
using LinguisticsAPI.Application.Validators.Author;
using LinguisticsAPI.Infrastructure;
using LinguisticsAPI.Infrastructure.Services.Storage;
using LinguisticsAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace LinguisticsAPI.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddPersistence();
			builder.Services.AddInfrastructure();
			
			// Add storage to the container.
			builder.Services.AddStorage<LocalStorage>();

			// CORS policy
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // todo Origin should be configured
			});
			
			// Fluent Validation
			builder.Services.AddControllers()
				.AddFluentValidation(configration => configration.RegisterValidatorsFromAssemblyContaining<AuthorCreateValidator>());

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // -> Bearer
				.AddJwtBearer(option => option.TokenValidationParameters = new()
				{
					ValidateIssuer = true, // -> Issuer(İşaretleyen)
					ValidateAudience = true, // -> Audience(Dinleyen)
					ValidateLifetime = true, 
					ValidateIssuerSigningKey = true, 
					
					ValidIssuer = builder.Configuration["Token:Issuer"],
					ValidAudience = builder.Configuration["Token:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecretKey"]))
				} );
			
			// AutoMapper
			builder.Services.AddAutoMapper(typeof(AuthorProfile));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			
			// wwwroot
			app.UseStaticFiles();
			
			// CORS
			app.UseCors("AllowAll");
			
			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();
			
			app.MapControllers();

			app.Run();
		}
	}
}
