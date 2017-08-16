function KategoriEkle()
{
    Kategori = new Object();
    Kategori.KategoriAdi = $("#kategoriAdi").val();
    Kategori.Url = $("#KategoriUrl").val();
    Kategori.AktifMi = $("#KategoriAktif").is(":checked");
    Kategori.ParentID = $('#ParentID').val();
    //Kategori.Kullanici_Id = $('#KullaniciId').text();

    //alert(Kategori.Adi + Kategori.Url + Kategori.Aktif);
    //alert(Kategori.ParentID);

    $.ajax(
        {
            url: "/Kategori/Ekle",
            data: Kategori,
            type: "POST",
            dataType:"json",
            success: function (response)
            {
                if (response.Success)
                {
                    bootbox.alert(response.Message, function ()
                    {
                        location.reload();
                    });
                    //bootboxjs
                }
                else
                {
                    bootbox.alert(response.Message, function ()
                    {
                        //geridöndüğünde bir şey yapılması istneiyorsa buraya yazılır
                    });
                }
            },
            error: function (er1, er2, er3)
            {
                console.log(er3);
            }


        });
}

$(document).on("click", "#KatSil", function ()
{
    var gelenId = $(this).attr("data-id");
    var siltr = $(this).closest("tr");
    var obje= {};
    obje.Id=gelenId;
    $.ajax(
        {
            url: '/Kategori/Sil',
            data:obje,
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                $.notify(response.Message, "success");
                siltr.fadeOut(300, function () { siltr.remove();});
           
         
           
            },
            error: function () { }

        });

})

//function KategoriSil()
//{



//    Kategori = new Object();
//    Kategori.Id = $('#KatSil').attr("data-id");
//    $.ajax(
//        {
//            url: "/Kategori/Sil/" + Kategori.Id,
//            type: "POST",
//            dataType: "json",
//            data: Kategori,
//            success: function (response)
//            {
//                if (response.Success)
//                {
//                    bootbox.alert(response.Message, function ()
//                    {
//                        location.reload();
//                    });
//                }
//                else
//                {
//                    bootbox.alert(response.Message, function () { });
//                }
//            },
//            error: function (er1,er2,er3) { }
//        });
 
//}

function KategoriDuzenle()
{

    var gelenid = $('#ID').val();
    Kategori = new Object();
    Kategori.KategoriAdi = $("#kategoriAdi").val();
    Kategori.Url = $("#KategoriUrl").val();
    Kategori.AktifMi = $("#KategoriAktif").is(":checked");
    Kategori.ParentID = $('#ParentID').val();
    Kategori.ID = gelenid;


    $.ajax(
        {
            url: "/Kategori/Duzenle",
            data: Kategori,
            dataType: "json",
            type: "POST",
            success: function (response)
            {
                if (response.Success)
                {
                    bootbox.alert(response.Message, function ()
                    {
                        location.reload();
                    });
                }
                else
                {
                    bootbox.alert(response.Message, function () { });
                }
            },
            error: function (er1, er2, er3)
            {
                console.log(er3);
            }
        });
  
}

