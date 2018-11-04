using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AutomatedSeekApplication
{
    class Seek
    {
        IWebDriver _driver = new ChromeDriver();
        public Boolean  SignIn()
        {
            Boolean isSigin = true;
            // Navigate to Sign-in
            _driver.Navigate().GoToUrl("https://www.seek.co.nz/sign-in");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement email = _driver.FindElement(By.Id("email"));
            IWebElement password = _driver.FindElement(By.Id("password"));


            // read from a credentials json file
            JObject credential = new JObject();
            using (StreamReader file = new StreamReader("credentials.json"))
            {
                credential = JObject.Parse(file.ReadToEnd());
                foreach (var item in credential.Properties())
                {
                    if (item.Name == "email")
                    {
                        email.SendKeys(item.Value.ToString());
                    }
                    if (item.Name == "password")
                    {
                        password.SendKeys(item.Value.ToString());
                    }

                }
            }
            password.SendKeys(Keys.Enter);

            return isSigin;
            
        }

        public void SignOut()
        {   
            _driver.Close();
            _driver.Quit();
        }
    }
}
