var quanLy = quanLy || {};

quanLy.nhanVien = function () {

    var nhanVienObj = {};
    nhanVienObj.NhanVienId = $('#NhanVienId').val();
    nhanVienObj.Ngay = $('#Ngay').val();
    nhanVienObj.QuanLyId = 2;

    $.ajax({
        url: '/QuanLy/DiemDanhNhanVienAjax',
        method: 'POST',
        dataType: 'json',
        data: JSON.stringify(nhanVienObj),
        contentType: 'application/json',
        success: function (data) {
            $('#tbNhanVien').empty();
            if (data.code === 1) {
                var response = data.response;
                var rows = "<tr>"
                    + "<td> <p>" + response.hoTen + "</p> </td>"
                    + "<td><input type='radio' name='TrangThai' value='1' " + (response.trangThai === 1 ? 'checked' : '') + "></td>"
                    + "<td><input type='radio' name='TrangThai' value='2' " + (response.trangThai === 2 ? 'checked' : '') + "> </td>"
                    + "<td><input type='radio' name='TrangThai' value='3' " + (response.trangThai === 3 ? 'checked' : '') + "> </td>"
                    + "<td><input type='radio' name='TrangThai' value='4' " + (response.trangThai === 4 ? 'checked' : '') + "> </td>"
                    + "<td><input type='radio' name='TrangThai' value='5' " + (response.trangThai === 5 ? 'checked' : '') + "> </td>"
                    + "</tr>";
                $('#tbNhanVien').append(rows);
            }
        }
    });
};

$('#Ngay').on('change', quanLy.nhanVien);