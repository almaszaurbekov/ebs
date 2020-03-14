class BookController {
    constructor(options, target) {

        this.options = options;
        this.target = target;
        this.url = `https://murmuring-savannah-25756.herokuapp.com/ebs/bookcity/`;

        this._init();
    }

    _init() { }

    getBooksByValue(value) {
        alert(this.url + value);
        $.ajax({
            method: "GET",
            url: this.url + value,
            headers: {
                RequestVerificationToken:
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            beforeSend: function () {
                $(this.target).empty();
                $('.wait-pre-con').show();
                toastr.info("Your book is searching, please wait", "Got it!");
            }
        })
        .done(function (result) {
            $('.wait-pre-con').hide();
            return result;
        });
    }
}