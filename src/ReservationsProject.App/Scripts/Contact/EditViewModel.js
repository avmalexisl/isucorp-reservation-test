var EditViewModel = {
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
            url: "/Contact/Edit",
            type: "POST",
            data: JSON.stringify(json),
            contentType: "application/json",
            success: function (result) {
                window.location.href = window.location.origin + "/Contact/List";
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    }
};

ko.applyBindings(EditViewModel);

/*EditViewModel.Id($('#hidden-id').val());
EditViewModel.Name($('#hidden-name').val());
EditViewModel.Type($('#hidden-type').val());
EditViewModel.Birthdate(Date($('#hidden-birthdate').val()));
EditViewModel.Phone($('#hidden-phone').val());
EditViewModel.Description($('#hidden-description').html());*/

$.getJSON("/Contact/GetById/" + $('#hidden-id').val(),
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
            ]
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