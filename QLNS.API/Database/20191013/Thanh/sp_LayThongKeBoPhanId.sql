USE [CaseStudy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ThanhLNP
-- Create date: 2019/10/11
-- Description:	Lay thong ke danh sach nhan vien theo bo phan cua QuanLyId
-- =============================================
CREATE PROCEDURE [dbo].[sp_LayThongKeBoPhanId]
	@QuanLyId INT
AS
BEGIN
	SET NOCOUNT ON;

	IF (EXISTS(SELECT * FROM dbo.TaiKhoan WHERE Id = @QuanLyId AND QuyenId = 2 AND DangHoatDong = 1))
	BEGIN
		DECLARE @BoPhanId INT = (SELECT TOP(1) BoPhanId FROM dbo.ChucVuNhanVien WHERE NhanVienId = @QuanLyId)

		SELECT NhanVien.Id AS NhanVienId, Thang, Nam, Ho, Ten, CoMat, Tre, KhongPhep, CoPhep, TheoQuyDinh FROM dbo.NhanVien
		LEFT JOIN dbo.ChucVuNhanVien ON ChucVuNhanVien.NhanVienId = NhanVien.Id
		LEFT JOIN dbo.ThongKe ON ThongKe.NhanVienId = NhanVien.Id
		WHERE DaXoa = 0 AND DangLamViec = 1 AND BoPhanId = @BoPhanId
		ORDER BY Nam DESC, Thang DESC, dbo.NhanVien.Id ASC
	END
END

GO
