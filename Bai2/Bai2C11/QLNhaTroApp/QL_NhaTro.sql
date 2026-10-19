IF DB_ID('QL_NhaTro') IS NOT NULL
BEGIN
    ALTER DATABASE QL_NhaTro SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QL_NhaTro;
END
GO

CREATE DATABASE QL_NhaTro;
GO

USE QL_NhaTro;
GO

CREATE TABLE PhongTro (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(20) NOT NULL,
    GiaThue DECIMAL(18,0) NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL DEFAULT N'Trống'
);
GO

CREATE TABLE KhachThue (
    MaKhach INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    NgaySinh DATE NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    MaTinh INT NOT NULL,
    TenTinh NVARCHAR(100) NOT NULL,
    MaPhuongXa INT NOT NULL,
    TenPhuongXa NVARCHAR(100) NOT NULL,
    DaDangKyTamTru BIT NOT NULL DEFAULT 0,
    MaPhong INT NOT NULL,
    CONSTRAINT FK_KhachThue_PhongTro FOREIGN KEY (MaPhong) REFERENCES PhongTro(MaPhong) ON DELETE CASCADE
);
GO

-- Chèn sẵn 6 phòng trọ
INSERT INTO PhongTro (TenPhong, GiaThue, TinhTrang) VALUES
(N'P01', 1500000, N'Đang thuê'),
(N'P02', 1600000, N'Đang thuê'),
(N'P03', 1800000, N'Đang thuê'),
(N'P04', 2000000, N'Đang thuê'),
(N'P05', 1700000, N'Đang thuê'),
(N'P06', 2200000, N'Trống');
GO

-- Chèn vài khách thuê (khớp ví dụ ảnh chụp: Nguyễn Văn, Nguyễn Văn An ở P03, Trần Thị Bình ở P01, Lê Văn Cường ở P02, Phạm Minh Đức ở P04, Hoàng Thị Dung ở P05)
INSERT INTO KhachThue (HoTen, GioiTinh, NgaySinh, SoDienThoai, MaTinh, TenTinh, MaPhuongXa, TenPhuongXa, DaDangKyTamTru, MaPhong) VALUES
(N'Nguyễn Văn', N'Nam', '2000-01-15', '0912345678', 1, N'Thành phố Hà Nội', 4, N'Phường Ba Đình', 0, 3),
(N'Nguyễn Văn An', N'Nam', '2004-05-12', '0912345678', 1, N'Thành phố Hà Nội', 4, N'Phường Ba Đình', 1, 3),
(N'Trần Thị Bình', N'Nữ', '2002-08-20', '0876543210', 37, N'Tỉnh Ninh Bình', 10354, N'Xã Gia Trấn', 0, 1),
(N'Lê Văn Cường', N'Nam', '1999-11-03', '0901234567', 38, N'Tỉnh Thanh Hóa', 10402, N'Phường Ba Đình', 0, 2),
(N'Phạm Minh Đức', N'Nam', '2001-03-25', '0987654321', 38, N'Tỉnh Thanh Hóa', 10417, N'Phường Điện Biên', 0, 4),
(N'Hoàng Thị Dung', N'Nữ', '2003-07-14', '0765432109', 24, N'Thành phố Bắc Ninh', 9556, N'Phường Tiền An', 0, 5);
GO
