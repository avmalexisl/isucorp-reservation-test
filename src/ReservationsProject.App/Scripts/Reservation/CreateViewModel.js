var CreateViewModel = {
    ContactsName: ko.observable().extend({ required: true }).extend({ maxLength: 80 }),
    Birthdate: ko.observable().extend({ required: true }),
    Type: ko.observable().extend({ required: true }),
    Phone: ko.observable().extend({ digit: true }),
    Description: ko.observable(),

    send: function () {

        var json = ko.toJS({
            ReservationDate: '2018-11-20 00:00:00.000',
            Rating: 5,
            ContactId: 2
        });
        $.ajax({
            url: "/Reservation/Create",
            type: "POST",
            data: JSON.stringify(json),
            contentType: "application/json",
            success: function (result) {
                window.location.href = window.location.origin + "/Reservation/List";
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    }
};

ko.applyBindings(CreateViewModel);