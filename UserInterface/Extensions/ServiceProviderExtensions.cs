using BusinessLogic.Services;
using BusinessLogic.Services.BusinessService;
using Microsoft.Extensions.DependencyInjection;

namespace UserInterface.Extensions
{

    public static class ServiceProviderExtensions
    {
        public static void AddEbsServices(this IServiceCollection services)
        {
            services.AddTransient<IUserBusinessService, UserBusinessService>();
            services.AddTransient<IBookBusinessService, BookBusinessService>();
            services.AddTransient<IMessageBusinessService, MessageBusinessService>();
            services.AddTransient<IAdminBusinessService, AdminBusinessService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IDialogControlService, DialogControlService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IBcBookService, BcBookService>();
            services.AddTransient<IBookTransactionService, BookTransactionService>();
        }
    }
}
