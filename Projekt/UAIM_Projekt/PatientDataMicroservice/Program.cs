using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using XMLDatabase;

namespace DoctorsDataMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            { // TODO: Delete this block after full DB
                //new SpecializatonSerializer().SerializeDemo();
                //new PatientSerializer().SerializeDemo();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}