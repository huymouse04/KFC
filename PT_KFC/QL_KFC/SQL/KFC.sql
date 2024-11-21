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
--ALTER TABLE Luong
--ALTER COLUMN LuongCoBan DECIMAL(18, 2);
--ALTER TABLE Luong
--ALTER COLUMN ThuongChuyenCan DECIMAL(18, 2);
--ALTER TABLE Luong
--ALTER COLUMN ThuongHieuSuat DECIMAL(18, 2);


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
	TenSanPham NVARCHAR (100) not null,
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
	ThoiGianDen DATETIME NOT NULL,
	ThoiGianRoi	DATETIME NOT NULL,  
    TrangThaiBan BIT  
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
    MaDonDat INT IDENTITY(1,1) PRIMARY KEY,  
    MaBan VARCHAR(20) NOT NULL,  
	TongTien FLOAT,
    HinhThucThanhToan NVARCHAR(50),  
    SoTienNhan FLOAT NULL, 
    SoTienTra FLOAT NULL,  
	MaKhuyenMai VARCHAR(12) null,
	MaKhachHang VARCHAR(30) null,
    FOREIGN KEY (MaBan) REFERENCES Ban(MaBan)  ,
	FOREIGN KEY (MaKhuyenMai) REFERENCES KhuyenMai(MaKhuyenMai),
	FOREIGN KEY (MaKhachHang) REFERENCES KhachHangThanThiet(MaKhachHang)
);

-- Bảng chi tiết hóa đơn
CREATE TABLE ChiTietDonDat (  
	MaDonDat INT NOT NULL, 
    ID INT IDENTITY(1,1) PRIMARY KEY,  
    MaSanPham VARCHAR(30) NULL,  
    MaCombo VARCHAR(30) NULL,  
    SoLuong INT NOT NULL,   
	DonGia FLOAT NULL, 
	FOREIGN KEY (MaDonDat) REFERENCES DonDat(MaDonDat),
    FOREIGN KEY (MaSanPham) REFERENCES ThucDon(MaSanPham),  
    FOREIGN KEY (MaCombo) REFERENCES Combo(MaCombo)  
);


-- Bảng Hoa Don  
CREATE TABLE HoaDon (  
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY, 
	MaDonDat INT not NULL,   
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
('NV020', 10, 2024, 3500000, 22, 4, 200000, 150000, 70000);




-- Bảng Loại Hàng
INSERT INTO LoaiHang (MaLoaiHang, TenLoaiHang) VALUES
('GR', N'Gà Rán'),
('GQ', N'Gà Quay'),
('NUOC', N'Nước Uống'),
('TM', N'Món Tráng Miệng'),
('TAN', N'Thức Ăn Nhẹ'),
('BMC', N'Burger - Mì Ý - Cơm');

-- Bảng Kho 
INSERT INTO Kho (MaSanPham, TenSanPham, SoLuong, DonViTinh, DonGia, NgaySanXuat, NgayHetHan, MaLoaiHang)
VALUES
('GR001', N'Gà Rán Giòn', 100, N'Chiếc', 65000, '2024-12-01', '2025-06-30', 'GR'),
('GR002', N'Gà Rán Nguyên Tâm', 50, N'Chiếc', 70000, '2024-12-02', '2025-07-30', 'GR'),
('GQ001', N'Gà Quay Nguyên Tâm', 80, N'Chiếc', 85000, '2024-12-15', '2025-06-15', 'GQ'),
('NUOC001', N'Nước Ngọt', 200, N'Lít', 15000, '2024-12-03', '2025-12-03', 'NUOC'),
('TM001', N'Bánh Tart', 150, N'Cái', 20000, '2024-12-20', '2025-04-20', 'TM'),
('TAN001', N'Khoai Tây Chiên', 120, N'Cái', 30000, '2024-12-15', '2025-08-15', 'TAN'),
('BMC001', N'Burger Gà', 80, N'Chiếc', 50000, '2024-12-25', '2025-05-25', 'BMC'),
('BMC002', N'Mì Ý', 70, N'Dĩa', 60000, '2024-12-05', '2025-05-05', 'BMC'),
('GR003', N'Gà Rán Cay', 90, N'Chiếc', 68000, '2024-12-30', '2025-07-30', 'GR'),
('NUOC002', N'Nước Trái Cây', 180, N'Lít', 18000, '2024-12-01', '2025-12-01', 'NUOC'),
('NUOC003', N'Nước CoCa', 160, N'Lít', 12000, '2024-03-11', '2024-04-11', 'NUOC');


-- Bảng Thực Đơn
INSERT INTO ThucDon (MaSanPham, TenSanPham, HinhAnh, DonGia, MaLoaiHang) VALUES
('GR001', N'Gà Rán Giòn', NULL, 65000, 'GR'),
('GR002', N'Gà Rán Nguyên Tâm', NULL, 70000, 'GR'),
('GQ001', N'Gà Quay Nguyên Tâm', NULL, 85000, 'GQ'),
('NUOC001', N'Nước Ngọt', NULL, 15000, 'NUOC'),
('TM001', N'Bánh Tart', NULL, 20000, 'TM'),
('TAN001', N'Khoai Tây Chiên', NULL, 30000, 'TAN'),
('BMC001', N'Burger Gà', NULL, 50000, 'BMC'),
('BMC002', N'Mì Ý', NULL, 60000, 'BMC'),
('GR003', N'Gà Rán Cay', NULL, 68000, 'GR'),
('NUOC002', N'Nước Trái Cây', NULL, 18000, 'NUOC');

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
('KH001', N'Nguyễn Văn A', '0123456789', 100),
('KH002', N'Trần Thị B', '0123456790', 10),
('KH003', N'Nguyễn Thị C', '0123456791', 50),
('KH004', N'Phạm Văn D', '0123456792', 90),
('KH005', N'Đỗ Thị E', '0123456793', 150),
('KH006', N'Lê Văn F', '0123456794', 120),
('KH007', N'Nguyễn Văn G', '0123456795', 55),
('KH008', N'Vũ Thị H', '0123456796', 15),
('KH009', N'Hồ Văn I', '0123456797', 140),
('KH010', N'Tôn Thị J', '0123456798', 150);

INSERT INTO Ban (MaBan, TenBan, ThoiGianDen, ThoiGianRoi, TrangThaiBan)
VALUES 
    ('B001', 'Bàn 1', '10:30:00', '12:00:00', 1),  
    ('B002', 'Bàn 2', '11:00:00', '13:00:00', 1),  
    ('B003', 'Bàn 3', '12:00:00', '14:30:00', 1), 
    ('B004', 'Bàn 4', '13:30:00', '15:00:00', 0),  
    ('B005', 'Bàn 5', '09:45:00', '11:45:00', 1),  
    ('B006', 'Bàn 6', '14:00:00', '16:00:00', 0),  
    ('B007', 'Bàn 7', '10:15:00', '12:45:00', 1),  
    ('B008', 'Bàn 8', '11:30:00', '13:30:00', 0),  
    ('B009', 'Bàn 9', '12:15:00', '14:15:00', 1), 
    ('B010', 'Bàn 10', '15:00:00', '17:30:00', 1); 


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



INSERT INTO Combo (MaCombo, TenCombo, GiaCombo, SoLuong, NgayBatDau , NgayketThuc)  
VALUES 
('CB01', N'Combo Gà Rán', 150000, 50, '01/11/2024', '15/11/2024'),
('CB02', N'Combo Burger', 120000, 30, '01/11/2024', '15/11/2024');


INSERT INTO ChiTietCombo (MaCombo, MaSanPham, SoLuong)  
VALUES 
('CB01', 'GR001', 2),
('CB01', 'GR002', 1),
('CB02', 'TM001', 3),
('CB02', 'BMC001', 2);

INSERT INTO KhuyenMai (MaKhuyenMai, NgayBatDau, NgayKetThuc, GiaTriGiam, SoLuong, TrangThai) VALUES
('KM01', GETDATE(), DATEADD(DAY, 30, GETDATE()), 20000, 100, 1),
('KM02', GETDATE(), DATEADD(DAY, 15, GETDATE()), 10000, 50, 1),
('KM03', GETDATE(), DATEADD(DAY, 20, GETDATE()), 50000, 20, 1),
('KM04', GETDATE(), DATEADD(DAY, 10, GETDATE()), 30000, 70, 0),
('KM05', GETDATE(), DATEADD(DAY, 25, GETDATE()), 15000, 150, 1),
('KM06', GETDATE(), DATEADD(DAY, 40, GETDATE()), 25000, 60, 1),
('KM07', GETDATE(), DATEADD(DAY, 50, GETDATE()), 50000, 30, 0),
('KM08', GETDATE(), DATEADD(DAY, 5, GETDATE()), 20000, 10, 1),
('KM09', GETDATE(), DATEADD(DAY, 7, GETDATE()), 10000, 25, 1),
('KM10', GETDATE(), DATEADD(DAY, 18, GETDATE()), 30000, 90, 1);

INSERT INTO DonDat (MaBan, TongTien, HinhThucThanhToan, SoTienNhan, SoTienTra, MaKhuyenMai, MaKhachHang) VALUES
('B001', 300000, 'Tiền mặt', 300000, 0, 'KM01', 'KH001'),
('B002', 450000, 'Thẻ tín dụng', NULL, NULL, 'KM02', 'KH002'),
('B003', 200000, 'Tiền mặt', 200000, 0, 'KM03', NULL),
('B004', 550000, 'Chuyển khoản', NULL, NULL, 'KM04', 'KH003'),
('B005', 100000, 'Tiền mặt', 100000, 0, NULL, 'KH004'),
('B006', 650000, 'Thẻ tín dụng', NULL, NULL, 'KM05', 'KH005'),
('B007', 300000, 'Chuyển khoản', NULL, NULL, NULL, NULL),
('B008', 250000, 'Tiền mặt', 300000, 50000, 'KM06', 'KH006'),
('B009', 400000, 'Chuyển khoản', NULL, NULL, NULL, NULL),
('B010', 700000, 'Thẻ tín dụng', NULL, NULL, 'KM07', 'KH007');

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
-- Nhập hàng có lãi
(1, 11, 2024, '2024-11-01', 1, 6000000, 14000000), -- Lãi: 8000000
(2, 11, 2024, '2024-11-02', 2, 3200000, 7200000), -- Lãi: 4000000
(3, 11, 2024, '2024-11-03', 3, 6600000, 14600000), -- Lãi: 8000000
-- Nhập hàng hòa vốn
(4, 11, 2024, '2024-11-04', 4, 5000000, 5000000), -- Hòa vốn
(5, 11, 2024, '2024-11-05', 5, 3600000, 3600000), -- Hòa vốn
-- Nhập hàng lỗ
(6, 11, 2024, '2024-11-06', 6, 9000000, 8000000), -- Lỗ: 1000000
(7, 11, 2024, '2024-11-07', 7, 7000000, 6500000), -- Lỗ: 500000
-- Nhập hàng có lãi cao
(8, 11, 2024, '2024-11-08', 8, 5500000, 12500000), -- Lãi: 7000000
(9, 11, 2024, '2024-11-09', 9, 2500000, 6000000), -- Lãi: 3500000
(10, 11, 2024, '2024-11-10', 10, 3200000, 7000000); -- Lãi: 3800000


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

select * from Luong

select * from Kho

SELECT * FROM Luong WHERE MaNhanVien = 'NV001' AND Thang = 10 AND Nam = 2024;
DELETE FROM Luong WHERE MaNhanVien = 'NV001' AND Thang = 2; -- Thay MãNhânViênCầnXóa và 1 bằng giá trị cụ thể



SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Luong';

EXEC sp_help 'Luong';


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