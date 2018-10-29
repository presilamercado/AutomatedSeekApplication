using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomatedSeekApplication
{
    class Program
    {
        static void Main(string[] args)
        {
  
            IWebDriver driver = new ChromeDriver();

            // And now use this to visit Google
            driver.Navigate().GoToUrl("https://www.seek.co.nz/sign-in");
        }
    }
}


// TODO LIST
// Done 1. Go to seek.co.nz login page
// 2. Login with Credentials
// 3. Filter all IT Jobs within NZ for the day
// 4. Define Job Filters example ( Tester, Support, Intermediate, Junior )
// 5. Define Exlude Filters example ( Senior, lead )
// 6. Define filter include Companies 
// 7. Define Exclude Companies
// 8. Save List in a File ( JobId, Description, Company, Location, SubmitStatus, DatePosted )
// 8. Create Cover Letter template
// 9. Apply Job from a save list
// 10. 