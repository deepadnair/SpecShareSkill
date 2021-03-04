using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SpecShareSkill.Pages
{
    public class Loginpage 
    {
        
        public static void LoginStep()
        {
            Driver.NavigateUrl();
            Thread.Sleep(1000);

            Driver.driver.FindElement(By.XPath("//a[contains(.,'Sign In')]")).Click();
            //Enter Username
            Driver.driver.FindElement(By.XPath("//input[@name='email']")).SendKeys("deepa.nair.d@gmail.com");
            //Enter password
            Driver.driver.FindElement(By.XPath("//input[contains(@name,'password')]")).SendKeys("Industry15Connect");
            Thread.Sleep(1000);

            //Click on Login Button
            Driver.driver.FindElement(By.XPath("//button[contains(.,'Login')]")).Click();
            Thread.Sleep(5000);

            //Validate if user logged in or not
             IWebElement loggedin = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
             Assert.AreEqual(loggedin.Text,"Hi Deepa");
        }


    }
}

