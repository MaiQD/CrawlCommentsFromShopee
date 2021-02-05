using App.Factories;
using App.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration _config)
		{
			//tạo dependency injection cho Token Service
			services.AddScoped<IApiServices, ApiServices>();
			services.AddScoped<IRatingFactory, RatingFactory>();
			services.AddScoped<IProductFactory, ProductFactory>();
			return services;
		}
	}
}
