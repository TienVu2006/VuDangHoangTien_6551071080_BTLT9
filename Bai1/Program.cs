using System;
using System.IO;
using System.Windows.Forms;
using QLChiTieu.Config;
using QLChiTieu.GUI;
using Serilog;

namespace QLChiTieu;

static class Program
{
    [STAThread]
    static void Main()
    {
        // 1. Cấu hình thư mục Logs cạnh file thực thi .exe theo ngày (Task 6)
        var logsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        if (!Directory.Exists(logsDir))
        {
            Directory.CreateDirectory(logsDir);
        }

        var logFilePath = Path.Combine(logsDir, "log-.txt");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(
                path: logFilePath,
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
            )
            .CreateLogger();

        try
        {
            Log.Information("=== Khởi động ứng dụng Sổ chi tiêu cá nhân ===");

            // 2. Tải cấu hình strongly-typed từ appsettings.json (Task 5)
            AppConfig.LoadConfiguration();
            Log.Information("Cấu hình hệ thống tải thành công. Chuỗi kết nối sẵn sàng.");

            // 3. Khởi tạo cấu hình giao diện WinForms
            ApplicationConfiguration.Initialize();

            // 4. Bắt lỗi toàn cục không mong muốn
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) =>
            {
                Log.Error(e.Exception, "Lỗi ThreadException chưa được bắt");
                MessageBox.Show("Đã xảy ra sự cố không mong muốn: " + e.Exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Fatal(ex, "Lỗi nghiêm trọng UnhandledException");
                }
            };

            Application.Run(new FormChiTieu());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ứng dụng bị dừng đột ngột do lỗi khởi động");
            MessageBox.Show("Không thể khởi động ứng dụng: " + ex.Message, "Lỗi khởi động", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        finally
        {
            Log.Information("=== Ứng dụng kết thúc phiên làm việc ===");
            Log.CloseAndFlush();
        }
    }
}