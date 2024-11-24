CREATE DATABASE QLKFC

GO
--drop databasE QLKFC
USE QLKFC;

set dateformat dmy

GO

-- Bảng Quan Ly Nhan Vien  
CREATE TABLE NhanVien (  
    MaNhanVien VARCHAR(30) PRIMARY KEY NOT NULL,  
	AnhNhanVien  VARBINARY(MAX),
    TenNhanVien NVARCHAR(250) NOT NULL,  
    GioiTinh NVARCHAR(3),  
    NgaySinh DATETIME,  
    SoDienThoai VARCHAR(15),  
    Email VARCHAR(150),  
    DiaChi NVARCHAR(300),  
    ChucVu NVARCHAR(100),  
    SoGioLam int 
); 


-- Bảng Tinh Luong Nhan Vien  
CREATE TABLE Luong (  
    MaNhanVien VARCHAR(30) NOT NULL,  
    Thang INT NOT NULL,  
	Nam INT NOT NULL,  
    LuongCoBan INT NOT NULL,  
    SoNgayLam INT NOT NULL,  
    SoGioLamThem INT , -- Số giờ làm thêm
    ThuongChuyenCan INT, -- Thưởng chuyên cần
    ThuongHieuSuat INT , -- Thưởng hiệu suất
    KhoanTru INT, -- Khoản trừ (thuế, bảo hiểm, v.v.)
    PRIMARY KEY (MaNhanVien, Thang, Nam),  
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)  
);  


-- Bảng Loai Hang  
CREATE TABLE LoaiHang (  
    MaLoaiHang VARCHAR(20) PRIMARY KEY NOT NULL,  
    TenLoaiHang NVARCHAR(150) NOT NULL  
);  

-- bảng nhà cung cấp
CREATE TABLE NhaCungCap (  
    MaNhaCungCap VARCHAR(10) PRIMARY KEY,  
    TenNhaCungCap NVARCHAR(100) NOT NULL,  
	AnhNhaCungCap  VARBINARY(MAX),
    DiaChi NVARCHAR(200),  
    SoDienThoai VARCHAR(10),  
    GhiChu NVARCHAR(200)  
);  

-- Bảng Kho  
CREATE TABLE Kho (  
    MaSanPham VARCHAR(30) PRIMARY KEY NOT NULL,  
    TenSanPham NVARCHAR(250) NOT NULL,  
    SoLuong INT NOT NULL,  
	DonViTinh NVARCHAR(50),  
	DonGia FLOAT, 
	NgaySanXuat DATE,
	NgayHetHan DATE,
    MaLoaiHang VARCHAR(20),  
    CONSTRAINT CK_SoLuong CHECK (SoLuong >= 0),  
    FOREIGN KEY (MaLoaiHang) REFERENCES LoaiHang(MaLoaiHang) 
);
 
-- Bảng NhapHang  
CREATE TABLE NhapHang (  
    MaNhapHang INT IDENTITY(1,1) PRIMARY KEY,  
    MaSanPham VARCHAR(30) NOT NULL,  
	TenSanPham NVARCHAR (100) null,
    SoLuong INT NOT NULL,  
    DonViTinh NVARCHAR(50),  
    DonGia FLOAT,  
    NgayNhap DATETIME NOT NULL,		
    MaLoaiHang VARCHAR(20),  
	MaNhaCungCap VARCHAR(10),
	NgaySanXuat DATE,
    NgayHetHan DATE,
    FOREIGN KEY (MaSanPham) REFERENCES Kho(MaSanPham),  
    FOREIGN KEY (MaLoaiHang) REFERENCES LoaiHang(MaLoaiHang),
	FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);  


-- Bảng Quan Ly Combo  
CREATE TABLE Combo (  
    MaCombo VARCHAR(30) PRIMARY KEY NOT NULL,  
    TenCombo NVARCHAR(250) NOT NULL,  
    GiaCombo int,  
	SoLuong int,
	PhanTramGiam int,
	NgayBatDau datetime,
    NgayKetThuc DATETIME  
); 


-- Bảng Chi Tiet Combo  
CREATE TABLE ChiTietCombo (  
    MaChiTietCombo INT PRIMARY KEY IDENTITY(1,1),  
    MaCombo VARCHAR(30) NOT NULL,  
    MaSanPham VARCHAR(30) NOT NULL,  
    SoLuong INT NOT NULL,  
    FOREIGN KEY (MaCombo) REFERENCES Combo(MaCombo),  
);

-- Bảng Quan Ly Thuc Don  
CREATE TABLE ThucDon (  
    MaSanPham VARCHAR(30) PRIMARY KEY NOT NULL,  
    TenSanPham NVARCHAR(250) NOT NULL,  
	HinhAnh VARBINARY(MAX),
    DonGia FLOAT,
	MaLoaiHang VARCHAR(20)
	FOREIGN KEY (MaSanPham) REFERENCES Kho(MaSanPham),  
FOREIGN KEY (MaLoaiHang) REFERENCES LoaiHang(MaLoaiHang)
);  

-- Bảng Quan Ly Khuyen Mai  
CREATE TABLE KhuyenMai (  
    MaKhuyenMai VARCHAR(12) PRIMARY KEY,  
    NgayBatDau DATETIME NOT NULL,  
    NgayKetThuc DATETIME NOT NULL,  
    GiaTriGiam DECIMAL(10, 2),  
    SoLuong INT,  
    TrangThai BIT  
);  

-- Bảng Quan Ly Ban  
CREATE TABLE Ban (  
    MaBan VARCHAR(20) PRIMARY KEY NOT NULL,  
    TenBan NVARCHAR(50) NOT NULL,
	ThoiGianDen DATETIME  NULL,
	ThoiGianRoi DATETIME  NULL,  
    TrangThaiBan BIT,
	MaDonDat VARCHAR(10) null
);  

-- Bảng Khach Hang Than Thiet  
CREATE TABLE KhachHangThanThiet (  
    MaKhachHang VARCHAR(30) PRIMARY KEY NOT NULL,  
    TenKhachHang NVARCHAR(250) NOT NULL,  
    SoDienThoai VARCHAR(15),   
    DiemTichLuy INT DEFAULT 0,  
);

-- bảng đơn đặt
CREATE TABLE DonDat (  
    MaDonDat VARCHAR(10) PRIMARY KEY,  
    MaBan VARCHAR(20)  NULL,  
	TongTien int,
    HinhThucThanhToan NVARCHAR(50),  
    SoTienNhan int NULL, 
    SoTienTra int NULL,  
	MaKhuyenMai VARCHAR(12) null,
	MaKhachHang VARCHAR(30) null,
    FOREIGN KEY (MaBan) REFERENCES Ban(MaBan)  ,
	FOREIGN KEY (MaKhuyenMai) REFERENCES KhuyenMai(MaKhuyenMai),
	FOREIGN KEY (MaKhachHang) REFERENCES KhachHangThanThiet(MaKhachHang)
);

-- Bảng chi tiết hóa đơn
CREATE TABLE ChiTietDonDat (  
	MaDonDat VARCHAR(10), 
    ID INT IDENTITY(1,1) PRIMARY KEY,  
    MaSanPham VARCHAR(30) NULL,
	SoLuong INT NOT NULL,   
	DonGia int NULL, 
	FOREIGN KEY (MaDonDat) REFERENCES DonDat(MaDonDat),
    FOREIGN KEY (MaSanPham) REFERENCES ThucDon(MaSanPham),  
);


-- Bảng Hoa Don  
CREATE TABLE HoaDon (  
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY, 
	MaDonDat VARCHAR(10), 
    NgayThanhToan DATETIME,   
    FOREIGN KEY (MaDonDat) REFERENCES DonDat(MaDonDat)  
);   

-- Bảng Doanh Thu  
CREATE TABLE DoanhThu (  
	MaNhapHang INT,
    Thang INT NOT NULL,  
    Nam INT NOT NULL,  
    NgayGhiNhan DATE NOT NULL,  
    MaHoaDon INT,  -- Kết nối với bảng HoaDon (Hóa đơn)  
    TongChiTieu FLOAT,  -- Tổng chi tiêu  
    TongDoanhThu FLOAT,  -- Tổng doanh thu  
    PRIMARY KEY (Thang, Nam, NgayGhiNhan),  
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),  
	FOREIGN KEY (MaNhapHang) REFERENCES NhapHang(MaNhapHang)
);


INSERT INTO NhanVien (MaNhanVien, AnhNhanVien, TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, ChucVu, SoGioLam) VALUES
('NV001', NULL, N'Nguyễn Văn A', N'Nam', '01/01/1990', '0123456789', 'vana@gmail.com', N'Hà Nội', N'Quản lý', 160),
('NV002', NULL, N'Trần Thị B', N'Nữ', '02/02/1991', '0123456780', 'thib@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV003', NULL, N'Lê Văn C', N'Nam', '03/03/1992', '0123456781', 'vanc@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV004', NULL, N'Phạm Thị D', N'Nữ', '04/04/1993', '0123456782', 'thid@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV005', NULL, N'Nguyễn Văn E', N'Nam', '05/05/1994', '0123456783', 'vane@gmail.com', N'Hà Nội', N'Quản lý', 160),
('NV006', NULL, N'Trần Thị F', N'Nữ', '06/06/1995', '0123456784', 'thif@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV007', NULL, N'Lê Văn G', N'Nam', '07/07/1996', '0123456785', 'vang@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV008', NULL, N'Phạm Thị H', N'Nữ', '08/08/1997', '0123456786', 'thih@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV009', NULL, N'Nguyễn Văn I', N'Nam', '09/09/1998', '0123456787', 'vani@gmail.com', N'Hà Nội', N'Quản lý', 160),
('NV010', NULL, N'Trần Thị J', N'Nữ', '10/10/1999', '0123456788', 'thij@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV011', NULL, N'Lê Văn K', N'Nam', '11/11/1988', '0123456789', 'vank@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV012', NULL, N'Phạm Thị L', N'Nữ', '12/12/1987', '0123456790', 'thil@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV013', NULL, N'Nguyễn Văn M', N'Nam', '13/01/1986', '0123456791', 'vanm@gmail.com', N'Hà Nội', N'Quản lý', 160),
('NV014', NULL, N'Trần Thị N', N'Nữ', '14/02/1985', '0123456792', 'thin@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV015', NULL, N'Lê Văn O', N'Nam', '15/03/1984', '0123456793', 'vano@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV016', NULL, N'Phạm Thị P', N'Nữ', '16/04/1983', '0123456794', 'thip@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV017', NULL, N'Nguyễn Văn Q', N'Nam', '17/05/1982', '0123456795', 'vanq@gmail.com', N'Hà Nội', N'Quản lý', 160),
('NV018', NULL, N'Trần Thị R', N'Nữ', '18/06/1981', '0123456796', 'thir@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV019', NULL, N'Lê Văn S', N'Nam', '19/07/1980', '0123456797', 'vans@gmail.com', N'Hà Nội', N'Nhân viên', 160),
('NV020', NULL, N'Phạm Thị T', N'Nữ', '20/08/1979', '0123456798', 'thit@gmail.com', N'Hà Nội', N'Nhân viên', 160);

INSERT INTO Luong (MaNhanVien, Thang, Nam, LuongCoBan, SoNgayLam, SoGioLamThem, ThuongChuyenCan, ThuongHieuSuat, KhoanTru) VALUES
('NV001', 10, 2024, 5000000, 22, 5, 500000, 300000, 100000),
('NV002', 10, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV003', 10, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV004', 10, 2024, 3500000, 22, 4, 200000, 150000, 70000),
('NV005', 10, 2024, 5000000, 22, 3, 500000, 300000, 100000),
('NV006', 10, 2024, 3500000, 22, 1, 200000, 150000, 70000),
('NV007', 10, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV008', 10, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV009', 10, 2024, 5000000, 22, 5, 500000, 300000, 100000),
('NV010', 10, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV011', 10, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV012', 10, 2024, 3500000, 22, 4, 200000, 150000, 70000),
('NV013', 10, 2024, 5000000, 22, 3, 500000, 300000, 100000),
('NV014', 10, 2024, 3500000, 22, 1, 200000, 150000, 70000),
('NV015', 10, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV016', 10, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV017', 10, 2024, 5000000, 22, 5, 500000, 300000, 100000),
('NV018', 10, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV019', 10, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV020', 10, 2024, 3500000, 22, 4, 200000, 150000, 70000),
('NV001', 9, 2024, 5000000, 22, 5, 500000, 300000, 100000),
('NV002', 9, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV003', 9, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV004', 9, 2024, 3500000, 22, 4, 200000, 150000, 70000),
('NV005', 9, 2024, 5000000, 22, 3, 500000, 300000, 100000),
('NV006', 9, 2024, 3500000, 22, 1, 200000, 150000, 70000),
('NV007', 9, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV008', 9, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV009', 9, 2024, 5000000, 22, 5, 500000, 300000, 100000),
('NV010', 9, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV011', 9, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV012', 9, 2024, 3500000, 22, 4, 200000, 150000, 70000),
('NV013', 9, 2024, 5000000, 22, 3, 500000, 300000, 100000),
('NV014', 9, 2024, 3500000, 22, 1, 200000, 150000, 70000),
('NV015', 9, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV016', 9, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV017', 9, 2024, 5000000, 22, 5, 500000, 300000, 100000),
('NV018', 9, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV019', 9, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV020', 9, 2024, 3500000, 22, 4, 200000, 150000, 70000),
('NV001', 8, 2024, 5000000, 22, 5, 500000, 300000, 100000),
('NV002', 8, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV003', 8, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV004', 8, 2024, 3500000, 22, 4, 200000, 150000, 70000),
('NV005', 8, 2024, 5000000, 22, 3, 500000, 300000, 100000),
('NV006', 8, 2024, 3500000, 22, 1, 200000, 150000, 70000),
('NV007', 8, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV008', 8, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV009', 8, 2024, 5000000, 22, 5, 500000, 300000, 100000),
('NV010', 8, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV011', 8, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV012', 8, 2024, 3500000, 22, 4, 200000, 150000, 70000),
('NV013', 8, 2024, 5000000, 22, 3, 500000, 300000, 100000),
('NV014', 8, 2024, 3500000, 22, 1, 200000, 150000, 70000),
('NV015', 8, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV016', 8, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV017', 8, 2024, 5000000, 22, 5, 500000, 300000, 100000),
('NV018', 8, 2024, 4000000, 22, 2, 300000, 200000, 80000),
('NV019', 8, 2024, 4000000, 22, 0, 300000, 200000, 80000),
('NV020', 8, 2024, 3500000, 22, 4, 200000, 150000, 70000);

-- Bảng Loại Hàng
INSERT INTO LoaiHang (MaLoaiHang, TenLoaiHang) VALUES
('GR', N'Gà Rán'),
('GQ', N'Gà Quay'),
('NUOC', N'Nước Uống'),
('TM', N'Tráng Miệng'),
('TAN', N'Thức Ăn Nhẹ'),
('BMC', N'Burger - Mì Ý - Cơm');

-- Bảng Kho 
INSERT INTO Kho (MaSanPham, TenSanPham, SoLuong, DonViTinh, DonGia, NgaySanXuat, NgayHetHan, MaLoaiHang)
VALUES
('GR001', N'Gà Rán Giòn', 100, N'Chiếc', 65000, '2024-12-01', '2025-06-30', 'GR'),
('GR002', N'Gà Rán Nguyên Tâm', 50, N'Chiếc', 70000, '2024-12-02', '2025-07-30', 'GR'),
('GR003', N'Gà Rán Cay', 90, N'Chiếc', 68000, '2024-12-30', '2025-07-30', 'GR'),
('GQ001', N'Gà Quay Nguyên Tâm', 80, N'Chiếc', 85000, '2024-12-15', '2025-06-15', 'GQ'),
('TM001', N'Bánh Tart', 150, N'Cái', 20000, '2024-12-20', '2025-04-20', 'TM'),
('TM002', N'Bánh trứng', 150, N'Cái', 20000, '2024-12-20', '2025-04-20', 'TM'),
('TM003', N'socola', 150, N'Cái', 20000, '2024-12-20', '2025-04-20', 'TM'),
('TM004', N'kem vani', 150, N'Cái', 20000, '2024-12-20', '2025-04-20', 'TM'),
('TM005', N'kem dâu', 150, N'Cái', 20000, '2024-12-20', '2025-04-20', 'TM'),
('TM006', N'kem socola', 150, N'Cái', 20000, '2024-12-20', '2025-04-20', 'TM'),
('TAN001', N'Khoai Tây Chiên', 120, N'Cái', 30000, '2024-12-15', '2025-08-15', 'TAN'),
('BMC001', N'Burger Gà', 80, N'Chiếc', 50000, '2024-12-25', '2025-05-25', 'BMC'),
('BMC002', N'Mì Ý', 70, N'Dĩa', 60000, '2024-12-05', '2025-05-05', 'BMC'),
('BMC003', N'Burger Gà quay', 80, N'Chiếc', 50000, '2024-12-25', '2025-05-25', 'BMC'),
('BMC004', N'burger gà rán', 70, N'Chiếc', 60000, '2024-12-05', '2025-05-05', 'BMC'),
('BMC005', N'Burger tôm', 80, N'Chiếc', 50000, '2024-12-25', '2025-05-25', 'BMC'),
('BMC006', N'cơm gà quay', 70, N'Dĩa', 60000, '2024-12-05', '2025-05-05', 'BMC'),
('BMC007', N'cơm gà rán', 70, N'Dĩa', 60000, '2024-12-05', '2025-05-05', 'BMC'),
('NUOC001', N'Nước Ngọt', 200, N'Lít', 15000, '2024-12-03', '2025-12-03', 'NUOC'),
('NUOC002', N'Nước Trái Cây', 180, N'Lít', 18000, '2024-12-01', '2025-12-01', 'NUOC'),
('NUOC003', N'CoCa', 160, N'Lít', 12000, '2024-03-11', '2024-04-11', 'NUOC'),
('NUOC004', N'Pepsi', 180, N'Lít', 18000, '2024-12-01', '2025-12-01', 'NUOC'),
('NUOC005', N'mirinda', 200, N'Lít', 15000, '2024-12-03', '2025-12-03', 'NUOC'),
('NUOC006', N'7 up', 180, N'Lít', 18000, '2024-12-01', '2025-12-01', 'NUOC');

-- Bảng Thực Đơn
INSERT INTO ThucDon (MaSanPham, TenSanPham, HinhAnh, DonGia, MaLoaiHang) VALUES
('GR001', N'Gà Rán Giòn', null, 65000, 'GR'),
('GR002', N'Gà Rán Nguyên Tâm', null, 70000,'GR'),
('GR003', N'Gà Rán Cay', null,68000,'GR'),
('GQ001', N'Gà Quay Nguyên Tâm', null,85000,'GQ'),
('TM001', N'Bánh Tart', null,20000,'TM'),
('TM002', N'Bánh trứng', null, 20000,'TM'),
('TM003', N'socola', null,20000,'TM'),
('TM004', N'kem vani', null,20000,'TM'),
('TM005', N'kem dâu', null,20000,'TM'),
('TM006', N'kem socola', null,20000,'TM'),
('TAN001', N'Khoai Tây Chiên', null,30000,'TAN'),
('BMC001', N'Burger Gà', null, 50000,'BMC'),
('BMC002', N'Mì Ý', null, 60000, 'BMC'),
('BMC003', N'Burger Gà quay', null,50000, 'BMC'),
('BMC004', N'burger gà rán', null, 60000,'BMC'),
('BMC005', N'Burger tôm', null, 50000, 'BMC'),
('BMC006', N'cơm gà quay', null, 60000,'BMC'),
('BMC007', N'cơm gà rán', null,60000, 'BMC'),
('NUOC001', N'Nước Ngọt', null, 15000,'NUOC'),
('NUOC002', N'Nước Trái Cây', null,18000, 'NUOC'),
('NUOC003', N'CoCa', null, 12000,'NUOC'),
('NUOC004', N'Pepsi', null, 18000,'NUOC'),
('NUOC005', N'mirinda', null,15000,'NUOC'),
('NUOC006', N'7 up', null,18000,'NUOC');

-- Bảng Nhà Cung Cấp
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, AnhNhaCungCap, DiaChi, SoDienThoai, GhiChu) VALUES
('NCC01', N'Nhà Cung Cấp A', NULL, N'Địa chỉ NCC A', '0123456789', N'Nhà cung cấp thực phẩm'),
('NCC02', N'Nhà Cung Cấp B', NULL, N'Địa chỉ NCC B', '0987654321', N'Nhà cung cấp nước uống'),
('NCC03', N'Nhà Cung Cấp C', NULL, N'Địa chỉ NCC C', '0912345678', N'Nhà cung cấp đồ ăn nhẹ'),
('NCC04', N'Nhà Cung Cấp D', NULL, N'Địa chỉ NCC D', '0981234567', N'Nhà cung cấp bánh ngọt'),
('NCC05', N'Nhà Cung Cấp E', NULL, N'Địa chỉ NCC E', '0962345671', N'Nhà cung cấp nước giải khát'),
('NCC06', N'Nhà Cung Cấp F', NULL, N'Địa chỉ NCC F', '0932123456', N'Nhà cung cấp gia vị'),
('NCC07', N'Nhà Cung Cấp G', NULL, N'Địa chỉ NCC G', '0901122334', N'Nhà cung cấp nguyên liệu'),
('NCC08', N'Nhà Cung Cấp H', NULL, N'Địa chỉ NCC H', '0922133445', N'Nhà cung cấp bánh'),
('NCC09', N'Nhà Cung Cấp I', NULL, N'Địa chỉ NCC I', '0987654444', N'Nhà cung cấp trái cây'),
('NCC10', N'Nhà Cung Cấp J', NULL, N'Địa chỉ NCC J', '0976543333', N'Nhà cung cấp rau củ');

-- Bảng Khách Hàng 
INSERT INTO KhachHangThanThiet (MaKhachHang, TenKhachHang, SoDienThoai, DiemTichLuy) VALUES 
('KH001', N'Nguyễn Văn An', '0123456000', 100),
('KH002', N'Trần Thị Bích', '0123456001', 10),
('KH003', N'Nguyễn Thị Cẩm', '0123456002', 50),
('KH004', N'Phạm Văn Dương', '0123456003', 90),
('KH005', N'Đỗ Thị Hạnh', '0123456004', 150),
('KH006', N'Lê Văn Hùng', '0123456005', 120),
('KH007', N'Nguyễn Văn Hòa', '0123456006', 55),
('KH008', N'Vũ Thị Minh', '0123456007', 15),
('KH009', N'Hồ Văn Khánh', '0123456008', 140),
('KH010', N'Vũ Thị Ngọc', '0123456009', 20),
('KH011', N'Tôn Thị Lan', '0123456010', 150),
('KH012', N'Nguyễn Văn Phú', '0123456011', 100),
('KH013', N'Trần Thị Xuân', '0123456012', 10),
('KH014', N'Nguyễn Thị Liên', '0123456013', 50),
('KH015', N'Phạm Văn Cường', '0123456014', 90),
('KH016', N'Đỗ Thị Mai', '0123456015', 150),
('KH017', N'Lê Văn Quân', '0123456016', 120),
('KH018', N'Nguyễn Văn Bảo', '0123456017', 55),
('KH019', N'Hồ Văn Lâm', '0123456018', 140),
('KH020', N'Tôn Thị Huệ', '0123456019', 150),
('KH021', N'Lý Văn Thành', '0123456020', 80),
('KH022', N'Trịnh Thị Vân', '0123456021', 25),
('KH023', N'Nguyễn Thị Phương', '0123456022', 70),
('KH024', N'Phạm Văn Tuấn', '0123456023', 110),
('KH025', N'Đỗ Thị Hà', '0123456024', 95),
('KH026', N'Lê Văn Tâm', '0123456025', 130),
('KH027', N'Nguyễn Văn Sang', '0123456026', 60),
('KH028', N'Vũ Thị Yến', '0123456027', 40),
('KH029', N'Hồ Văn Bình', '0123456028', 120),
('KH030', N'Tôn Thị Nhung', '0123456029', 50);

INSERT INTO Ban (MaBan, TenBan, ThoiGianDen, ThoiGianRoi, TrangThaiBan, MaDonDat)
VALUES 
    ('B001', 'Bàn 1', null, null, 0 , null), 
    ('B002', 'Bàn 2', null, null, 0 , null),
    ('B003', 'Bàn 3', null, null, 0 , null),  
    ('B004', 'Bàn 4',  null, null, 0 , null), 
    ('B005', 'Bàn 5', null, null, 0 , null),  
    ('B006', 'Bàn 6',  null, null, 0 , null),  
    ('B007', 'Bàn 7',  null, null, 0 , null),  
    ('B008', 'Bàn 8', null, null, 0 , null), 
    ('B009', 'Bàn 9', null, null, 0 , null),  
    ('B010', 'Bàn 10',  null, null, 0 , null), 
	('B011', 'Bàn 11',  null, null, 0 , null), 
    ('B012', 'Bàn 12',  null, null, 0 , null),  
    ('B013', 'Bàn 13',  null, null, 0 , null),  
    ('B014', 'Bàn 14',  null, null, 0 , null),  
    ('B015', 'Bàn 15',  null, null, 0 , null), 
    ('B016', 'Bàn 16',  null, null, 0 , null),
    ('B017', 'Bàn 17',  null, null, 0 , null), 
    ('B018', 'Bàn 18',  null, null, 0 , null), 
    ('B019', 'Bàn 19',  null, null, 0 , null),  
    ('B020', 'Bàn 20',  null, null, 0 , null), 
	('B021', 'Bàn 21',  null, null, 0 , null), 
    ('B022', 'Bàn 22',  null, null, 0 , null),  
    ('B023', 'Bàn 23',  null, null, 0 , null),  
    ('B024', 'Bàn 24',  null, null, 0 , null), 
    ('B025', 'Bàn 25',  null, null, 0 , null),  
    ('B026', 'Bàn 26',  null, null, 0 , null),  
    ('B027', 'Bàn 27',  null, null, 0 , null), 
    ('B028', 'Bàn 28',  null, null, 0 , null),  
    ('B029', 'Bàn 29',  null, null, 0 , null),  
    ('B030', 'Bàn 30',  null, null, 0 , null);

-- Bảng Nhập Hàng
INSERT INTO NhapHang (MaSanPham, TenSanPham, SoLuong, DonViTinh, DonGia, NgayNhap, MaLoaiHang, MaNhaCungCap, NgaySanXuat, NgayHetHan) VALUES
('GR001', N'Gà Rán Giòn', 50, N'Chiếc', 65000, GETDATE(), 'GR', 'NCC01', '2024-12-01', '2025-06-30'),
('GR002', N'Gà Rán Nguyên Tâm', 30, N'Chiếc', 70000, GETDATE(), 'GR', 'NCC02', '2024-12-02', '2025-07-30'),
('GQ001', N'Gà Quay Nguyên Tâm', 40, N'Chiếc', 85000, GETDATE(), 'GQ', 'NCC03', '2024-12-15', '2025-06-15'),
('NUOC001', N'Nước Ngọt', 100, N'Lít', 15000, GETDATE(), 'NUOC', 'NCC04', '2024-12-03', '2025-12-03'),
('TM001', N'Bánh Tart', 70, N'Cái', 20000, GETDATE(), 'TM', 'NCC05', '2024-12-20', '2025-04-20'),
('TAN001', N'Khoai Tây Chiên', 80, N'Cái', 30000, GETDATE(), 'TAN', 'NCC06', '2024-12-15', '2025-08-15'),
('BMC001', N'Burger Gà', 40, N'Chiếc', 50000, GETDATE(), 'BMC', 'NCC07', '2024-12-25', '2025-05-25'),
('BMC002', N'Mì Ý', 30, N'Dĩa', 60000, GETDATE(), 'BMC', 'NCC08', '2024-12-05', '2025-05-05'),
('GR003', N'Gà Rán Cay', 45, N'Chiếc', 68000, GETDATE(), 'GR', 'NCC01', '2024-12-30', '2025-07-30'),
('NUOC002', N'Nước Trái Cây', 90, N'Lít', 18000, GETDATE(), 'NUOC', 'NCC09', '2024-12-01', '2025-12-01');



INSERT INTO Combo (MaCombo, TenCombo, GiaCombo, SoLuong, PhanTramGiam, NgayBatDau , NgayketThuc)  
VALUES 
('CB01', N'Combo Gà Rán', 150000, 50, 10, '01/11/2024', '15/12/2024'),
('CB02', N'Combo Burger', 120000, 30, 20, '01/11/2024', '15/12/2024'),
('CB03', N'Combo Nước', 150000, 50, 10, '01/11/2024', '15/11/2024'),
('CB04', N'Combo Mỳ Gà', 120000, 30, 20, '01/11/2024', '15/11/2024'),
('CB05', N'Combo Bánh', 150000, 50, 10, '01/11/2024', '15/12/2024'),
('CB06', N'Combo Cơm', 120000, 30, 20, '01/11/2024', '22/11/2024');

INSERT INTO ChiTietCombo (MaCombo, MaSanPham, SoLuong)  
VALUES 
('CB01', 'GR001', 2),
('CB01', 'GR002', 1),
('CB02', 'TM001', 3),
('CB02', 'BMC001', 2),
('CB03', 'NUOC006', 3),
('CB03', 'NUOC004', 2),
('CB04', 'GR003', 3),
('CB04', 'BMC002', 2),
('CB05', 'TM001', 3),
('CB05', 'TM002', 2),
('CB06', 'BMC006', 3),
('CB06', 'BMC007', 2);
INSERT INTO HoaDon (MaDonDat, NgayThanhToan) VALUES
(1, GETDATE()),
(2, GETDATE()),
(3, GETDATE()),
(4, GETDATE()),
(5, GETDATE()),
(6, GETDATE()),
(7, GETDATE()),
(8, GETDATE()),
(9, GETDATE()),
(10, GETDATE());


INSERT INTO DoanhThu (MaNhapHang, Thang, Nam, NgayGhiNhan, MaHoaDon, TongChiTieu, TongDoanhThu)
VALUES
(1, 10, 2023, '2023-10-01', 1, 4000000, 8000000), -- Lãi: 4000000
(2, 10, 2023, '2023-10-02', 2, 3000000, 6000000), -- Lãi: 3000000
(3, 10, 2023, '2023-10-03', 3, 5000000, 5000000), -- Hòa vốn
(4, 10, 2023, '2023-10-04', 4, 7000000, 6500000), -- Lỗ: 500000
(5, 10, 2023, '2023-10-05', 5, 2000000, 4500000), -- Lãi: 2500000

(6, 11, 2023, '2023-11-01', 6, 3000000, 7000000), -- Lãi: 4000000
(7, 11, 2023, '2023-11-02', 7, 4000000, 4000000), -- Hòa vốn
(8, 11, 2023, '2023-11-03', 8, 5000000, 6000000), -- Lãi: 1000000
(9, 11, 2023, '2023-11-04', 9, 8000000, 7000000), -- Lỗ: 1000000
(10, 11, 2023, '2023-11-05', 10, 3500000, 7500000), -- Lãi: 4000000

(11, 12, 2023, '2023-12-01', 11, 6000000, 12000000), -- Lãi: 6000000
(12, 12, 2023, '2023-12-02', 12, 4000000, 7000000), -- Lãi: 3000000
(13, 12, 2023, '2023-12-03', 13, 7000000, 7000000), -- Hòa vốn
(14, 12, 2023, '2023-12-04', 14, 9000000, 8000000), -- Lỗ: 1000000
(15, 12, 2023, '2023-12-05', 15, 2500000, 6500000), -- Lãi: 4000000

(16, 1, 2024, '2024-01-01', 16, 5000000, 10000000), -- Lãi: 5000000
(17, 1, 2024, '2024-01-02', 17, 4000000, 9000000), -- Lãi: 5000000
(18, 1, 2024, '2024-01-03', 18, 6000000, 6000000), -- Hòa vốn
(19, 1, 2024, '2024-01-04', 19, 8000000, 7500000), -- Lỗ: 500000
(20, 1, 2024, '2024-01-05', 20, 3000000, 7000000), -- Lãi: 4000000

(21, 2, 2024, '2024-02-01', 21, 4000000, 8000000), -- Lãi: 4000000
(22, 2, 2024, '2024-02-02', 22, 3000000, 7000000), -- Lãi: 4000000
(23, 2, 2024, '2024-02-03', 23, 5000000, 5000000), -- Hòa vốn
(24, 2, 2024, '2024-02-04', 24, 4500000, 3500000), -- Lỗ: 1000000
(25, 2, 2024, '2024-02-05', 25, 6000000, 12000000), -- Lãi: 6000000
(26, 2, 2024, '2024-02-06', 26, 3000000, 6000000), -- Lãi: 3000000
(27, 2, 2024, '2024-02-07', 27, 4000000, 4000000), -- Hòa vốn
(28, 2, 2024, '2024-02-08', 28, 3500000, 8000000), -- Lãi: 4500000

(29, 3, 2024, '2024-03-01', 29, 6000000, 13000000), -- Lãi: 7000000
(30, 3, 2024, '2024-03-02', 30, 8000000, 7500000), -- Lỗ: 500000
(31, 3, 2024, '2024-03-03', 31, 5000000, 5000000), -- Hòa vốn
(32, 3, 2024, '2024-03-04', 32, 9000000, 8000000), -- Lỗ: 1000000
(33, 3, 2024, '2024-03-05', 33, 7000000, 14000000), -- Lãi: 7000000
(34, 3, 2024, '2024-03-06', 34, 3500000, 8500000), -- Lãi: 5000000

(35, 4, 2024, '2024-04-01', 35, 5000000, 10000000), -- Lãi: 5000000
(36, 4, 2024, '2024-04-02', 36, 4000000, 8500000), -- Lãi: 4500000
(37, 4, 2024, '2024-04-03', 37, 7000000, 7000000), -- Hòa vốn
(38, 4, 2024, '2024-04-04', 38, 9000000, 8000000), -- Lỗ: 1000000
(39, 4, 2024, '2024-04-05', 39, 2500000, 7000000), -- Lãi: 4500000

(40, 5, 2024, '2024-05-01', 40, 4000000, 8000000), -- Lãi: 4000000
(41, 5, 2024, '2024-05-02', 41, 3000000, 6000000), -- Lãi: 3000000
(42, 5, 2024, '2024-05-03', 42, 7000000, 7000000), -- Hòa vốn
(43, 5, 2024, '2024-05-04', 43, 9000000, 8000000), -- Lỗ: 1000000
(44, 5, 2024, '2024-05-05', 44, 2500000, 6500000), -- Lãi: 4000000

(45, 6, 2024, '2024-06-01', 45, 4000000, 9000000), -- Lãi: 5000000
(46, 6, 2024, '2024-06-02', 46, 7000000, 7000000), -- Hòa vốn
(47, 6, 2024, '2024-06-03', 47, 6000000, 5000000), -- Lỗ: 1000000
(48, 6, 2024, '2024-06-04', 48, 5000000, 10000000), -- Lãi: 5000000
(49, 6, 2024, '2024-06-05', 49, 3000000, 7000000), -- Lãi: 4000000

(50, 7, 2024, '2024-07-01', 50, 4500000, 8000000), -- Lãi: 3500000
(51, 7, 2024, '2024-07-02', 51, 6000000, 6000000), -- Hòa vốn
(52, 7, 2024, '2024-07-03', 52, 8000000, 7500000), -- Lỗ: 500000
(53, 7, 2024, '2024-07-04', 53, 5000000, 11000000), -- Lãi: 6000000
(54, 7, 2024, '2024-07-05', 54, 7000000, 7000000), -- Hòa vốn

(55, 8, 2024, '2024-08-01', 55, 4000000, 9000000), -- Lãi: 5000000
(56, 8, 2024, '2024-08-02', 56, 3500000, 7500000), -- Lãi: 4000000
(57, 8, 2024, '2024-08-03', 57, 8000000, 7000000), -- Lỗ: 1000000
(58, 8, 2024, '2024-08-04', 58, 3000000, 6000000), -- Lãi: 3000000
(59, 8, 2024, '2024-08-05', 59, 5000000, 5000000), -- Hòa vốn

(60, 9, 2024, '2024-09-01', 60, 6000000, 14000000), -- Lãi: 8000000
(61, 9, 2024, '2024-09-02', 61, 3200000, 7200000), -- Lãi: 4000000
(62, 9, 2024, '2024-09-03', 62, 9000000, 8000000), -- Lỗ: 1000000
(63, 9, 2024, '2024-09-04', 63, 5000000, 5000000), -- Hòa vốn
(64, 9, 2024, '2024-09-05', 64, 4500000, 9500000), -- Lãi: 5000000

(65, 10, 2024, '2024-10-01', 65, 6000000, 15000000), -- Lãi: 9000000
(66, 10, 2024, '2024-10-02', 66, 7000000, 8000000), -- Lãi: 1000000
(67, 10, 2024, '2024-10-03', 67, 8000000, 7500000), -- Lỗ: 500000
(68, 10, 2024, '2024-10-04', 68, 5000000, 10000000), -- Lãi: 5000000
(69, 10, 2024, '2024-10-05', 69, 3000000, 7000000), -- Lãi: 4000000

(70, 11, 2024, '2024-11-11', 70, 4000000, 8000000), -- Lãi: 4000000
(71, 11, 2024, '2024-11-12', 71, 9000000, 9500000), -- Lãi: 500000
(72, 11, 2024, '2024-11-13', 72, 7000000, 6000000), -- Lỗ: 1000000
(73, 11, 2024, '2024-11-14', 73, 6000000, 11000000), -- Lãi: 5000000
(74, 11, 2024, '2024-11-15', 74, 5000000, 5000000); -- Hòa vốn

INSERT INTO KhuyenMai (MaKhuyenMai, NgayBatDau, NgayKetThuc, GiaTriGiam, SoLuong, TrangThai) VALUES
('KM01', GETDATE(), DATEADD(DAY, 30, GETDATE()), 20000, 100, 1),
('KM02', GETDATE(), DATEADD(DAY, 30, GETDATE()), 30000, 100, 1),

('KM03', GETDATE(), DATEADD(DAY, 30, GETDATE()), 10000, 100, 1),

('KM04', GETDATE(), DATEADD(DAY, 30, GETDATE()), 15000, 100, 1),

('KM05', GETDATE(), DATEADD(DAY, 30, GETDATE()), 20000, 100, 1),

('KM06', GETDATE(), DATEADD(DAY, 30, GETDATE()), 20000, 100, 1),

('KM07', GETDATE(), DATEADD(DAY, 30, GETDATE()), 30000, 100, 1),

('KM08', GETDATE(), DATEADD(DAY, 30, GETDATE()), 50000, 100, 1),

('KM09', GETDATE(), DATEADD(DAY, 30, GETDATE()), 20000, 100, 1),

('KM010', GETDATE(), DATEADD(DAY, 30, GETDATE()), 10000, 100, 1),

('KM11', GETDATE(), DATEADD(DAY, 30, GETDATE()), 13000, 100, 1),
('KM12', GETDATE(), DATEADD(DAY, 30, GETDATE()), 15000, 100, 1),
('KM13', GETDATE(), DATEADD(DAY, 30, GETDATE()), 20000, 100, 1);




UPDATE NhapHang
SET NgaySanXuat = '01/10/2024', NgayHetHan = '01/12/2024'
WHERE MaSanPham = 'GR01';

UPDATE NhapHang
SET NgaySanXuat = '05/10/2024', NgayHetHan = '05/12/2024'
WHERE MaSanPham = 'GQ01';

UPDATE NhapHang
SET NgaySanXuat = '10/10/2024', NgayHetHan = '10/10/2025'
WHERE MaSanPham = 'NUOC01';

UPDATE NhapHang
SET NgaySanXuat = '12/10/2024', NgayHetHan = '12/01/2025'
WHERE MaSanPham = 'TAN01';

UPDATE NhapHang
SET NgaySanXuat = '15/10/2024', NgayHetHan = '15/11/2024'
WHERE MaSanPham = 'BMC01';

select * from DonDat

select * from ChiTietDonDat

select * from Ban

--DELETE FROM DonDat 
--WHERE MaDonDat IN ('DDbc0ac8f1','DDe7139f26');


--SELECT * FROM Luong WHERE MaNhanVien = 'NV001' AND Thang = 10 AND Nam = 2024;


--SELECT COLUMN_NAME, DATA_TYPE
--FROM INFORMATION_SCHEMA.COLUMNS
--WHERE TABLE_NAME = 'Luong';

--EXEC sp_help 'Luong';


Select * from DoanhThu

























---- 11. Bảng Chi Tiet Hoa Don  
--CREATE TABLE ChiTietHoaDon (  
--    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,  
--    MaHoaDon INT NOT NULL,  
--    MaSanPham VARCHAR(30) NOT NULL,	0
--    TenSanPham NVARCHAR(250) NOT NULL,  
--    SoLuong INT,  
--    DonGia FLOAT,  
--    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),  
--    FOREIGN KEY (MaSanPham) REFERENCES ThucDon(MaSanPham)  
--);  