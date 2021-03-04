using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecShareSkill.Pages
{
   public class Driver
    {
        //Initialize the browser
        public static IWebDriver driver { get; set; }

        public static void Initialize()
        {
            try
            {
                //Defining the browser
                driver = new ChromeDriver();
                TurnOnWait();

                //Maximise the window
                driver.Manage().Window.Maximize();
          
            }
            catch (TimeoutException e)
            {
                Thread.Sleep(5000);
                Console.WriteLine("Error");
            }
        }

        public static string BaseUrl = "http://localhost:5000/Home";

        //Implicit Wait
        public static void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

        }
        // Navigate to base Url
        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        //Close the browser
        public static void Close()
        {
            driver.Close();
        }

        internal static object FindElement(By by)
        {
            throw new NotImplementedException();
        }
    }

}

