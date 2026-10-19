-- Script tạo CSDL và dữ liệu mẫu cho bài toán Quản lý chi tiêu
USE QL_ChiTieu;
GO

IF OBJECT_ID('dbo.ChiTieu', 'U') IS NOT NULL
    DROP TABLE dbo.ChiTieu;
GO

CREATE TABLE ChiTieu (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    NgayChi DATE NOT NULL,
    NoiDung NVARCHAR(100) NOT NULL,
    LoaiChi NVARCHAR(30) NOT NULL,
    SoTien DECIMAL(18,0) NOT NULL,
    GhiChu NVARCHAR(200) NULL
);
GO

-- Nhập sẵn ít nhất 10 dòng dữ liệu mẫu theo đúng đề bài
INSERT INTO ChiTieu (NgayChi, NoiDung, LoaiChi, SoTien, GhiChu)
VALUES
    ('2026-10-01', N'Cơm trưa', N'Ăn uống', 35000, N'Cơm văn phòng'),
    ('2026-10-02', N'Xăng xe', N'Đi lại', 60000, N'Đổ xăng đầy bình'),
    ('2026-10-03', N'Photo giáo trình', N'Học tập', 25000, N'Giáo trình C# WinForms'),
    ('2026-10-04', N'Xem phim', N'Giải trí', 90000, N'Vé rạp CGV cuối tuần'),
    ('2026-10-05', N'Trà sữa', N'Ăn uống', 40000, N'Trà sữa trân châu bạn bè'),
    ('2026-10-06', N'Mua sắm', N'Khác', 150000, N'Cá nhân'),
    ('2026-10-07', N'Tiền điện', N'Khác', 500000, N'Hóa đơn'),
    ('2026-10-08', N'Ăn sáng', N'Ăn uống', 25000, N'Ăn sáng'),
    ('2026-10-10', N'Mua sách giải thuật', N'Học tập', 120000, N'Sách cấu trúc dữ liệu và giải thuật'),
    ('2026-10-12', N'Sửa xe máy', N'Đi lại', 80000, N'Thay dầu nhớt định kỳ'),
    ('2026-10-15', N'Cà phê với bạn', N'Ăn uống', 45000, N'Gặp bạn cũ'),
    ('2026-10-18', N'Vé xe bus tháng', N'Đi lại', 100000, N'Vé tháng tuyến 01');
GO

SELECT MaCT, NgayChi, NoiDung, LoaiChi, SoTien, GhiChu FROM ChiTieu;
GO
