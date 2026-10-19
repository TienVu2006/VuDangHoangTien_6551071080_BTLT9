using Serilog;

namespace Bai4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(AppContext.BaseDirectory, "logs", "log-.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new FormBanHang());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Lỗi khởi động ứng dụng");
                MessageBox.Show(
                    "Không thể khởi động ứng dụng.\n\n" +
                    "Kiểm tra SQL Server và chuỗi kết nối trong appsettings.json.\n\n" +
                    ex.Message,
                    "Quán trà sữa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}