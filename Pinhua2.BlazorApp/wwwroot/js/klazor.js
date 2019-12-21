window.klazor = {
    showModal: function (name) {
        $(name).modal('show');
    },
    hideModal: function (name) {
        $(name).modal('hide');
    },
    toggleModal: function (name) {
        $(name).modal('toggle');
    },
    alert: function (message) {
        alert(message);
    }
};