using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Service.Helpers
{
    public static class ConfigHelper
    {
        public static string ReadAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
