using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicCore
{
    public static class ApplicationConfiguration
    {
        public static ConfigurationValues Config { get; set; }
    }

    public class ConfigurationValues
    {
        //app config
        public int SomeConfigItem { get; set; }
    }

}
