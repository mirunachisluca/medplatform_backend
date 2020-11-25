using AutoMapper;
using Core.Interfaces;
using Infrastructure.DAL;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Infrastructure.Hubs;
using Infrastructure.Services;
using MedPlatformAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;

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
            services.AddCors();
            services.AddControllers();
            services.AddDbContext<MedPlatformContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("ApplicationDbContext")));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<ICaregiverService, CaregiverService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<IMedicationPlanService, MedicationPlanService>();
            services.AddScoped<IMedicationPlanDetailsService, MedicationPlanDetailsService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMedicationStatusService, MedicationStatusService>();
            //services.AddScoped<IActivityService, ActivityService>();

            services.AddSignalR();
            services.AddHostedService<ActivityService>();

            services.AddGrpc();

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));

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

            app.UseGrpcWeb();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:3000", "https://medplatformapp.herokuapp.com")
                .AllowCredentials());

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ActivityMessageHub>("/hubs/activity");
                endpoints.MapGrpcService<PillDispenserService>().EnableGrpcWeb()
                                                          .RequireCors("AllowAll");
            });


        }
    }
}
