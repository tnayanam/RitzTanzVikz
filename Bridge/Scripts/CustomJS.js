﻿$(function () {
    var coverLetterSelect = $('#CoverLetterId');
    $('#CompanyId').change(function () {
        var companyId = $(this).val();
        var url = $(this).data('url');
        coverLetterSelect.empty();
        if (!companyId) {
            return;
        }
        if (companyId == 4)
        {
            $('.js-div').show();
        }
        else {
            $('.js-div').hide();
        }
        $.ajax({
            url: url,
            type: 'POST',
            data: { companyId: companyId },
            success: function (response) {
                coverLetterSelect.append($('<option></option>').val('').text('None'));
                $.each(response, function (i, data) {
                    coverLetterSelect.append($('<option></option>').val(data.Value).text(data.Text));
                });
            },
            error: function () { }
        });
    });
})

$(function () {
    $('.mybtn').click(function () {
        $.ajax({
            url: url,
            type: 'POST',
            data: { companyName: companyName },
            success: function (response) {
                alert("hell");
            },
            error: function () { alert("fail") }
        });
    });
});