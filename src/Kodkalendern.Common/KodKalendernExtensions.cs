﻿using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace KodKalendern.Common;
public static class KodKalendernExtensions
{
    public static IServiceCollection AddAdventOfCodeCommon(this IServiceCollection services)
    {
        // Logging serilog to console
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

        services.AddTransient<IInputRepository, InputRepository>();

        return services;
    }

    public static IServiceCollection AddRangeTransient<TService>(this IServiceCollection services)
    {
        foreach (var dayService in typeof(TService).Assembly.GetTypes()
            .Where(x => typeof(TService).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract))
            services.AddTransient(dayService);

        return services;
    }
}
