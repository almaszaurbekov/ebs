using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using AutoMapper;
using UserInterface.Mappings;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using BusinessLogic.Services.BusinessService;
using UserInterface.Hubs;
using BusinessLogic.Loggers;

namespace UserInterface
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // DbContext Configurations
            services.AddDbContext<EbsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));
            
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Dependency Injection Configurations
            #region AddTransient

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
            services.AddTransient<IBookOperationsLogger, Logger>();

            #endregion

            // Authentication Configurations
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
                options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/User");
            });

            // SignalR Configurations
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapHub<RequestHub>("/request");
            });
        }
    }
}