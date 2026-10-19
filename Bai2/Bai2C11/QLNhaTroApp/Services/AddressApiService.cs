using System.Net.Http.Json;
using QLNhaTroApp.Models;
using Serilog;

namespace QLNhaTroApp.Services;

public class AddressApiService
{
    private static readonly HttpClient _httpClient = new()
    {
        Timeout = TimeSpan.FromSeconds(10)
    };

    private const string BaseUrl = "https://provinces.open-api.vn/api/v2/";

    public static async Task<List<ProvinceDto>?> GetProvincesAsync()
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProvinceDto>>(BaseUrl);
            return result;
        }
        catch (HttpRequestException ex)
        {
            Log.Warning(ex, "Lỗi kết nối mạng khi tải danh sách Tỉnh/Thành từ API.");
            throw;
        }
        catch (TaskCanceledException ex)
        {
            Log.Warning(ex, "Hết thời gian chờ (Timeout 10s) khi tải danh sách Tỉnh/Thành từ API.");
            throw;
        }
        catch (Exception ex)
        {
            Log.Warning(ex, "Lỗi không xác định khi tải danh sách Tỉnh/Thành từ API.");
            throw;
        }
    }

    public static async Task<List<WardDto>?> GetWardsAsync(int provinceCode)
    {
        try
        {
            string url = $"{BaseUrl}p/{provinceCode}?depth=2";
            var detail = await _httpClient.GetFromJsonAsync<ProvinceDetailDto>(url);
            return detail?.Wards;
        }
        catch (HttpRequestException ex)
        {
            Log.Warning(ex, "Lỗi kết nối mạng khi tải danh sách Phường/Xã cho tỉnh mã {ProvinceCode}.", provinceCode);
            throw;
        }
        catch (TaskCanceledException ex)
        {
            Log.Warning(ex, "Hết thời gian chờ (Timeout 10s) khi tải danh sách Phường/Xã cho tỉnh mã {ProvinceCode}.", provinceCode);
            throw;
        }
        catch (Exception ex)
        {
            Log.Warning(ex, "Lỗi không xác định khi tải danh sách Phường/Xã cho tỉnh mã {ProvinceCode}.", provinceCode);
            throw;
        }
    }
}
