USE [CaseStudy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ThanhLNP
-- Create date: 2019/10/11
-- Description:	Lay diem danh cua nhan vien theo bo phan cua QuanLyId (theo ngay)
-- =============================================
CREATE PROCEDURE [dbo].[sp_LayDiemDanhNhanVienId]
	@NhanVienId INT,
	@QuanLyId INT,
	@Ngay DATE
AS
BEGIN
	SET NOCOUNT ON;

	IF (EXISTS(SELECT * FROM dbo.TaiKhoan WHERE Id = @QuanLyId AND QuyenId = 2 AND DangHoatDong = 1))
	BEGIN
		DECLARE @BoPhanId INT = (SELECT TOP(1) BoPhanId FROM dbo.ChucVuNhanVien WHERE NhanVienId = @QuanLyId)

		SELECT NhanVien.Id AS NhanVienId, Ho, Ten, ISNULL(TrangThai,0) AS TrangThai, @Ngay AS 'Ngay', ISNULL(QuanLyId,0) AS QuanLyId FROM dbo.NhanVien
		LEFT JOIN dbo.ChucVuNhanVien ON ChucVuNhanVien.NhanVienId = NhanVien.Id
		LEFT JOIN dbo.DiemDanh ON DiemDanh.NhanVienId = NhanVien.Id AND Ngay = @Ngay
		WHERE DaXoa = 0 AND DangLamViec = 1 AND BoPhanId = @BoPhanId AND NhanVien.Id = @NhanVienId
	END
END

GO
