USE [CaseStudy]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		ThanhLNP
-- Create date: 2019/10/11
-- Description:	Them moi diem danh va thong ke, hoac sua lai diem danh va tinh lai thong ke
-- 1. Neu chua diem danh thi tao moi
-- 1.1 Tao moi diem danh
-- 1.2 Neu chua co thong ke theo thang thi tao moi voi mac dinh deu = 0, tinh SoPhepConLai
-- 2. Neu da diem danh thi cap nhap khi co thay doi ve trang thai
-- 2.1 Luu diem danh cu vao DiemDanhLog
-- 2.2 Cap nhap diem danh
-- 2.3 Tru di trang thai cu trong bang thong ke
-- 3. Cong don trang thai vao bang thong ke
-- =============================================
CREATE PROCEDURE [dbo].[sp_TaoDiemDanh]
	@NhanVienId INT,
	@QuanLyId INT,
	@TrangThai INT,
	@Ngay DATE
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ErrMsg NVARCHAR(2000), 
		    @ErrSev SMALLINT, 
			@ErrSta SMALLINT

	DECLARE @Result INT = 0

	IF(EXISTS(SELECT * FROM dbo.NhanVien WHERE Id = @NhanVienId AND DaXoa = 0) 
		AND EXISTS(SELECT * FROM dbo.TaiKhoan WHERE Id = @QuanLyId AND QuyenId = 2 AND DangHoatDong = 1))
	BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
-- Kiem tra da diem danh hay chua
		DECLARE @DiemDanhId INT
		DECLARE @TrangThaiBanDau INT
		SELECT TOP(1) @DiemDanhId = Id, @TrangThaiBanDau = TrangThai FROM dbo.DiemDanh WHERE NhanVienId = @NhanVienId AND Ngay = @Ngay

-- Kiem tra da co thong ke theo thang chua
		DECLARE @Thang TINYINT = MONTH(@Ngay)
		DECLARE @Nam INT = YEAR(@Ngay)
		DECLARE @ThongKeId INT = (SELECT TOP(1) Id FROM dbo.ThongKe WHERE NhanVienId = @NhanVienId AND Thang = @Thang AND Nam = @Nam)

-- 1. Neu chua diem danh thi tao moi
		IF(@DiemDanhId IS NULL)
		BEGIN
-- 1.1 Tao moi diem danh
			INSERT dbo.DiemDanh
			        ( NhanVienId ,
			          QuanLyId ,
			          TrangThai ,
			          Ngay ,
			          NgayTao ,
			          NgaySua
			        )
			VALUES  ( @NhanVienId , -- NhanVienId - int
			          @QuanLyId , -- QuanLyId - int
			          @TrangThai , -- TrangThai - int
			          @Ngay , -- Ngay - date
			          GETDATE() , -- NgayTao - date
			          GETDATE()  -- NgaySua - date
			        )
-- 1.2 Neu chua co thong ke theo thang thi tao moi voi mac dinh deu = 0, tinh SoPhepConLai
			IF(@ThongKeId IS NULL)
			BEGIN
				DECLARE @SoPhep TINYINT = (SELECT SoPhep FROM dbo.PhepNam WHERE NhanVienId = @NhanVienId AND Nam = @Nam)
				DECLARE @SoPhepConLai TINYINT = (SELECT (@SoPhep - ISNULL(SUM(CoPhep),0)) FROM dbo.ThongKe WHERE NhanVienId = @NhanVienId AND Nam = @Nam AND (Thang < @Thang))

				INSERT dbo.ThongKe
						( NhanVienId ,
						  Thang ,
						  Nam ,
						  CoMat ,
						  Tre ,
						  KhongPhep ,
						  CoPhep ,
						  TheoQuyDinh ,
						  SoPhepConLai
						)
				VALUES  ( @NhanVienId , -- NhanVienId - int
						  @Thang , -- Thang - tinyint
						  @Nam , -- Nam - int
						  0 , -- CoMat - tinyint
						  0 , -- Tre - tinyint
						  0 , -- KhongPhep - tinyint
						  0 , -- CoPhep - tinyint
						  0 , -- TheoQuyDinh - tinyint
						  @SoPhepConLai  -- SoPhepConLai - tinyint
						)

				SET @ThongKeId = SCOPE_IDENTITY()
			END
		END
-- 2. Neu da diem danh thi cap nhap khi co thay doi ve trang thai
		ELSE
		BEGIN
			IF(@TrangThaiBanDau <> @TrangThai)
			BEGIN
-- 2.1 Luu diem danh cu vao DiemDanhLog
				INSERT INTO dbo.DiemDanhLog
				        ( NhanVienId ,
				          QuanLyId ,
				          TrangThai ,
				          Ngay ,
				          NgaySua ,
				          DiemDanhId
				        )
				SELECT NhanVienId, QuanLyId, TrangThai, Ngay, NgaySua, dbo.DiemDanh.Id FROM dbo.DiemDanh
				WHERE dbo.DiemDanh.Id = @DiemDanhId
-- 2.2 Cap nhap diem danh
				UPDATE dbo.DiemDanh SET TrangThai = @TrangThai, QuanLyId = @QuanLyId, NgaySua = GETDATE() WHERE Id = @DiemDanhId
-- 2.3 Tru di trang thai cu trong bang thong ke 
				IF (@TrangThaiBanDau = 1) UPDATE dbo.ThongKe SET CoMat = (CoMat - 1) WHERE Id = @ThongKeId

				IF (@TrangThaiBanDau = 2) UPDATE dbo.ThongKe SET Tre = (Tre - 1) WHERE Id = @ThongKeId

				IF (@TrangThaiBanDau = 3) UPDATE dbo.ThongKe SET KhongPhep = (KhongPhep - 1) WHERE Id = @ThongKeId

				IF (@TrangThaiBanDau = 4) 
				BEGIN 
					UPDATE dbo.ThongKe SET CoPhep = (CoPhep - 1), SoPhepConLai = (SoPhepConLai + 1) WHERE Id = @ThongKeId
-- Neu la cap nhap thang cu thi phai cap nhap lai thong ke cua cac thang sau
					IF(EXISTS(SELECT Id FROM dbo.ThongKe WHERE NhanVienId = @NhanVienId AND Nam = @Nam AND Thang > @Thang))
						UPDATE dbo.ThongKe SET SoPhepConLai = (SoPhepConLai + 1) WHERE Id IN (SELECT Id FROM dbo.ThongKe WHERE NhanVienId = @NhanVienId AND Nam = @Nam AND Thang > @Thang)
				END 

				IF (@TrangThaiBanDau = 5) UPDATE dbo.ThongKe SET TheoQuyDinh = (TheoQuyDinh - 1) WHERE Id = @ThongKeId
			END
		END
-- 3. Cong don trang thai vao bang thong ke
		IF(ISNULL(@TrangThaiBanDau,0) <> @TrangThai)
		BEGIN
			IF (@TrangThai = 1) UPDATE dbo.ThongKe SET CoMat = (CoMat + 1) WHERE Id = @ThongKeId

			IF (@TrangThai = 2) UPDATE dbo.ThongKe SET Tre = (Tre + 1) WHERE Id = @ThongKeId

			IF (@TrangThai = 3) UPDATE dbo.ThongKe SET KhongPhep = (KhongPhep + 1) WHERE Id = @ThongKeId

			IF (@TrangThai = 4) 
			BEGIN 
				UPDATE dbo.ThongKe SET CoPhep = (CoPhep + 1), SoPhepConLai = (SoPhepConLai - 1) WHERE Id = @ThongKeId
-- Neu la cap nhap thang cu thi phai cap nhap lai thong ke cua cac thang sau
				IF(EXISTS(SELECT Id FROM dbo.ThongKe WHERE NhanVienId = @NhanVienId AND Nam = @Nam AND Thang > @Thang))
					UPDATE dbo.ThongKe SET SoPhepConLai = (SoPhepConLai - 1) WHERE Id IN (SELECT Id FROM dbo.ThongKe WHERE NhanVienId = @NhanVienId AND Nam = @Nam AND Thang > @Thang)
			END 

			IF (@TrangThai = 5) UPDATE dbo.ThongKe SET TheoQuyDinh = (TheoQuyDinh + 1) WHERE Id = @ThongKeId
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
