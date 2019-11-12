USE [CaseStudy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ThanhLNP
-- Create date: 2019/10/11
-- Description:	Lay thong ke cua nhan vien theo bo phan cua QuanLyId
-- =============================================
CREATE PROCEDURE [dbo].[sp_LayThongTinBoPhanId]
	@QuanLyId INT
AS
BEGIN
	SET NOCOUNT ON;

	IF (EXISTS(SELECT * FROM dbo.TaiKhoan WHERE Id = @QuanLyId AND QuyenId = 2 AND DangHoatDong = 1))
	BEGIN
		DECLARE @BoPhanId INT = (SELECT TOP(1) BoPhanId FROM dbo.ChucVuNhanVien WHERE NhanVienId = @QuanLyId)

		SELECT NhanVien.Id AS NhanVienId, Ho, NhanVien.Ten, GioiTinh, NgaySinh, SoDienThoai, Email, HinhAnh, ChucVu.Ten AS ChucVuTen FROM dbo.NhanVien
		LEFT JOIN dbo.ChucVuNhanVien ON ChucVuNhanVien.NhanVienId = NhanVien.Id
		LEFT JOIN dbo.ChucVu ON ChucVu.Id = ChucVuNhanVien.ChucVuId
		WHERE NhanVien.DaXoa = 0 AND DangLamViec = 1 AND BoPhanId = @BoPhanId
	END
END

GO
