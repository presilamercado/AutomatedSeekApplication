using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedSeekApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Seek seek = new Seek();
            seek.SignIn();

            seek.ListJobs();

            

        }
    }
}
