using Avalonia.Controls.Shapes;
using SharpConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWallAvalonia.Services
{
    public class ConfigService
    {
        private const string CONFIGNAME = "BingWall.cfg";

        public static ConfigService Instance = new ConfigService();


        public ConfigService()
        {
            
        }

        private Configuration Config()
        {
            var filedir = System.IO.Path.Combine(AppContext.BaseDirectory , CONFIGNAME);
            if (System.IO.Path.Exists(filedir))
            {
                //var section = config["General"];

                return Configuration.LoadFromFile(filedir);
            }
            else
            { 

                return new Configuration();
            }
        }

        private void Save(Configuration confg)
        {
            //var filedir = System.IO.Path.Combine(AppContext.BaseDirectory, configobj);
            confg.SaveToFile(CONFIGNAME);
        }

        public void SetProperty(string propertyName, string propertyValue,string groupName = "system")
        {
            var conf = Config();
            
            conf[groupName][propertyName].StringValue = propertyValue;
            Save(conf);
        }

        public string GetProperty(string propertyName,string groupName = "system")
        {
            var conf = Config();
            var section = conf[groupName];
            return section[propertyName].StringValue;
        }
    }
}
