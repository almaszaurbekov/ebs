class AdminController {
    constructor(thead, tbody, title, excelButton) {

        this.thead = thead;
        this.tbody = tbody;
        this.title = title;
        this.excelButton = excelButton;

        this.active = "/api/ebs/admin/getUsers";
        this.url = "/api/ebs/admin/";

        this._init();
    }

    _init() { }

    getBookList() {
        this.title.html("Books Count By Author");
        this.active = this.url + "excel/getBooks";
        this.__clear();

        var url = "/api/ebs/books/index";
        var ajax = this.__ajaxQuery("GET", url, {});

        this.thead.append("<th scope='col'>Id</th>");
        this.thead.append("<th scope='col'>Title</th>");
        this.thead.append("<th scope='col'>Author</th>");
        this.thead.append("<th scope='col'>User Id</th>");

        for (let obj of ajax.responseJSON) {
            var tr = $("<tr></tr>");
            const { id, title, author, userId } = obj;

            tr.append(`<th scope="row">${id}</th>`);
            tr.append(`<td>${title}</td>`);
            tr.append(`<td>${author}</td>`);
            tr.append(`<td>${userId}</td>`);

            this.tbody.append(tr);
        }
    }

    getBooksCountByAuthor() {
        this.title.html("Books Count By Author");
        this.active = this.url + "excel/getBooksAuthor";
        this.__clear();

        var url = this.url + "getBooksAuthor";
        var ajax = this.__ajaxQuery("GET", url, {});

        this.thead.append("<th scope='col'>Author</th>");
        this.thead.append("<th scope='col'>Books Count</th>");

        for (let obj of ajax.responseJSON) {
            var tr = $("<tr></tr>");
            const { author, count } = obj;

            tr.append(`<th scope="row">${author}</th>`);
            tr.append(`<td>${count}</td>`);

            this.tbody.append(tr);
        }
    }

    getBooksInGoodCondition() {
        this.title.html("Books In Good Condition");
        this.active = this.url + "excel/getBooksInGoodConditon";
        this.__clear();

        var url = this.url + "getBooksInGoodConditon";
        var ajax = this.__ajaxQuery("GET", url, {});

        this.thead.append("<th scope='col'>Author</th>");
        this.thead.append("<th scope='col'>Title</th>");
        this.thead.append("<th scope='col'>Last Comment</th>");
        this.thead.append("<th scope='col'>Last Comment Time</th>");

        for (let obj of ajax.responseJSON) {
            var tr = $("<tr></tr>");
            const { author, title, lastCommentText, lastCommentTime } = obj;

            tr.append(`<th scope="row">${author}</th>`);
            tr.append(`<td>${title}</td>`);
            tr.append(`<td>${lastCommentText}</td>`);
            tr.append(`<td>${this.__getDateTime(lastCommentTime)}</td>`);

            this.tbody.append(tr);
        }
    }

    getBooksCountByUsers() {
        this.title.html("Books Count By Users");
        this.active = this.url + "excel/getBooksUser";
        this.__clear();

        var url = this.url + "getBooksUser";
        var ajax = this.__ajaxQuery("GET", url, {});

        this.thead.append("<th scope='col'>User ID</th>");
        this.thead.append("<th scope='col'>Books Count</th>");

        for (let obj of ajax.responseJSON) {
            var tr = $("<tr></tr>");
            const { id, count } = obj;

            tr.append(`<th scope="row">${id}</th>`);
            tr.append(`<td>${count}</td>`);

            this.tbody.append(tr);
        }
    }

    getUserList() {
        this.title.html("Users");
        this.active = this.url + "getUsers";
        this.__clear();

        var url = "/api/ebs/users";
        var ajax = this.__ajaxQuery("GET", url, {});

        this.thead.append("<th scope='col'>#</th>");
        this.thead.append("<th scope='col'>Email</th>");
        this.thead.append("<th scope='col'>FullName</th>");
        this.thead.append("<th scope='col'>Address</th>");
        this.thead.append("<th scope='col'>Role</th>");

        for (let obj of ajax.responseJSON) {
            var tr = $("<tr></tr>");
            const { id, email, fullName, address, roleName } = obj;

            tr.append(`<th scope="row">${id}</th>`);
            tr.append(`<td>${email}</td>`);
            tr.append(`<td>${fullName}</td>`);
            tr.append(`<td>${address}</td>`);
            tr.append(`<td>${roleName}</td>`);

            this.tbody.append(tr);
        }
    }

    getMessagesCountByUsers() {
        this.title.html("Messages Count By Users");
        this.active = this.url + "excel/getMessages";
        this.__clear();

        var url = this.url + "getMessages";
        var ajax = this.__ajaxQuery("GET", url, {});

        this.thead.append("<th scope='col'>User ID</th>");
        this.thead.append("<th scope='col'>Books Count</th>");

        for (let obj of ajax.responseJSON) {
            var tr = $("<tr></tr>");
            const { id, count } = obj;

            tr.append(`<th scope="row">${id}</th>`);
            tr.append(`<td>${count}</td>`);

            this.tbody.append(tr);
        }
    }

    getCommentsCountByUsers() {
        this.title.html("Comments Count By Users");
        this.active = this.url + "excel/getComments";
        this.__clear();

        var url = this.url + "getComments";
        var ajax = this.__ajaxQuery("GET", url, {});

        this.thead.append("<th scope='col'>User ID</th>");
        this.thead.append("<th scope='col'>Books Count</th>");

        for (let obj of ajax.responseJSON) {
            var tr = $("<tr></tr>");
            const { id, count } = obj;

            tr.append(`<th scope="row">${id}</th>`);
            tr.append(`<td>${count}</td>`);

            this.tbody.append(tr);
        }
    }

    __clear() {
        this.tbody.empty();
        this.thead.empty();
    }

    __getDateTime(time) {
        if (time != null) {
            var date = time.split("T");
            return date[0];
        }
        return time;
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
                //toastr.info("We process your request", "Please wait.");
            },
            success: function (result) {
                $('.wait-pre-con').hide();
                //toastr.success("Your request is processed", "Success");
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
        thead: $("#admin-thead-target"),
        tbody: $("#admin-tbody-target"),
        title: $("#current-table"),
        excelButton: $("#excel-button")
    };

    var controller = new AdminController(options.thead,
        options.tbody, options.title, options.excelButton);

    controller.getUserList();

    $("#excel-button").click(function () {
        window.location = controller.active;
    });

    // Books
    $("#bs0").click(function () {
        controller.getBookList();
    });
    $("#bs1").click(function () {
        controller.getBooksCountByAuthor();
    });
    $("#bs2").click(function () {
        controller.getBooksInGoodCondition();
    });
    $("#bs3").click(function () {
        controller.getBooksCountByUsers();
    });
    // Users
    $("#us0").click(function () {
        controller.getUserList();
    });
    // Messages
    $("#ms1").click(function () {
        controller.getMessagesCountByUsers();
    });
    //Comments
    $("#cs1").click(function () {
        controller.getCommentsCountByUsers();
    });
});