class MainController {
    constructor(options = {}) {
        this.options = options;
        this.api = {
            user: "/api/ebs/users/",
            book: "/api/ebs/books/",
            transaction: "/api/ebs/transactions/"
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
        var progress = {
            privateData: this.__isUserDataIsFull(user.data),
            books: { isSuccess: false, currentCount: 0 },
            // Успешно одолженные книги
            successBorrow: { isSuccess: false, currentCount: 0, waitList: 0 },
            // Успешно закрытые долги по книгам
            successRequest: { isSuccess: false, currentCount: 0, waitList: 0 }
        };

        var url = this.api.book + `count/user/${user.data.id}`;
        var books = this.__ajaxQuery("GET", url, {}).responseJSON;

        url = this.api.transaction + `user/${user.data.id}`;
        var transactions = this.__ajaxQuery("GET", url, {}).responseJSON;

        // Проверка на заполнение библиотеки 5 книгами
        progress.books.currentCount = books.count;
        if (books.count >= 5) progress.books.isSuccess = true;

        // Пробегаемся по всем транзакциям, где пользователь принимал участие
        for (let tr of transactions.data) {
            if (tr.borrowerId == user.data.id) {
                if (tr.isSuccess == 1) {
                    progress.successBorrow.currentCount += 1;
                }
                else {
                    progress.successBorrow.waitList += 1;
                }
            }
            if (tr.ownerId == user.data.id) {
                if (tr.isSuccess == 1) {
                    progress.successRequest.currentCount += 1;
                }
                else {
                    progress.successRequest.waitList += 1;
                }
            }
        }

        // Проверка на количество успешно одолженных книг (мин. 3)
        if (progress.successBorrow.currentCount >= 3) {
            progress.successBorrow.isSuccess = true;
        }

        // Проверка на количество успешно закрытых долгов по книгам (мин. 3)
        if (progress.successRequest.currentCount >= 3) {
            progress.successRequest.isSuccess = true;
        }
    }

    

    initTopUsers() {

    }

    initTopBooks() {

    }

    getCurrentUser() {
        var url = this.api.user + "me";
        return this.__ajaxQuery("GET", url, {}).responseJSON;
    }

    __isUserDataIsFull(user) {
        const { address, firstName, lastName } = user;
        return { isSuccess: (this.__isNotNull(address) & this.__isNotNull(firstName) &
            this.__isNotNull(lastName)) == 1 };
    }

    __isNotNull(data) {
        return data != null;
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