using CaseStudy.BAL;
using CaseStudy.DAL.Interface;
using CaseStudy.Domain.Request.NhanVien;
using CaseStudy.Domain.Request.SendEmailRequest;
using CaseStudy.Domain.Response.NhanVien;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CaseStudy.DAL
{
    public class NhanVienRepository : BaseRepository, INhanVienRepository
    {
        public IList<DiemDanh> ChiTietDiemDanhTheoThang(ThongKeModel model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", model.Id);
            parameters.Add("@Thang", model.Thang);
            parameters.Add("@Nam", model.Nam);

            IList<DiemDanh> diemDanhs = SqlMapper.Query<DiemDanh>(con, "sp_ChiTietDiemDanhTheoNhanVienId", parameters, commandType: CommandType.StoredProcedure).ToList();
            return diemDanhs;
        }

        public DonXinPhepView ChiTietDonXinPhep(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            DonXinPhepView donXinPhep = SqlMapper.Query<DonXinPhepView>(con, "sp_ChiTietDonXinPhep", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return donXinPhep;
        }

        public IList<DonXinPhepView> ChiTietDonXinPhepNhanVienTheoId(int nvId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", nvId);
            IList<DonXinPhepView> donXinPheps = SqlMapper.Query<DonXinPhepView>(con, "XemDonXinPhepNhanVienTheoId", parameters, commandType: CommandType.StoredProcedure).ToList();
            return donXinPheps;
        }

        public NhanVienView LayNhanVienTheoId(int nvId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", nvId);

            NhanVienView nhanVien = SqlMapper.Query<NhanVienView>(con, "LayNhanVienTheoId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return nhanVien;
        }

        public DonXinPhepCreate LayThongTinDonXinPhepTheoId(int nvId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", nvId);
            DonXinPhepCreate donXinPhep = SqlMapper.Query<DonXinPhepCreate>(con, "TaoDonXinPhepView", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return donXinPhep;
        }

        public int TaoDonXinPhep(DonXinPhepCreate model)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NhanVienId", model.NhanVienId); 
                parameters.Add("@NgayBatDau", model.NgayBatDau);
                parameters.Add("@NgayKetThuc", model.NgayKetThuc);
                parameters.Add("@SoPhepConLai", model.SoPhepConLai);
                parameters.Add("@SoNgayDaNghi", model.SoNgayDaNghi);
                parameters.Add("@GhiChu", model.GhiChu);
                parameters.Add("@TraLoi", model.TraLoi);

                var id = SqlMapper.ExecuteScalar<int>(con, "TaoDonXinPhep", parameters, commandType: CommandType.StoredProcedure);
                var sendEmail = EmailService.Send(new SendEmailRequest()
                {
                    template = "",
                    body = $"Thông tin đơn xin phép của nhân viên: <br>"+
                            $"+ Họ tên: {model.HoTen} <br>"+
                            $"+ Bộ phận: {model.BoPhan} <br>"+
                            $"+ Xin nghỉ từ ngày: {model.NgayBatDau.ToString("dddd, dd MMMM yyyy")} <br>"+
                            $"+ Đến ngày : {model.NgayKetThuc.ToString("dddd, dd MMMM yyyy")} <br>"+
                            $"+ Ghi Chú: {model.GhiChu} <br>"+
                            $"+ Ngày Viết Đơn: {model.NgayGui.ToString("dddd, dd MMMM yyyy")}",
                    subject = "Đơn Xin Nghỉ Phép",
                    ToEmail = model.Email
                });

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<ThongKe> ThongKeNhanVienTheoId(int nvId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", nvId);
            IList<ThongKe> thongKeNVs = SqlMapper.Query<ThongKe>(con, "ThongKeNhanVienTheoId", parameters, commandType: CommandType.StoredProcedure).ToList();

            return thongKeNVs;
        }
    }
}
