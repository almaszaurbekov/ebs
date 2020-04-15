class MainController {
    constructor(options = {}) {
        this.options = options;
        this._init();
    }

    _init() {
        var url = "/api/ebs/books/index";
        var data = { "minCount": 5 };
        var ajax = this.__ajaxQuery("GET", url, data);

        for (let obj of ajax.responseJSON) {
            var tr = $("<div class='col-md-12 bg-dark text-light py-2 px-2 mb-3'></div>");
            const { id, title, author, userId } = obj;

            tr.append(`<p>Title: ${title}</p>`);
            tr.append(`<p>Author: ${author}</p>`);

            this.options.target.append(tr);
        }
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
            },
            success: function (result) {
                $('.wait-pre-con').hide();
                return result;
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

    var options = {
        target: $("#book-list-target")
    };

    var controller = new MainController(options);
});