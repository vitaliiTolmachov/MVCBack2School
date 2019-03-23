using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _2_03_NetCoreMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Stopwatch timer;
            float duration,totalDuration,requestCounter;
            duration = totalDuration = requestCounter = 0;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.Use(middleware: async (context, next) =>
                {
                    timer = Stopwatch.StartNew();
                    await Task.Delay(new Random().Next(1, 1000));
                    duration = (float)timer.ElapsedTicks / Stopwatch.Frequency;

                    //#1
                    await context.Response.WriteAsync(
                        "<div style='color:red;'>TimerModule:</br>" +
                        $"Request time: {duration:F5} seconds" +
                        $"</div>");

                    await next();
                });

            app.Use(
                async (context, next) =>
                {
                    await next();

                    totalDuration += duration;
                    string result = $"<div style='color:blue;'>TotalTimeModule:</br>RequestCounter: {++requestCounter} </div>" +
                                    $"<div style='color:blue;'>Total time of requests: {totalDuration:F5} seconds </div>";
                    await context.Response.WriteAsync(result);

                });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
