function showAlert(message, type) {
    var alertPlaceholder = $('#alertPlaceholder');
    if (alertPlaceholder.length === 0) {
        $('body').prepend('<div id="alertPlaceholder" style="position: fixed; top: 80px; right: 20px; z-index: 9999;"></div>');
        alertPlaceholder = $('#alertPlaceholder');
    }

    var alertHtml = `<div class="alert alert-${type} alert-dismissible fade show" role="alert">
                        ${message}
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                     </div>`;

    alertPlaceholder.html(alertHtml);

    setTimeout(function () {
        alertPlaceholder.find('.alert').fadeOut('slow', function () { $(this).remove(); });
    }, 3000);
}