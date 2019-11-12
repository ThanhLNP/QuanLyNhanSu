USE [CaseStudy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ThanhLNP
-- Create date: 2019/10/13
-- Description:	Lay don xin phep cua danh sach nhan vien theo bo phan cua QuanLyId
-- =============================================
CREATE PROCEDURE [dbo].[sp_LayDonXinPhepBoPhanId]
	@QuanLyId INT
AS
BEGIN
	SET NOCOUNT ON;

	IF (EXISTS(SELECT * FROM dbo.TaiKhoan WHERE Id = @QuanLyId AND QuyenId = 2 AND DangHoatDong = 1))
	BEGIN
		DECLARE @BoPhanId INT = (SELECT TOP(1) BoPhanId FROM dbo.ChucVuNhanVien WHERE NhanVienId = @QuanLyId)

		SELECT DonXinPhep.Id AS DonXinPhepId, Ho, Ten, TinhTrang, NgayBatDau, NgayKetThuc, SoPhepConLai, ISNULL(SoNgayDaNghi,0) AS SoNgayDaNghi, 
			NgayGui, NgayPhanHoi, ISNULL(GhiChu,'') AS GhiChu, ISNULL(TraLoi,'') AS TraLoi, QuanLyId FROM dbo.NhanVien
		JOIN dbo.DonXinPhep ON DonXinPhep.NhanVienId = NhanVien.Id
		JOIN dbo.ChucVuNhanVien ON ChucVuNhanVien.NhanVienId = NhanVien.Id
		WHERE DaXoa = 0 AND DangLamViec = 1 AND BoPhanId = @BoPhanId
		ORDER BY NgayGui DESC, DonXinPhep.Id DESC
	END
END

GO
