using BusinessLogic.Services.Base;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface ICommentService : IService<Comment> { }

    public class CommentService : EntityService<Comment>, ICommentService
    {
        public CommentService(EbsContext context) : base(context) { }
    }
}