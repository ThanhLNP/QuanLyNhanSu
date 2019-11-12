var quanLy = quanLy || {};

quanLy.boPhan = function () {

    var boPhanObj = {};
    boPhanObj.Ngay = $('#Ngay').val();
    boPhanObj.QuanLyId = 2;

    $.ajax({
        url: '/QuanLy/DiemDanhBoPhanAjax',
        method: 'POST',
        dataType: 'json',
        data: JSON.stringify(boPhanObj),
        contentType: 'application/json',
        success: function (data) {
            var nhanVienObj = {};

            $('#tbBoPhan').empty();

            if (data.code === 1) {
                var response = data.response;
                var rows = '';
                $('#tbBoPhan').append("<form>")
                $.each(response, function (index, value) {
                    nhanVienObj.NhanVienId = value.nhanVienId;
                    nhanVienObj.Ngay = value.ngay;
                    nhanVienObj.QuanLyId = 2;

                    rows += "<tr>"
                        + "<td><a href=/QuanLy/DiemDanhNhanVien?NhanVienId=" + value.nhanVienId + "&Ngay=" + value.ngay + ">" + value.hoTen + "</a></td>"
                        + "<td><input type='radio' name='TrangThai" + value.nhanVienId + "' value='1' " + (value.trangThai === 1 ? 'checked' : '') + "></td>"
                        + "<td><input type='radio' name='TrangThai" + value.nhanVienId + "' value='2' " + (value.trangThai === 2 ? 'checked' : '') + "> </td>"
                        + "<td><input type='radio' name='TrangThai" + value.nhanVienId + "' value='3' " + (value.trangThai === 3 ? 'checked' : '') + "> </td>"
                        + "<td><input type='radio' name='TrangThai" + value.nhanVienId + "' value='4' " + (value.trangThai === 4 ? 'checked' : '') + "> </td>"
                        + "<td><input type='radio' name='TrangThai" + value.nhanVienId + "' value='5' " + (value.trangThai === 5 ? 'checked' : '') + "> </td>"
                        + "</tr>";

                });
                $('#tbBoPhan').append(rows).append("</form>");
            }
        }
    });
};
$('#Ngay').on('change', quanLy.boPhan);

