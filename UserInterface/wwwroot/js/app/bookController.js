class BookController {
    constructor(options = null, target = null) {

        this.options = options;
        this.target = target;
        this.url = '/api/ebs/books/';
        this.bcUrl = `https://murmuring-savannah-25756.herokuapp.com/ebs/bookcity/`;
        this.localBcUrl = ``;

        this._init();
    }

    _init() { }

    getBCBooksByValue(value) {
        var url = this.bcurl + value;
        var ajax = this.__ajaxQuery("GET", url, {});
        return ajax.responseJSON;
    }

    getBooksByValue(value) {
        var data = { search: value };
        var url = this.url + 'index';
        var ajax = this.__ajaxQuery("GET", url, data);
        return ajax.responseJSON;
    }

    __getImage(imageSource) {
        var image = "/img/no-book.png";
        if (imageSource != null) {
            image = "/img/" + imageSource;
        }
        if (imageSource != null && imageSource.includes("http")) {
            image = imageSource;
        }
        return image;
    }

    __createCol(image, title, author, id, userEmail, createdDate) {
        var col = $(`<div class="col-md-12"></div>`);
        var row = $('<div class="row pt-3 pl-3 pr-3 pb-3 bg-light mb-3"></div>');
        var image = $(`<div class="col-md-4"><img src="${image}" width="100%"></div>`);
        var fields = $('<div class="col-md-8"></div>');

        fields.append(`<p><b>${title}</b></p>`);
        fields.append(`<p>${author}</p>`);
        fields.append(`<a href="/Book/Details/${id}" class="btn btn-outline-primary pull-right">Visit</a>`);
        fields.append(`<p>${createdDate}</p>`);
        fields.append(`<p>${userEmail}</p>`);

        row.append(image);
        row.append(fields);

        col.append(row);

        return col;
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

    var controller = new BookController();
    if (window.location.href == "https://localhost:44378/Book") {
        $(".ebs-search").css("display", "none");
    }

    // localhost:/Book/Index
    // Search by value
    $("#ebs-search-submit").click(function () {
        var search = $("#ebs-search-value").val();
        if (search.trim() != "") {
            var res = controller.getBooksByValue(search);
            if (res.length > 0) {
                toastr.success("Your book list was successfully updated", "Successful!");
                $("#ebs-target-list").empty();
                for (let book of res) {
                    var { imageSource, title, author, id, createdDate, userEmail } = book;
                    var image = controller.__getImage(imageSource);
                    var col = controller.__createCol(image, title, author, id, userEmail, createdDate);
                    $("#ebs-target-list").append(col);
                }
            }
            else {
                toastr.error("There is no books that you have searching", "No result");
            }
        } else {
            toastr.error("Search field is empty", "What!?");
        }
    });

    // localhost:/Book/Create
    // Search a book by value for autofill
    $("#book-search-auto").click(function () {
        var value = $("#book-auto").val();
        if (value.trim() != "") {
            $.ajax({
                method: "GET",
                url: "/api/ebs/books/byvalue",
                data: {
                    value: value.trim()
                },
                headers: {
                    RequestVerificationToken:
                        $('input:hidden[name="__RequestVerificationToken"]').val()
                },
                beforeSend: function () {
                    $("#book-list").empty();
                    $('.wait-pre-con').show();
                    toastr.info("Your book is searching, please wait", "Got it!");
                }
            })
                .done(function (result) {
                    $('.wait-pre-con').hide();
                    if (result.length > 0) {
                        toastr.success("A lot of books", "Yeah, we have it!");
                        for (let val of result) {
                            $("#book-list").append(`<div class="row bg-light mb-2 pl-2 pt-2 pr-2 pb-2">
                                                                <div class="col-md-4"><img src="/img/no-book.png" width="100%"></div>
                                                                <div class="col-md-8"><p class="border-bottom"><b>${val.title}</b></p>
                                                                <button data-id="${val.id}" class="book-auto-details btn btn-primary pull-right">Добавить</button>
                                                                <p>${val.author}</p></div>
                                                            </div>`);
                        }
                    } else {
                        toastr.error("There is no one book what you are looking for", "Oops...");
                    }
                });
        }
    });
});