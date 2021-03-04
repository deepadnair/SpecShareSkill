using ImTools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpecShareSkill.Pages
{
   public class ManageListPage
    {
        
        public IWebElement EditLnk => Driver.driver.FindElement(By.XPath("//div[@id='listing-management-section']/div[2]/div/div/table/tbody/tr/td[8]/div/button[2]/i"));
        public IWebElement TagLink => Driver.driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));
        public IWebElement Skltrade => Driver.driver.FindElement(By.XPath("//div[8]//div[2]//div[1]//div[2]//div[1]//input[1]"));
        public IWebElement CrdtValue => Driver.driver.FindElement(By.Name("charge"));
        public IWebElement MngLstLnk => Driver.driver.FindElement(By.LinkText("Manage Listings"));
        public IWebElement Deleicon => Driver.driver.FindElement(By.XPath("//div[@id='listing-management-section']/div[2]/div/div/table/tbody/tr/td[8]/div/button[3]/i"));
        public IWebElement Yeslnk => Driver.driver.FindElement(By.XPath("//div[3]/button[2]"));
        public IWebElement Nolnk => Driver.driver.FindElement(By.XPath("//button[normalize-space()='No']"));
       
        //Select the edit link to update the ShareskillPage
        public void EditIcn()
        {
            Thread.Sleep(5000);
            EditLnk.Click();
        }

        //Enter the tag and Skilltag
        public void TagAdd(string tag)
        {
            Thread.Sleep(2000);
            TagLink.SendKeys(tag);
            TagLink.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            Skltrade.Click();
            CrdtValue.SendKeys("9");
            var valur =  CrdtValue.GetAttribute("Value");
        
            // Verifying the Creditvalue entered is same
            try
            {
                Assert.AreEqual("9",valur);
            }
            catch (Exception e)
            {
                Console.WriteLine("CREDIT VALUE:   CAN ENTER ONLY ONE DIGIT WHICH SHOULD BE RECTIFIED");
            }
        }

        // Select the day by clicking on checkbox 
        public void DaySelect()
        {
            Thread.Sleep(4000);
            IList<IWebElement> Ckbx = Driver.driver.FindElements(By.XPath("(//input[@name='Available'])"));
            
            if (Ckbx.Count != 0)
            {
              //Selecting checkboxes for days from Monday to Friday
               for (int i = 1; i <= Ckbx.Count-2; i++)
               {
             //Verify whether checkbox is not selected
                  if (!Ckbx.ElementAt(i).Selected)
                   { 
                      Ckbx.ElementAt(i).Click();
             //Asserting to check the checkbox for 5 days selected
                      Assert.IsTrue(Ckbx.ElementAt(i).Selected);
                   }
                }
            }
        }
        

        //Enter the starttime and endtime
        public void Wrktime()
        {
           IList<IWebElement> Sttim = Driver.driver.FindElements(By.Name("StartTime"));
           IList<IWebElement> Edtim = Driver.driver.FindElements(By.Name("EndTime"));
            //Validating the Count
             if (Sttim.Count != 0)
             {
              // Looping from index 1 to 5 from Monday to Friday for start and End time
                for (int i = 1; i <= Sttim.Count - 2; i++)
                {
                    Sttim.ElementAt(i).SendKeys("0900");
                    Thread.Sleep(2000);
                    Edtim.ElementAt(i).SendKeys("0530");
                    Thread.Sleep(2000);

              // Verifying the Starttime and EndTime is displayed for 5 days
                    Assert.IsTrue( Sttim.ElementAt(i).Displayed);
                    Assert.IsTrue(Edtim.ElementAt(i).Displayed);
                }
             }
         }
        
        // Click on delete Icon
        public void MngListtab() => MngLstLnk.Click();

        // Deleting the Service Added
        public void DeleteIcon() => Deleicon.Click();

       // Validating Confirmation for No button
        public void NoConfirmation()
        {
            Nolnk.Click();
            Thread.Sleep(5000);
            string currentURL = Driver.driver.Url;
            Assert.AreEqual(currentURL, "http://localhost:5000/Home/ListingManagement");
            
        }
        //Confirmation  for Delete
        public void Confirmation() => Yeslnk.Click();
     }

}
