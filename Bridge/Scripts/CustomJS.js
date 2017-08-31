$(function () {
    var coverLetterSelect = $('#CoverLetterId');
    $('#CompanyId').change(function () {
        var companyId = $(this).val();
        var url = $(this).data('url');
        coverLetterSelect.empty();
        if (!companyId) {
            return;
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
    //var companyFind = $('#companyfind');
    $('#companyfind').click(function () {
        debugger;

        $(".onclick").show();
    });
})



