var CreateViewModel = {
    AvailableContacts: ko.observableArray([]),
    SelectedContact: ko.observable(),
    ReservationDate: ko.observable().extend({ required: true }),
    ReservationRating: ko.observable(),

    send: function () {

        var json = ko.toJS({
            ReservationDate: CreateViewModel.ReservationDate(),
            Rating: CreateViewModel.ReservationRating(),
            ContactId: CreateViewModel.SelectedContact().Id
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

$.getJSON("/Contact/GetAll/",
    function (data) {
        CreateViewModel.AvailableContacts(data.Items);

        ko.applyBindings(CreateViewModel);
    });