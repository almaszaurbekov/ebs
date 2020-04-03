using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Services.BusinessService;
using Common;
using DataAccess.Models;
using GemBox.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserInterface.ViewModels;

namespace UserInterface.Controllers.Api
{
    public class AdminController : EbsApiController
    {
        public AdminController(IAdminBusinessService adminBusinessService, IUserBusinessService userBusinessService,
            IBookBusinessService bookBusinessService, IMapper mapper, IWebHostEnvironment hostEnvironment) 
            : base(adminBusinessService, userBusinessService, bookBusinessService, mapper, hostEnvironment)
        { }

        [HttpGet("admin/getBooksAuthor")]
        public async Task<List<BookGroup>> GetBooksCountByAuthor()
        {
            return await adminBusinessService.GetBooksCountByAuthor();
        }

        [HttpGet("admin/excel/getBooksAuthor")]
        public async Task<IActionResult> DownloadBooksCountByAuthor()
        {
            var groups = await adminBusinessService.GetBooksCountByAuthor();
            var excel = new Excel();

            excel.WriteCell(0, 0, "Author");
            excel.WriteCell(0, 1, "Count of books");

            for (var i = 0; i < groups.Count; i++)
            {
                excel.WriteCell(i + 1, 0, groups[i].Author);
                excel.WriteCell(i + 1, 1, groups[i].Count.ToString());
            }

            return File(GetBytes(excel.xlsWorkBook, excel.xlsOptions),
                excel.xlsOptions.ContentType, "GetBooksCountByAuthor.xls");
        }

        [HttpGet("admin/getBooksUser")]
        public async Task<List<ShortUserList>> GetBooksCountByUsers()
        {
            return await adminBusinessService.GetBooksCountByUsers();
        }

        [HttpGet("admin/excel/getBooksUser")]
        public async Task<IActionResult> DownloadBooksCountByUsers()
        {
            var groups = await adminBusinessService.GetBooksCountByUsers();
            var excel = new Excel();

            excel.WriteCell(0, 0, "User ID");
            excel.WriteCell(0, 1, "Count of Books");

            for (var i = 0; i < groups.Count; i++)
            {
                excel.WriteCell(i + 1, 0, groups[i].Id.ToString());
                excel.WriteCell(i + 1, 1, groups[i].Count.ToString());
            }

            return File(GetBytes(excel.xlsWorkBook, excel.xlsOptions),
                excel.xlsOptions.ContentType, "GetBooksCountByUsers.xls");
        }

        [HttpGet("admin/getMessages")]
        public async Task<List<ShortUserList>> GetMessagesCountByUsers()
        {
            return await adminBusinessService.GetMessagesCountByUsers();
        }

        [HttpGet("admin/excel/getMessages")]
        public async Task<IActionResult> DownloadMessagesCountByUsers()
        {
            var groups = await adminBusinessService.GetMessagesCountByUsers();
            var excel = new Excel();

            excel.WriteCell(0, 0, "User ID");
            excel.WriteCell(0, 1, "Count of Messages");

            for (var i = 0; i < groups.Count; i++)
            {
                excel.WriteCell(i + 1, 0, groups[i].Id.ToString());
                excel.WriteCell(i + 1, 1, groups[i].Count.ToString());
            }

            return File(GetBytes(excel.xlsWorkBook, excel.xlsOptions),
                excel.xlsOptions.ContentType, "GetMessagesCountByUsers.xls");
        }

        [HttpGet("admin/getComments")]
        public async Task<List<ShortUserList>> GetCommentsCountByUsers()
        {
            return await adminBusinessService.GetCommentsCountByUsers();
        }

        [HttpGet("admin/excel/getComments")]
        public async Task<IActionResult> DownloadCommentsCountByUsers()
        {
            var groups = await adminBusinessService.GetCommentsCountByUsers();
            var excel = new Excel();

            excel.WriteCell(0, 0, "User ID");
            excel.WriteCell(0, 1, "Count of Comments");

            for (var i = 0; i < groups.Count; i++)
            {
                excel.WriteCell(i + 1, 0, groups[i].Id.ToString());
                excel.WriteCell(i + 1, 1, groups[i].Count.ToString());
            }

            return File(GetBytes(excel.xlsWorkBook, excel.xlsOptions),
                excel.xlsOptions.ContentType, "GetCommentsCountByUsers.xls");
        }

        [HttpGet("admin/getBooksInGoodConditon")]
        public async Task<List<GoodBookList>> GetBooksInGoodCondition()
        {
            return await adminBusinessService.GetBooksByCondition();
        }

        [HttpGet("admin/excel/getBooksInGoodConditon")]
        public async Task<IActionResult> DownloadBooksInGoodCondition()
        {
            try
            {
                var groups = await adminBusinessService.GetBooksByCondition();
                var excel = new Excel();

                excel.WriteCell(0, 0, "Author");
                excel.WriteCell(0, 1, "BookName");
                excel.WriteCell(0, 2, "LastCommentText");
                excel.WriteCell(0, 3, "LastCommnetTime");

                for (var i = 0; i < groups.Count; i++)
                {
                    string LastCommentTime = groups[i].LastCommentTime.HasValue ?
                        groups[i].LastCommentTime.Value.ToShortDateString().ToString() : string.Empty;

                    string LastCommentText = groups[i].LastCommentText != null ?
                        groups[i].LastCommentText : string.Empty;

                    excel.WriteCell(i + 1, 0, groups[i].Author);
                    excel.WriteCell(i + 1, 1, groups[i].Title);
                    excel.WriteCell(i + 1, 2, LastCommentText);
                    excel.WriteCell(i + 1, 3, LastCommentTime);
                }

                return File(GetBytes(excel.xlsWorkBook, excel.xlsOptions),
                    excel.xlsOptions.ContentType, "GetBooksInGoodCondition.xls");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("admin/getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var excel = new Excel();
                var users = await userBusinessService.GetUsers();
                var usersVM = mapper.Map<List<UserDto>, List<UserListViewModel>>(users);

                excel.WriteCell(0, 0, "Id");
                excel.WriteCell(0, 1, "Email");
                excel.WriteCell(0, 2, "Full Name");
                excel.WriteCell(0, 3, "Address");
                excel.WriteCell(0, 4, "Role Name");

                for (var i = 0; i < usersVM.Count; i++)
                {
                    var address = usersVM[i].Address != null ?
                        usersVM[i].Address : string.Empty;

                    excel.WriteCell(i + 1, 0, usersVM[i].Id.ToString());
                    excel.WriteCell(i + 1, 1, usersVM[i].Email);
                    excel.WriteCell(i + 1, 2, usersVM[i].FullName);
                    excel.WriteCell(i + 1, 3, address);
                    excel.WriteCell(i + 1, 4, usersVM[i].RoleName);
                }

                return File(GetBytes(excel.xlsWorkBook, excel.xlsOptions),
                    excel.xlsOptions.ContentType, "GetUsers.xls");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("admin/excel/getBooks")]
        public async Task<IActionResult> DownloadBooks()
        {
            var groups = await bookBusinessService.GetBooks();
            var excel = new Excel();

            excel.WriteCell(0, 0, "Id");
            excel.WriteCell(0, 1, "Title");
            excel.WriteCell(0, 2, "Author");
            excel.WriteCell(0, 3, "User Id");

            for (var i = 0; i < groups.Count; i++)
            {
                excel.WriteCell(i + 1, 0, groups[i].Id.ToString());
                excel.WriteCell(i + 1, 1, groups[i].Title);
                excel.WriteCell(i + 1, 2, groups[i].Author);
                excel.WriteCell(i + 1, 3, groups[i].UserId.ToString());
            }

            return File(GetBytes(excel.xlsWorkBook, excel.xlsOptions),
                excel.xlsOptions.ContentType, "GetBooksCountByAuthor.xls");
        }

        private static byte[] GetBytes(ExcelFile file, SaveOptions options)
        {
            using (var stream = new MemoryStream())
            {
                file.Save(stream, options);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Скачать созданный файл
        /// </summary>
        /// <param name="fileName">Созданный файл</param>
        [HttpGet("download")]
        public FileResult DownloadExcel(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                IFileProvider provider = new PhysicalFileProvider(folder);
                IFileInfo fileInfo = provider.GetFileInfo(fileName);
                var readStream = fileInfo.CreateReadStream();
                var fileType = "text/plain";

                return File(readStream, fileType, fileName);
            }
            else
            {
                return null;
            }
        }
    }
}
