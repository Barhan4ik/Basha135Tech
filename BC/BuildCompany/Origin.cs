using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BuildCompany
{
    public class Origin
    {
        public Origin(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //string con = Configuration.GetConnectionString("DefaultConnection");
            string con = "Server=Localhost\\SQLEXPRESS;Database=practika;Trusted_Connection=True;";
            // устанавливаем контекст данных
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(con));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v.1", new OpenApiInfo { Title = "BuildCompany", Version = "v.1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v.1/swagger.json", "BuildCompany v.1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}