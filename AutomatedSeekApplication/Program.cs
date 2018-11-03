using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Support.UI;
using System.Threading;
using Newtonsoft.Json;



namespace AutomatedSeekApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Seek seek = new Seek();
            seek.SignIn();

        }
    }
}