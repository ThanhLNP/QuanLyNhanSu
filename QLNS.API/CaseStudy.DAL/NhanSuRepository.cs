using CaseStudy.DAL.Interface;
using CaseStudy.Domain.Request.NhanSu;
using CaseStudy.Domain.Response.NhanSu;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.DAL
{
    public class NhanSuRepository : BaseRepository, INhanSuRepository
    {
       public IList<ThongKeNhanVien> ThongKe(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                List<ThongKeNhanVien> dsThongKe = SqlMapper.Query<ThongKeNhanVien>(con, "sp_ThongkeNhanVien", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return dsThongKe;
                
            }catch(Exception exp)
            {
                throw exp;
            }
        }
        public CapPhepNhanVienView GetPhepNhanVien(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NhanVienId", id);
                return SqlMapper.Query<CapPhepNhanVienView>(con, "sp_CapPhepNamGet", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }catch(Exception exp)
            {
                throw exp;
            }
        }
        public IList<CapPhepNhanVienView> ThongTinPhepNam(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                List<CapPhepNhanVienView> thongTinPhepNam= SqlMapper.Query<CapPhepNhanVienView>(con, "sp_LayNhanVienId",parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return thongTinPhepNam;
            }catch(Exception exp)
            {
                throw exp;
            }
        }
        public bool CapPhepNam(CapPhepNam phepNam)
        {
            
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NhanVienId", phepNam.NhanVienId);
                parameters.Add("@Nam", phepNam.Nam);
                parameters.Add("@SoPhep", phepNam.SoPhep);
                SqlMapper.Execute(con, "sp_CapPhepNam", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }catch(Exception exp)
            {
                throw exp;
            }
        }
        public IList<DanhSachBoPhan> ThongTinBoPhan()
        {
            List<DanhSachBoPhan> dsBoPhan = SqlMapper.Query<DanhSachBoPhan>(con, "sp_thongTinPhongBan", commandType: System.Data.CommandType.StoredProcedure).ToList();
            return dsBoPhan;
        }
        public IList<DanhSachNhanVienTheoPhongBan> ThongTinNhanVienTheoPhongBan(int id)

        {   

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                IList<DanhSachNhanVienTheoPhongBan> dsNhanVien = SqlMapper.Query<DanhSachNhanVienTheoPhongBan>(
                     con, "sp_XemThongTinNhanVienTheoPhongBan", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return dsNhanVien;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public bool SuaThongTinNhanVien(SuaThongTinNhanVien nhanVien)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", nhanVien.Id);
                parameters.Add("@Ho", nhanVien.Ho);
                parameters.Add("@Ten", nhanVien.Ten);
                parameters.Add("@GioiTinh", nhanVien.GioiTinh);
                parameters.Add("@NgaySinh", nhanVien.NgaySinh);
                parameters.Add("@SoChungMinh", nhanVien.SoChungMinh);
                parameters.Add("@SoDienThoai", nhanVien.SoDienThoai);
                parameters.Add("@Email", nhanVien.Email);
                parameters.Add("@DiaChi", nhanVien.DiaChi);
                parameters.Add("@MaSoThue", nhanVien.MaSoThue);
                parameters.Add("@HinhAnh", nhanVien.HinhAnh);
                parameters.Add("@NgayTao", nhanVien.NgayTao);
                parameters.Add("@NgaySua", nhanVien.NgaySua);
                parameters.Add("@DangLamViec", nhanVien.DangLamViec);
                parameters.Add("@QuyenId", nhanVien.QuyenId);
                parameters.Add("@ChucVuId", nhanVien.ChucVuId);
                parameters.Add("@BoPhanId", nhanVien.BoPhanId);


                SqlMapper.Execute(con, "sp_SuaThongTinNhanVien", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public HienThiThongTinNhanVien ThongTinNhanVien(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return SqlMapper.Query<HienThiThongTinNhanVien>(con, "sp_HienThiThongTinNhanVien", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public bool XoaNhanVien(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                SqlMapper.Execute(con, "sp_XoaNhanVien", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public bool ThemNhanVien(ThemNhanVien nhanVien)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ho", nhanVien.Ho);
                parameters.Add("@Ten", nhanVien.Ten);
                parameters.Add("@GioiTinh", nhanVien.GioiTinh);
                parameters.Add("@NgaySinh", nhanVien.NgaySinh);
                parameters.Add("@SoChungMinh", nhanVien.SoChungMinh);
                parameters.Add("@SoDienThoai", nhanVien.SoChungMinh);
                parameters.Add("@Email", nhanVien.Email);
                parameters.Add("@DiaChi", nhanVien.DiaChi);
                parameters.Add("@MaSoThue", nhanVien.MaSoThue);
                parameters.Add("@HinhAnh", nhanVien.HinhAnh);
                parameters.Add("@QuyenId", nhanVien.QuyenId);
                parameters.Add("@ChucVuId", nhanVien.ChucVuId);
                parameters.Add("@BoPhanId", nhanVien.BoPhanId);
                parameters.Add("@MatKhau", nhanVien.MatKhau);
                SqlMapper.Execute(con, "sp_ThemNhanVien", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public IList<BoPhanViewBag> BoPhanViewBags()
        {
            List<BoPhanViewBag> boPhan = SqlMapper.Query<BoPhanViewBag>(con, "sp_LayBoPhan", commandType: System.Data.CommandType.StoredProcedure).ToList();
            return boPhan;
        }
        public IList<ChucVuViewBag> ChucVuViewBags()
        {
            List<ChucVuViewBag> chucVu = SqlMapper.Query<ChucVuViewBag>(con, "sp_layChucVu", commandType: System.Data.CommandType.StoredProcedure).ToList();
            return chucVu;
        }
        public IList<QuyenTruyCapViewBag> QuyenTruyCapViewBags()
        {
            List<QuyenTruyCapViewBag> quyen = SqlMapper.Query<QuyenTruyCapViewBag>(con, "sp_layQuyenTruyCap", commandType: System.Data.CommandType.StoredProcedure).ToList();
            return quyen;
        }
        public bool ThemBoPhan(ThemBoPhan boPhan)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ten", boPhan.Ten);
                SqlMapper.Execute(con, "sp_TaoMoiBoPhan", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public bool SuaBoPhan(SuaBoPhan boPhan)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", boPhan.Id);
                parameters.Add("@Ten", boPhan.Ten);
                parameters.Add("@DangHoatDong", boPhan.DangHoatDong);
                SqlMapper.Execute(con, "sp_SuaboPhan", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public bool XoaBoPhan(int id)

        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                SqlMapper.Execute(con, "sp_XoaBoPhan", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return true;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public ThongTinBoPhanTheoId ThongTinBoPhan(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return SqlMapper.Query<ThongTinBoPhanTheoId>(con, "sp_ThongTinBoPhanTheoId", parameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public IList<TimKiemNhanVien> TimKiemNhanVien(string search, int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Search", search);
                parameters.Add("@Id", id);
                List < TimKiemNhanVien > ketQuaTimKiem= SqlMapper.Query<TimKiemNhanVien>(con, "sp_TimKiemNhanVien", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return ketQuaTimKiem;
            }catch(Exception exp)
            {
                throw exp;
            }
        }
    }
}
