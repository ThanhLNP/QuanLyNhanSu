USE [CaseStudy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ThanhLNP
-- Create date: 2019/10/21
-- Description:	Cap nhap don xin phep cua nhan vien theo bo phan cua QuanLyId
-- =============================================
CREATE PROCEDURE [dbo].[sp_SuaDonXinPhepNhanVienId]
	@Id INT,
	@QuanLyId INT,
	@TinhTrang INT,
	@TraLoi NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrMsg NVARCHAR(2000), 
			@ErrSev SMALLINT, 
			@ErrSta SMALLINT

	DECLARE @Result INT = 0

	DECLARE @NhanVienId INT
	DECLARE	@NgayBatDau DATE
	DECLARE	@NgayKetThuc DATE
	SELECT @NhanVienId = NhanVienId, @NgayBatDau = NgayBatDau, @NgayKetThuc = NgayKetThuc FROM dbo.DonXinPhep WHERE Id = @Id

	IF(EXISTS(SELECT * FROM dbo.NhanVien WHERE Id = @NhanVienId AND DaXoa = 0) 
		AND EXISTS(SELECT * FROM dbo.TaiKhoan WHERE Id = @QuanLyId AND QuyenId = 2 AND DangHoatDong = 1)
		AND EXISTS(SELECT * FROM dbo.DonXinPhep WHERE Id = @Id AND TinhTrang = 1))
	BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
		IF(@TinhTrang = 2)
		BEGIN
			UPDATE dbo.DonXinPhep SET
			QuanLyId = @QuanLyId,
			TinhTrang = @TinhTrang,
			TraLoi = ISNULL(@TraLoi,''),
			NgayPhanHoi = GETDATE()
			WHERE Id = @Id

			DECLARE @Ngay DATE = @NgayBatDau
			WHILE(@Ngay <= @NgayKetThuc)
			BEGIN
				EXEC [dbo].[sp_TaoDiemDanh]
					@NhanVienId,
					@QuanLyId,
					4,
					@Ngay
				SET @Ngay =	DATEADD(day, 1, @Ngay)
			END
        END
        ELSE IF(@TinhTrang = 3)
		BEGIN
			UPDATE dbo.DonXinPhep SET
			QuanLyId = @QuanLyId,
			TinhTrang = @TinhTrang,
			TraLoi = ISNULL(@TraLoi,''),
			NgayPhanHoi = GETDATE()
			WHERE Id = @Id
		END
    
		SET @Result = 1
		COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION

		SELECT @ErrMsg = ERROR_MESSAGE(),
			@ErrSev = ERROR_SEVERITY(),
			@ErrSta = ERROR_STATE()

        RAISERROR(@ErrMsg, @ErrSev, @ErrSta)

    END CATCH
	END
	SELECT @Result AS Result
END

GO
