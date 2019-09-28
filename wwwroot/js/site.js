// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function() {
   $("input[name=id]").on('click', function (e) {
       pickTheDate(e.target);
   });
});

function pickTheDate(radio) {
    var form = radio.closest('form');
    form.submit();
}