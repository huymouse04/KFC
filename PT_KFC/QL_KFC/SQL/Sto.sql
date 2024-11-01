CREATE PROCEDURE sp_ThemLuong
AS
BEGIN
    DECLARE @CurrentDate DATETIME = GETDATE();
    DECLARE @Month INT = MONTH(@CurrentDate);
    DECLARE @Year INT = YEAR(@CurrentDate);

    -- Kiểm tra nếu lương đã được thêm cho tháng này
    IF NOT EXISTS (SELECT 1 FROM Luong WHERE Thang = @Month AND Nam = @Year)
    BEGIN
        -- Thêm lương cho tất cả nhân viên
        INSERT INTO Luong (MaNhanVien, Thang, Nam, LuongCoBan, SoNgayLam, SoGioLamThem, ThuongChuyenCan, ThuongHieuSuat, KhoanTru)
        SELECT 
            MaNhanVien,  -- Đảm bảo cột này tồn tại trong bảng NhanVien
            @Month AS Thang,
            @Year AS Nam,
            1000000 AS LuongCoBan,  -- Thay đổi giá trị này theo thực tế
            20 AS SoNgayLam,        -- Số ngày làm
            0 AS SoGioLamThem,      -- Số giờ làm thêm
            100000 AS ThuongChuyenCan,  -- Thưởng chuyên cần
            200000 AS ThuongHieuSuat,    -- Thưởng hiệu suất
            50000 AS KhoanTru           -- Khoản trừ
        FROM NhanVien; -- Đảm bảo bạn lấy dữ liệu từ bảng NhanVien
    END
END
