class UserController {
    constructor(options, target) {

        this.options = options;
        this.target = target;
        this.url = '/api/ebs/users/';

        this._init();
    }

    getUserListBySearch(search) {
        var data = { search: search };
        var url = this.url + 'list';
        return this.__ajaxQuery("GET", url, data);
    }

    createCol(id, email, image) {
        var col = '<div class="col-md-12"></div>';
        var row = '<div class="row pt-3 pl-3 pr-3 pb-3 bg-light mb-3"></div>'
        var image = `<div class="col-md-4"><img src="${image}" width="100%" /></div>`;
        var fields = `<div class="col-md-8"></div>`;

        fields.append(`<p><b>${email}</b></p>`);
        fields.append(`<a href="/User/Details/${id}" class="btn btn-outline-primary">Visit</a>`);
        fields.append(`<a href="/Message/Send/${id}" class="btn btn-outline-success">Message</a>`);
        fields.append(`<a href="/Book/ByUser/${id}" class="btn btn-primary">ELibrary</a>`);

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
                toastr.info("We process your request", "Please wait.");
            },
            success: function (result) {
                toastr.success("Request processed successfully", "Success!");
                return result;
            },
            error: function (xhr) {
                console.log(xhr);
                toastr.error("Failed to process request", "Error");
            }
        });
    }
}

$(document).ready(function () {

    var controller = new UserController();

    $("#ebs-search-submit").click(function () {
        var search = $("#ebs-search-value").val();
        if (search.trim() != "") {
            var result = controller.getUserListBySearch(search);
            if (result.length > 0) {
                toastr.success("Your user list was successfully updated", "Successful!");
                $("#ebs-target-list").empty();
                for (let user of result) {
                    var { imageSource, email, id } = user;
                    var image = "/img/no-user.png";
                    if (imageSource != null) {
                        image = "/img/" + imageSource;
                    }
                    var col = controller.createCol(id, email, image);
                    $("#ebs-target-list").append(col);
                }
            }
            else { toastr.error("There is no user that you have searching", "No result"); }
        }
        else { toastr.error("Search field is empty", "What!?"); }
    });

});