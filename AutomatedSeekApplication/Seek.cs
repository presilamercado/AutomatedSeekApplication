using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomatedSeekApplication.Models;
using AutomatedSeekApplication.Core;


namespace AutomatedSeekApplication
{
    public class Seek
    {
        IWebDriver _driver = new ChromeDriver();
        List<string> _jobClassCodes = new List<string>();
        Config _config = new Config();
        public Boolean  SignIn()
        {
            
            Boolean isSigin = true;
            // Navigate to Sign-in
            _driver.Navigate().GoToUrl("https://www.seek.co.nz/sign-in");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement email = _driver.FindElement(By.Id("email"));
            IWebElement password = _driver.FindElement(By.Id("password"));

            email.SendKeys(_config.Email);
            password.SendKeys(_config.Password);
            password.SendKeys(Keys.Enter);

            return isSigin;
            
        }

        public void SignOut()
        {   
            _driver.Close();
            _driver.Quit();
        }

        public List<Job> ListJobs()
        {
            string[] jobClassificationFilter =  new string[0];
            bool somethingSelected = false;

            // explicitly convert filter to lowercase
            // jobClassificationFilter = jobClassificationFilter.Select(s => s.ToLowerInvariant()).ToArray();
            jobClassificationFilter = _config.ClassificationFilters.Select(s => s.ToLowerInvariant()).ToArray();

            List<Job> jobs = new List<Job>();
            IWebElement classificationDropdown = _driver.FindElement(By.XPath(@"//*[@id='SearchBar']/div/div[1]/div/div[2]/label"));
            classificationDropdown.Click();

            IWebElement classificationPanel = _driver.FindElement(By.XPath(@"//*[@id='classificationsPanel']/nav/ul"));
            IList<IWebElement> jobClasses = classificationPanel.FindElements(By.TagName("li"));

            foreach (IWebElement jobClass in jobClasses)
            {
                // get only the classification description ie. "Engineering\r\n1,235"
                string jobClassDesc = jobClass.Text.Split('\r')[0].ToLower();
                if (jobClassificationFilter.Contains(jobClassDesc))
                {
                    IWebElement aTag = jobClass.FindElement(By.TagName("a"));
                    string jobClassCode = aTag.GetAttribute("data-automation");
                    _jobClassCodes.Add(jobClassCode);
                    jobClass.Click();
                    somethingSelected = true;
                }
                
            }

            if (somethingSelected)
            {
                string queryClassification = string.Format("classification={0}", string.Join(",", _jobClassCodes.ToArray())) ;
               _driver.Navigate().GoToUrl(string.Format("https://www.seek.co.nz/jobs?{0}",queryClassification));
            }

            return jobs;
        }

        
    }
}
