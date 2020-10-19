using Core.Interfaces;
using Infrastructure.DAL;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MedPlatformAPI
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
            services.AddControllers();
            services.AddDbContext<MedPlatformContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("ApplicationDbContext")));
        //    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        //    services.AddScoped<IUnitOfWork, UnitOfWork>();
        //    services.AddScoped<IDoctorService, DoctorService>();
        //    services.AddScoped<ICaregiverService, CaregiverService>();
        //    services.AddScoped<IPatientService, PatientService>();
        //    services.AddScoped<IMedicationService, MedicationService>();
        //    services.AddScoped<IMedicationPlanService, MedicationPlanService>();
        //    services.AddScoped<IMedicationPlanDetailsService, MedicationPlanDetailsService>();
        //    services.AddScoped<IMedicalRecordService, MedicalRecordService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
