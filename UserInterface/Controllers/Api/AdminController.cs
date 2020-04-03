using AutoMapper;
using BusinessLogic.Services.BusinessService;
using Common;
using GemBox.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Controllers.Api
{
    public class AdminController : EbsApiController
    {
        public AdminController(IAdminBusinessService adminBusinessService,
          IMapper mapper, IWebHostEnvironment hostEnvironment) : base(adminBusinessService, mapper, hostEnvironment)
        { }

        [HttpGet("admin/getBooksAuthor")]
        public async Task<IActionResult> GetBooksCountByAuthor()
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
        public async Task<IActionResult> GetBooksCountByUsers()
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
        public async Task<IActionResult> GetMessagesCountByUsers()
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
        public async Task<IActionResult> GetCommentsCountByUsers()
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
        public async Task<IActionResult> GetBooksInGoodCondition()
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
