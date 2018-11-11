using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace AutomatedSeekApplication.Core
{  
    public class Config
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<string> ClassificationFilters { get; set; }
        public Config()
        {
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"AppSettings.json"))
            {
                JObject settingsObject = JObject.Parse(file.ReadToEnd());
                this.Email = (string)settingsObject.SelectToken("email");
                this.Password = (string)settingsObject.SelectToken("password");
                JArray classFilter = (JArray)settingsObject.SelectToken("seek.filters.classifications");
                this.ClassificationFilters = classFilter.ToObject<List<string>>();
            }

        }
    }
}
