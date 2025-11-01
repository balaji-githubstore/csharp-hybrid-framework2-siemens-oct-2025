using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecordAutomation.Base
{
    public class BrowserSettings
    {
       
        public string BaseUrl {  get; set; }
        public string BrowserName { get; set; } = "edge";
        public string ChromeBinaryLocation { get; set; }
        public string EdgeBinaryLocation { get; set; }

        public double TimeOut {  get; set; }
    }
}
