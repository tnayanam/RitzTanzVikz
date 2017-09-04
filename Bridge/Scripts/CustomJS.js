﻿// show coverletter for  a particular company selected.

$(function () {
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

// check whether referral already exist
$(function () {
    var canSubmit = false;
    $('form').submit(function (e) {
        if (!$(this).valid()) {
            return // exit
        }
        if (!canSubmit) {
            e.preventDefault();
            var data = $('form').serialize();
            var url = $(this).data('url');
            $.ajax({
                url: url,
                type: 'POST',
                data: data,
                success: function (response) {
                    if (response.hasPreviousRequest) {
                        if (confirm("You've already applied for this job. Apply again?")) {
                            canSubmit = true;
                            $('form').submit();
                        }
                    }
                    else {
                        canSubmit = true;
                        $('form').submit();
                    }
                },
                error: function () {
                    alert("error");
                }
            });
        }
    });
});