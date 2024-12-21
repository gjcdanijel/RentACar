// wwwroot/js/site.js
$(document).ready(function () {
    $('#confirmDeleteModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // dugme koje je pokrenulo modal
        var carId = button.data('car-id'); // Uzimanje ID-a iz atributa data-car-id

        var modal = $(this);
        modal.find('#carIdToDelete').val(carId); // Postavljanje ID-a u hidden input u formi
    });
});
