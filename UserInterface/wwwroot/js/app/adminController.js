class AdminController {
    constructor(options = null, target = null) {

        this.options = options;
        this.target = target;
        this.url = "/api/ebs/admin/"

        this._init();
    }

    _init() { }
    
    getBooksCountByAuthor() {
        var url = this.url + "getBooksAuthor";
        return this.__ajaxQuery("GET", url, {});
    }

    getBooksCountByUsers() {
        var url = this.url + "getBooksUser"
        return this.__ajaxQuery("GET", url, {});
    }

    getMessagesCountByUsers() {
        var url = this.url + "getMessages";
        return this.__ajaxQuery("GET", url, {});
    }

    getCommentsCountByUsers() {
        var url = this.url + "getComments";
        return this.__ajaxQuery("GET", url, {});
    }

    __ajaxQuery(method, url, data) {
        var ajax = $.ajax({
            method: method,
            url: url,
            data: data,
            beforeSend: function () {
                toastr.info("We process your request", "Please wait.");
            },
            success: function (result) {
                toastr.success("Request processed successfully", "Success!");
            },
            async: false,
            error: function (xhr) {
                console.log(xhr);
                toastr.error("Failed to process request", "Error");
            }
        });

        return ajax.responseJSON;
    }
}


$(document).ready(function () {

    var controller = new AdminController();

    $("#bs1").click(function () {
        var groups = controller.getBooksCountByAuthor();
        console.log(groups);
    });
    $("#us1").click(function () {
        var groups = controller.getBooksCountByUsers();
        console.log(groups);
    });
    $("#us2").click(function () {
        var groups = controller.getMessagesCountByUsers();
        console.log(groups);
    });
    $("#us3").click(function () {
        var groups = controller.getCommentsCountByUsers();
        console.log(groups);
    });

});