using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace QLChiTieu.Config;

/// <summary>
/// Lớp cấu hình strongly-typed ánh xạ từ appsettings.json
/// </summary>
public class AppConfig
{
    private static AppConfig? _current;
    public static AppConfig Current => _current ??= LoadConfiguration();

    public ConnectionStringsConfig ConnectionStrings { get; set; } = new();

    public static AppConfig LoadConfiguration()
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        var config = new AppConfig();
        configuration.Bind(config);

        // Fallback kiểm tra chuỗi kết nối
        if (string.IsNullOrWhiteSpace(config.ConnectionStrings.DefaultConnection))
        {
            var directConn = configuration.GetConnectionString("DefaultConnection");
            if (!string.IsNullOrWhiteSpace(directConn))
            {
                config.ConnectionStrings.DefaultConnection = directConn;
            }
        }

        _current = config;
        return config;
    }
}

public class ConnectionStringsConfig
{
    public string DefaultConnection { get; set; } = string.Empty;
}
