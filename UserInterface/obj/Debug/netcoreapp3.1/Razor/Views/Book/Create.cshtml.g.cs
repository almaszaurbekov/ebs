#pragma checksum "C:\Users\Almas\source\repos\ebs\UserInterface\Views\Book\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d26a53cad2f9ba353f3d6000c3b4ec1886ec50af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_Create), @"mvc.1.0.view", @"/Views/Book/Create.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Almas\source\repos\ebs\UserInterface\Views\_ViewImports.cshtml"
using UserInterface;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Almas\source\repos\ebs\UserInterface\Views\_ViewImports.cshtml"
using UserInterface.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d26a53cad2f9ba353f3d6000c3b4ec1886ec50af", @"/Views/Book/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e43315f7187e02b91fbe085b63d31aa8b4d17d98", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserInterface.ViewModels.Entities.BookViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Book", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ByUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Almas\source\repos\ebs\UserInterface\Views\Book\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    #book-container {
        width: 100%;
        height: 550px;
        background: #F1F2F3;
        border-radius: 5px;
        overflow: hidden;
        overflow-y: scroll;
        padding: 10px;
        margin-bottom:50px;
    }
    .wait-pre-con{
        width: 100%;
        height:200px;
        background: url('/img/loader.gif') center no-repeat #F1F2F3;
        display:none;
    }
</style>
<section style=""padding-top:50px;"">
    <div class=""container pt-5"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d26a53cad2f9ba353f3d6000c3b4ec1886ec50af6169", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\Almas\source\repos\ebs\UserInterface\Views\Book\Create.cshtml"
                                                                                     WriteLiteral(ViewBag.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <nav aria-label=\"breadcrumb\">\r\n            <ol class=\"breadcrumb\">\r\n                <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d26a53cad2f9ba353f3d6000c3b4ec1886ec50af8779", async() => {
                WriteLiteral("EBookSharing");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d26a53cad2f9ba353f3d6000c3b4ec1886ec50af10197", async() => {
                WriteLiteral("ELibrary");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "C:\Users\Almas\source\repos\ebs\UserInterface\Views\Book\Create.cshtml"
                                                                                           WriteLiteral(ViewBag.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                <li class=\"breadcrumb-item\">");
#nullable restore
#line 31 "C:\Users\Almas\source\repos\ebs\UserInterface\Views\Book\Create.cshtml"
                                       Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"breadcrumb-item active\" aria-current=\"page\">Add</li>\r\n            </ol>\r\n        </nav>\r\n        <div class=\"row pt-3\">\r\n            <div class=\"col-md-7\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d26a53cad2f9ba353f3d6000c3b4ec1886ec50af13133", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 37 "C:\Users\Almas\source\repos\ebs\UserInterface\Views\Book\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\Almas\source\repos\ebs\UserInterface\Views\Book\Create.cshtml"
                                                                      WriteLiteral(ViewBag.UserId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
                    <li class=""nav-item"">
                        <a class=""nav-link active"" id=""autofill-tab"" data-toggle=""tab"" href=""#autofill"" role=""tab"" aria-controls=""autofill"" aria-selected=""true"">Autofill</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""bookcity-tab"" data-toggle=""tab"" href=""#bookcity"" role=""tab"" aria-controls=""bookcity"" aria-selected=""false"">Bookcity</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""manually-tab"" data-toggle=""tab"" href=""#manually"" role=""tab"" aria-controls=""manually"" aria-selected=""false"">Manually</a>
                    </li>
                </ul>
                <div class=""tab-content pt-3"" id=""myTabContent"">

                    <div class=""tab-pane fade show active"" id=""autofill"" role=""tabpanel"" aria-labelledby=""autofill-tab"">
                 ");
            WriteLiteral(@"       <div class=""form-group"">
                            <label class=""control-label"">Choose a book from our database, just enter a title or author</label>
                            <input id=""book-auto"" class=""form-control"" />
                        </div>
                        <div class=""form-group"">
                            <input id=""book-search-auto"" type=""button"" value=""Search"" class=""btn btn-primary"" />
                        </div>
                    </div>

                    <div class=""tab-pane fade"" id=""bookcity"" role=""tabpanel"" aria-labelledby=""bookcity-tab"">
                        <div class=""form-group"">
                            <label class=""control-label"">Choose a book from the Bookcity database</label>
                            <input id=""book-bc"" class=""form-control"" />
                        </div>
                        <div class=""form-group"">
                            <input id=""book-search-bc"" type=""button"" value=""Search"" class=""btn btn-primary"" ");
            WriteLiteral(@"/>
                        </div>
                    </div>

                    <div class=""tab-pane fade"" id=""manually"" role=""tabpanel"" aria-labelledby=""manually-tab"">
                        <div class=""form-group"">
                            <label>Title</label>
                            <input class=""form-control"" type=""text"" id=""book-title-man"" placeholder=""Enter book's title"" required />
                        </div>
                        <div class=""form-group"">
                            <label>Author</label>
                            <input class=""form-control"" type=""text"" id=""book-author-man"" placeholder=""Enter book's author"" required />
                        </div>
                        <div class=""form-group"">
                            <label>Description</label>
                            <textarea class=""form-control"" id=""book-desc-man"" rows=""5""></textarea>
                        </div>
                        <div class=""form-group"">
                         ");
            WriteLiteral(@"   <label>Rate</label>
                            <input class=""form-control"" type=""number"" id=""book-rate-man"" min=""0"" max=""5"" value=""0"" required />
                        </div>
                        <div class=""form-group pt-3 pb-5"">
                            <button id=""book-man-submit"" class=""btn btn-success btn-block"">Submit</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-5"">
                <div class=""container-fluid"" id=""book-container"">
                    <div class=""wait-pre-con""></div>
                    <div class=""container"" id=""book-list""></div>
                </div>
            </div>
        </div>
    </div>
</section>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $(""#book-search-auto"").click(function () {
                var value = $(""#book-auto"").val();
                if (value.trim() != """") {
                    $.ajax({
                        method: ""POST"",
                        url: ""/api/ebs/books/byvalue"",
                        data: {
                            value: value.trim()
                        },
                        headers: {
                            RequestVerificationToken:
                                $('input:hidden[name=""__RequestVerificationToken""]').val()
                        },
                        beforeSend: function () {
                            $(""#book-list"").empty();
                            $('.wait-pre-con').show();
                            toastr.info(""Your book is searching, please wait"", ""Got it!"");
                        }
                    })
                    .done(function (result) {
                 ");
                WriteLiteral(@"       $('.wait-pre-con').hide();
                        if (result.length > 0) {
                            toastr.success(""A lot of books"", ""Yeah, we have it!"");
                            for (let val of result) {
                                $(""#book-list"").append(`<div class=""row bg-light mb-2 pl-2 pt-2 pr-2 pb-2"">
                                                            <div class=""col-md-4""><img src=""/img/no-book.png"" width=""100%""></div>
                                                            <div class=""col-md-8""><p class=""border-bottom""><b>${val.title}</b></p>
                                                            <button data-id=""${val.id}"" class=""book-auto-details btn btn-primary pull-right"">Добавить</button>
                                                            <p>${val.author}</p></div>
                                                        </div>`);
                            }
                        } else {
                            toastr.error(""There ");
                WriteLiteral(@"is no one book what you are looking for"", ""Oops..."");
                        }
                    });
                }
            });

            $(""#book-search-bc"").click(function () {
                var value = $(""#book-bc"").val();
                if (value.trim() != """") {
                    var url = `https://murmuring-savannah-25756.herokuapp.com/ebs/bookcity/${value.trim()}`
                    $.ajax({
                        method: ""GET"",
                        url: url,
                        headers: {
                            RequestVerificationToken:
                                $('input:hidden[name=""__RequestVerificationToken""]').val()
                        },
                        beforeSend: function () {
                            $(""#book-list"").empty();
                            $('.wait-pre-con').show();
                            toastr.info(""Your book is searching, please wait"", ""Got it!"");
                        }
                    })
   ");
                WriteLiteral(@"                 .done(function (result) {
                        $('.wait-pre-con').hide();
                        if (result.length > 0) {
                            toastr.success(""A lot of books"", ""Yeah, we have it!"");
                            for (let val of result) {
                                $(""#book-list"").append(`<div class=""row bg-light mb-2 pl-2 pt-2 pr-2 pb-2"">
                                                            <div class=""col-md-4""><img src=""${val.image}"" width=""100%""></div>
                                                            <div class=""col-md-8""><p class=""border-bottom""><b>${val.title}</b></p>
                                                            <button data-id=""${val.href}"" class=""book-bc-details btn btn-primary pull-right"">Добавить</button>
                                                            <p>${val.author}</p></div>
                                                        </div>`);
                            }
                        }");
                WriteLiteral(@" else {
                            toastr.error(""There is no one book what you are looking for"", ""Oops..."");
                        }
                    });
                }
            });

            $('#book-list').on('click', '.book-auto-details', function () {
                $.ajax({
                    method: ""POST"",
                    url: ""/api/ebs/books/auto/add"",
                    data: { id: $(this).attr(""data-id"") },
                    headers: {
                        RequestVerificationToken:
                            $('input:hidden[name=""__RequestVerificationToken""]').val()
                    },
                    beforeSend: function () {
                        toastr.info(""We are adding your book"", ""Please wait"");
                    }
                })
                .done(function (result) {
                    if (result == 1) {
                        toastr.success(""Book was added to your library"", ""Successful!"");
                    } else {
 ");
                WriteLiteral(@"                       toastr.error(""There is some problems"", ""Oops..."");
                    }
                });
            });

            $('#book-list').on('click', '.book-bc-details', function () {
                $.ajax({
                    method: ""POST"",
                    url: ""/api/ebs/books/bc/add"",
                    data: { href: $(this).attr(""data-id"") },
                    headers: {
                        RequestVerificationToken:
                            $('input:hidden[name=""__RequestVerificationToken""]').val()
                    },
                    beforeSend: function () {
                        toastr.info(""We are adding your book"", ""Please wait"");
                    }
                })
                .done(function (result) {
                    if (result == 1) {
                        toastr.success(""Book was added to your library"", ""Successful!"");
                    } else {
                        toastr.error(""There is some problems"", ""Oop");
                WriteLiteral(@"s..."");
                    }
                });
            });

            $(""#book-man-submit"").click(function () {
                var title = $(""#book-title-man"").val();
                if(!formField(title, ""Title""))
                    return false;

                var author = $(""#book-author-man"").val();
                if(!formField(author, ""Author""))
                    return false;

                var desc = $(""#book-desc-man"").val();
                if(!formField(desc, ""Description""))
                    return false;

                var rate = $(""#book-rate-man"").val();
                
                $.ajax({
                    method: ""GET"",
                    url: ""/api/ebs/books/manual/add"",
                    data: {
                        title: title,
                        author: author,
                        desc: desc,
                        rate: rate
                    },
                    headers: {
                        RequestVerif");
                WriteLiteral(@"icationToken:
                            $('input:hidden[name=""__RequestVerificationToken""]').val()
                    },
                    beforeSend: function () {
                        toastr.info(""We are adding your book"", ""Please wait"");
                    }
                })
                .done(function (result) {
                    if (result == 1) {
                        toastr.success(""Book was added to your library"", ""Successful!"");
                    } else {
                        toastr.error(""There is some problems"", ""Oops..."");
                    }
                });
            });

            function formField(field, fieldName) {
                if (field != null && field.trim() != """") {
                    return true;
                }
                toastr.error(`${fieldName} is required`, ""Not all fields are filled"")
                return false;
            }
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserInterface.ViewModels.Entities.BookViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
