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
            //url: "/Reservation/Create",
            url: urlActions.create,
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

$.getJSON(urlActions.getAll,
    function (data) {
        CreateViewModel.AvailableContacts(data.Items);

        ko.applyBindings(CreateViewModel);
    });

$('#reservation-date').prop('min', function () {
    return new Date().toJSON().split('T')[0];
});