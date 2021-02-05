using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;

namespace App.Middleware
{
	public static class ExceptionMiddleware
	{

        /// <summary>
        /// Add exception handling
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseMyExceptionHandler(this IApplicationBuilder application, IHostingEnvironment hostingEnvironment)
        {

            var useDetailedExceptionPage =  hostingEnvironment.IsDevelopment();
            if (useDetailedExceptionPage)
            {
                //get detailed exceptions for developing and testing purposes
                application.UseDeveloperExceptionPage();
            }
            else
            {
                //or use special exception handler
                application.UseExceptionHandler("/Home/Error");
            }
			//log errors
			application.UseExceptionHandler(handler =>
			{
				handler.Run(context =>
				{
					var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
					if (exception == null)
						return Task.CompletedTask;
					try
					{

					}
					catch (Exception ex)
					{
						var err = ex;
					}
					finally
					{
						//rethrow the exception to show the error page
						throw exception;
					}
				});
			});
		}
    }
}
