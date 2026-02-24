using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webby.Core.Interfaces.Repositories;
using Webby.Core.Interfaces.Services;
using Webby.Infrastructure.Data;
using Webby.Infrastructure.Repositories;
using Webby.Infrastructure.Services;

namespace Webby.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebbyInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var provider = configuration["DatabaseProvider"];
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var hasRealDb = !string.IsNullOrWhiteSpace(connectionString)
                        && !string.IsNullOrWhiteSpace(provider);

        if (hasRealDb)
        {
            services.AddDbContext<WebbyDbContext>(options =>
            {
                if (provider == "MySQL")
                {
                    options.UseMySql(
                        connectionString!,
                        ServerVersion.AutoDetect(connectionString!),
                        sql => sql.MigrationsAssembly("Webby.Infrastructure"));
                }
                else if (provider == "PostgreSQL")
                {
                    options.UseNpgsql(
                        connectionString!,
                        sql => sql.MigrationsAssembly("Webby.Infrastructure"));
                }
                else
                {
                    throw new InvalidOperationException(
                        $"Unsupported DatabaseProvider: '{provider}'. Use 'MySQL' or 'PostgreSQL'.");
                }
            });

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
        }
        else
        {
            // No connection string configured — run with in-memory seed data
            services.AddSingleton<IPostRepository, InMemoryPostRepository>();
            services.AddSingleton<IPageRepository, InMemoryPageRepository>();
            services.AddSingleton<ISettingsRepository, InMemorySettingsRepository>();
        }

        services.AddScoped<ISettingsService, SettingsService>();

        return services;
    }
}
