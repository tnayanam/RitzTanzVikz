$(function () {
    var coverLetterSelect = $('#CoverLetterId');
    $('#CompanyId').change(function () {
        var companyId = $(this).val();
        var url = $(this).data('url');
        console.log(url);
        coverLetterSelect.empty();
        if (!companyId) {
            return;
        }
        $.ajax({
              url: url, 
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

