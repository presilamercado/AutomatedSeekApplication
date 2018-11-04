using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedSeekApplication.Models
{
    public class Job
    {
        public string JobId { get; set; }
        public DateTime DatePosted { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
    }
}
