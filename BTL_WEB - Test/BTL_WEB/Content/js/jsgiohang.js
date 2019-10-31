
function tinhtientheosoluong(giatien, id, slhang)
{
    
    var soluong = $("#soluongsanpham_" + id).val();
    
   
    if (soluong <= 0) {
        $("#soluongsanpham_" + id).val(1);   
    }
    soluong = $("#soluongsanpham_" + id).val();
    console.log(id);
    var tien = soluong * giatien;
    console.log(slhang);
    $("#tongtien_" + id).html(tien.toString() + " đ");
    updatetien(slhang);
}

function updatetien(x)
{
    var tong = 0;
    for (var  id = 1; id <= x; id++)
    {
        var tien = $("#tongtien_" + id).text();
        var quytien = parseInt(tien.split(' ')[0]);
        tong = tong + quytien;
        console.log(quytien);
    }
    $(".tongtiengiohang").text(tong);
    
}