using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentProject.Mapper;
using StudentProject.Models;
using StudentProject.Repository;
using StudentProject.Repository.Interface;
using StudentProject.Service;
using StudentProject.Service.Interface;

namespace StudentProject
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
            services.AddDbContext<SchoolDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IMarksRepository, MarksRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IMarksService, MarksService>();
            var config = new MapperConfiguration(c => {
                c.AddProfile<StudentMapper>();
                c.AddProfile<MarksMapper>();
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=Index}/{id?}");
            });
        }
    }
}
