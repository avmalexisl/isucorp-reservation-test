﻿var EditViewModel = {
    Id: ko.observable(),
    Name: ko.observable().extend({ required: true }).extend({ maxLength: 80 }),
    Birthdate: ko.observable().extend({ required: true }),
    Type: ko.observable().extend({ required: true }),
    Phone: ko.observable().extend({ digit: true }),
    Description: ko.observable(),

    send: function () {
        var description = froala.froalaEditor('html.get');

        var json = ko.toJS(EditViewModel);
        json.Description = JSON.stringify(description);
        $.ajax({
            url: urlActions.edit,
            type: "POST",
            data: JSON.stringify(json),
            contentType: "application/json",
            success: function (result) {
                window.location.href = urlActions.list;
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    }
};

ko.applyBindings(EditViewModel);

$.getJSON(urlActions.getById,
    function (data) {
        EditViewModel.Id(data.Id);
        EditViewModel.Name(data.Name);
        EditViewModel.Phone(data.Phone);
        EditViewModel.Birthdate(data.FormattedBirthDate);
        EditViewModel.Type(data.Type);

        var decodedDesc = JSON.parse(data.Description);

        $('#edit').html(decodedDesc);
        froala = $('#edit').froalaEditor({
            toolbarButtons: [
                'undo', 'redo', '|', 'paragraphFormat', 'bold', 'italic', 'underline', '|', 'alignLeft', 'alignCenter',
                'alignRight', '|', 'insertLink', 'insertImage', 'insertVideo', 'emoticons'
            ],
            language: $('meta[http-equiv=content-language]').attr('content')
        })
        .on('froalaEditor.image.beforeUpload', function (e, editor, files) {
            if (files.length) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var result = e.target.result;

                    editor.image.insert(result, null, null, editor.image.get());
                };

                reader.readAsDataURL(files[0]);
            }

            return false;
        });
    });


var froala;

$('#birthdate').prop('max', function () {
    return new Date().toJSON().split('T')[0];
});