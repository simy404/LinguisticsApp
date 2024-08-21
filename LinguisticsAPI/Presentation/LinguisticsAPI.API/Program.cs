using FluentValidation.AspNetCore;
using LinguisticsAPI.Application.Validators.Author;
using LinguisticsAPI.Infrastructure;
using LinguisticsAPI.Infrastructure.Services.Storage;
using LinguisticsAPI.Persistence;

namespace LinguisticsAPI.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//Add services to the container.
			builder.Services.AddPersistence();
			builder.Services.AddInfrastructure();
			
			//Add storage to the container.
			builder.Services.AddStorage<LocalStorage>();

			//CORS policy
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

			app.UseAuthorization();
			
			app.MapControllers();

			app.Run();
		}
	}
}
