// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#searchbtn').on('click', function () {
    alert($('#searchid').val());

    $.ajax({
        url: "/home/Index/",
        type: "get",
        data: { searchtxt: $('#searchid').val() },

        success: function () {
            window.location.href = "/search/" + $('#searchid').val() +"?";

        },
        error: function (xhr, status, error) {
            alert(error);
        }
    })
})

