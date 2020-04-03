class AdminController {
    constructor(options = null, target = null) {

        this.options = options;
        this.target = target;
        this.url = "/api/ebs/admin/";

        this._init();
    }

    _init() { }
    
    getBooksCountByAuthor() {
        var url = this.url + "getBooksAuthor";
        window.location = url;
    }

    getBooksCountByUsers() {
        var url = this.url + "getBooksUser";
        window.location = url;
    }

    getMessagesCountByUsers() {
        var url = this.url + "getMessages";
        window.location = url;
    }

    getCommentsCountByUsers() {
        var url = this.url + "getComments";
        window.location = url;
    }

    getBooksInGoodCondition() {
        var url = this.url + "getBooksInGoodConditon";
        window.location = url;
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

    var controller = new AdminController();

    $("#bs1").click(function () {
        controller.getBooksCountByAuthor();
    });
    $("#bs2").click(function () {
        controller.getBooksInGoodCondition();
    });
    $("#us1").click(function () {
        controller.getBooksCountByUsers();
    });
    $("#us2").click(function () {
        controller.getMessagesCountByUsers();
    });
    $("#us3").click(function () {
        controller.getCommentsCountByUsers();
    });

});