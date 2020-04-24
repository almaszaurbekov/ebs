class MainController {
    constructor(options = {}) {
        this.options = options;
        this.api = {
            user: "/api/ebs/users/"
        };
        this._init();
    }

    _init() {
        var user = this.getCurrentUser();

        // у объекта user пока нет поля status
        var status = "Newcomer";
        this.options.status.html(status);

        // Инициализируем список дел для пользователя
        this.initToDoList(user);
    }

    initToDoList(user) {
        
    }

    initTopUsers() {

    }

    initTopBooks() {

    }

    getCurrentUser() {
        var url = this.api.user + "me";
        return this.__ajaxQuery("GET", url, {}).responseJSON;
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
                toastr.error("Обратитесь в тех поддержку", "Запрос вернул ошибку");
                console.log(xhr);
            }
        });
    }
}

$(document).ready(function () {

    var options = {
        toDoList: $("#user-status-todolist"),
        status: $("#user-status"),
        topBooks: $("#ebs-top-books"),
        topUsers: $("#ebs-top-users")
    };

    var controller = new MainController(options);
});