using System;
using System.IO;
using AutoMapper;
using BusinessLogic.Services.BusinessService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace UserInterface.Controllers
{
    [Route("api/ebs")]
    [ApiController]
    public partial class EbsApiController : ControllerBase
    {
        #region Initialize

        protected readonly IUserBusinessService userBusinessService;
        protected readonly IBookBusinessService bookBusinessService;
        protected readonly IMessageBusinessService messageBusinessService;
        protected readonly IAdminBusinessService adminBusinessService;
        protected readonly IMapper mapper;
        protected readonly IWebHostEnvironment hostEnvironment;
        protected string folder;

        public EbsApiController(IBookBusinessService bookBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment)
        {
            this.bookBusinessService = bookBusinessService;
            this.folder = Path.Combine(hostEnvironment.WebRootPath, "files");
            this.mapper = mapper;
        }

        public EbsApiController(IUserBusinessService userBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment)
        {
            this.userBusinessService = userBusinessService;
            this.folder = Path.Combine(hostEnvironment.WebRootPath, "files");
            this.mapper = mapper;
        }

        public EbsApiController(IMessageBusinessService messageBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment)
        {
            this.messageBusinessService = messageBusinessService;
            this.folder = Path.Combine(hostEnvironment.WebRootPath, "files");
            this.mapper = mapper;
        }

        public EbsApiController(IAdminBusinessService adminBusinessService, IMapper mapper,
            IWebHostEnvironment hostEnvironment)
        {
            this.adminBusinessService = adminBusinessService;
            this.folder = Path.Combine(hostEnvironment.WebRootPath, "files");
            this.mapper = mapper;
        }

        #endregion

        /// <summary>
        /// Функция по созданию файла в wwwroot/img
        /// </summary>
        /// <param name="imgfileName">Имя файла, отправленного пользователем</param>
        /// <param name="image">HtppRequest фотографии</param>
        protected string CreateFile(string imgfileName, IFormFile image)
        {
            string fileName = null;
            string folder = Path.Combine(hostEnvironment.WebRootPath, "images");
            fileName = Guid.NewGuid().ToString() + "_" + imgfileName;
            string filepath = Path.Combine(folder, fileName);
            image.CopyTo(new FileStream(filepath, FileMode.Create));
            return fileName;
        }
    }
}