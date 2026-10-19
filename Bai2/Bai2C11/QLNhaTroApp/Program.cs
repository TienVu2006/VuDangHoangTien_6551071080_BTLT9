using Serilog;

namespace QLNhaTroApp;

static class Program
{
    [STAThread]
    static void Main()
    {
        // 1. Cấu hình Serilog: ghi file theo ngày vào thư mục Logs cạnh file .exe
        string logDir = Path.Combine(AppContext.BaseDirectory, "Logs");
        Directory.CreateDirectory(logDir);

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(
                path: Path.Combine(logDir, "log-.txt"),
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
            )
            .CreateLogger();

        Log.Information("Ứng dụng Quản lý nhà trọ bắt đầu khởi động.");

        // 2. Đăng ký xử lý lỗi toàn cục (Global Exception Handling)
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

        // Bắt lỗi trên UI Thread
        Application.ThreadException += (sender, e) =>
        {
            Log.Error(e.Exception, "Lỗi UI Thread chưa được xử lý: {Message}", e.Exception.Message);
            MessageBox.Show(
                "Đã xảy ra lỗi, thông tin đã được ghi lại.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        };

        // Bắt lỗi trên Non-UI / Background Thread
        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            if (e.ExceptionObject is Exception ex)
            {
                Log.Fatal(ex, "Lỗi AppDomain UnhandledException (nghiêm trọng): {Message}", ex.Message);
            }
            else
            {
                Log.Fatal("Lỗi không xác định AppDomain: {ExceptionObject}", e.ExceptionObject);
            }

            MessageBox.Show(
                "Đã xảy ra lỗi, thông tin đã được ghi lại.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        };

        try
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormKhachThue());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Lỗi trong vòng lặp Application.Run");
            MessageBox.Show(
                "Đã xảy ra lỗi, thông tin đã được ghi lại.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        finally
        {
            Log.Information("Ứng dụng Quản lý nhà trọ đã đóng.");
            Log.CloseAndFlush();
        }
    }
}