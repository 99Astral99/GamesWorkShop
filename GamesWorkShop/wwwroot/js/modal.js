﻿function openModal(parameters) {
    const id = parameters.data;
    const url = parameters.url;
    const isPartial = true;

    const modal = $('#modal');

    if (id === undefined || url === undefined) {
        alert('Something went wrong')
        return;
    }

    $.ajax({
        type: 'GET',
        url: url,
        data: { "id": id, "IsPartial": isPartial },
        success: function (response) {
            modal.find(".modal-body").html(response);
            modal.modal('show')
        },
        failure: function () {
            modal.modal('hide')
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
};