class TransactionController {
    constructor(options, target) {

        this.options = options;
        this.target = target;
        this.url = '/api/ebs/transactions/';
    }

    accept(id) {
        var url = this.url + "accept";
        var data = { id: id };
        var result = this.__ajaxQuery("GET", url, data);
        console.log(result);
    }

    cancel(id) {
        var url = this.url + "cancel";
        var data = { id: id };
        var result = this.__ajaxQuery("GET", url, data);
        console.log(result);
    }

    __ajaxQuery(method, url, data) {
        return $.ajax({
            method: method,
            url: url,
            data: data,
            contentType: "application/json; charset=utf-8",
            type: "JSON",
            async: false,
            beforeSend: function () {
                $(this.target).empty();
                $('.wait-pre-con').show();
                toastr.info("We process your request", "Please wait.");
            },
            success: function (result) {
                $('.wait-pre-con').hide();
                toastr.success("Пользователю пришло уведомление о вашем решении", "Запрос обработан!");
            },
            error: function (xhr) {
                $('.wait-pre-con').hide();
                toastr.error("Failed to process request", "Error");
                console.log(xhr);
            }
        });
    }
}

$(document).ready(function () {

    var controller = new TransactionController();

    $(".ebs-btn-accept").click(function () {
        var id = $(this).attr("data-id");
        controller.accept(id);
        $(`#ebs-${id}`).fadeOut();
    });

    $(".ebs-btn-cancel").click(function () {
        var id = $(this).attr("data-id");
        controller.cancel(id);
        $(`#ebs-${id}`).fadeOut();
    });

});