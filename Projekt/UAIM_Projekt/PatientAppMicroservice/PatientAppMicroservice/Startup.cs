using ExaminationRoomsSelector.Web.Application.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PatientAppMicroservice.Application.Queries;
using PatientAppMicroservice.DataServiceClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientAppMicroservice
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatientAppMicroservice", Version = "v1" });
            });
            services.AddHttpClient();
            services.AddTransient<IPatientAppMicroserviceHandler, PatientAppMicroserviceQueryHandler>();
            services.AddTransient<IPatientsServiceClient, PatientsServiceClient>();
            services.AddTransient<IDoctorsServiceClient, DoctorsServiceClient>();
            services.AddTransient<ITreatmentsServiceClient, TreatmentsServiceClient>();
            services.AddTransient<IAppointmentsServiceClient, AppointmentsServiceClient>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientAppMicroservice"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
