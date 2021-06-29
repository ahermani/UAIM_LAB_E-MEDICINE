using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationRoomsSelector.Web.Application
{
    public class EnvironmentVars
    {
        public static string DATA_URL = Environment.GetEnvironmentVariable("Data__Url");
    }
}
