class BookController {
    constructor(options, target) {

        this.options = options;
        this.target = target;
        this.url = '/api/ebs/books/';
        this.bcurl = `https://murmuring-savannah-25756.herokuapp.com/ebs/bookcity/`;

        this._init();
    }

    _init() { }

    getBooksByValue(value) {
        var url = this.bcurl + value;
        return this.__ajaxQuery("GET", url, {});
    }

    getBookListBySearch(search) {
        var data = { search: search };
        var url = this.url + 'index';
        return this.__ajaxQuery("GET", url, data);
    }

    createCol(image, title, author, id, userEmail, createdDate) {
        var col = `<div class="col-md-12"></div>`;
        var row = '<div class="row pt-3 pl-3 pr-3 pb-3 bg-light mb-3"></div>';
        var image = `<div class="col-md-4"><img src="${image}" width="100%"></div>`;
        var fields = '<div class="col-md-8"></div>';

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
        $.ajax({
            method: method,
            url: url,
            data: data,
            contentType: "application/json; charset=utf-8",
            type: "JSON",
            beforeSend: function () {
                $(this.target).empty();
                $('.wait-pre-con').show();
                toastr.info("We process your request", "Please wait.");
            },
            success: function (result) {
                $('.wait-pre-con').hide();
                toastr.success("Request processed successfully", "Success!");
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

    $(".ebs-search").css("display", "none");

    $("#ebs-search-submit").click(function () {
        var search = $("#ebs-search-value").val();
        if (search.trim() != "") {
            var result = controller.getBookListBySearch(search);
            if (result.length > 0) {
                toastr.success("Your book list was successfully updated", "Successful!");
                $("#ebs-target-list").empty();
                for (let book of result) {
                    var { imageSource, title, author, id, createdDate, userEmail } = book;
                    var image = "/img/no-book.png";
                    if (imageSource != null) {
                        image = "/img/" + imageSource;
                    }
                    if (imageSource != null && imageSource.includes("http")) {
                        image = imageSource;
                    }
                    var col = controller.createCol(image, title, author, id, userEmail, createdDate);
                    $("#ebs-target-list").append(col);
                }
            }
            else { toastr.error("There is no books that you have searching", "No result"); }
        }
        else { toastr.error("Search field is empty", "What!?"); }

    });
});