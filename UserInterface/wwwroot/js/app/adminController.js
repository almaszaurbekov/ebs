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
        window.location = url;
    }

    getBooksCountByUsers() {
        var url = this.url + "getBooksUser"
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
}


$(document).ready(function () {

    var controller = new AdminController();

    $("#bs1").click(function () {
        controller.getBooksCountByAuthor();
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