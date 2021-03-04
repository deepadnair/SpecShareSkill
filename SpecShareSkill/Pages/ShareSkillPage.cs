using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Utf8Json.Formatters;

namespace SpecShareSkill.Pages
{
   public class ShareSkillPage
    {
        public IWebElement ShSkLink => Driver.driver.FindElement(By.XPath(" //a[normalize-space()='Share Skill']"));
        public IWebElement Title => Driver.driver.FindElement(By.Name("title"));
        public IWebElement Description => Driver.driver.FindElement(By.Name("description"));
        public IWebElement Tags => Driver.driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));
        public IWebElement StartDateLnk => Driver.driver.FindElement(By.Name("startDate"));
        public IWebElement EndDateLnk => Driver.driver.FindElement(By.Name("endDate"));
        public IWebElement SkillTags => Driver.driver.FindElement(By.XPath("//div[contains(@class,'twelve wide column')]//div[contains(@class,'')]//div[contains(@class,'form-wrapper')]//input[contains(@placeholder,'Add new tag')]"));
        public IWebElement SaveLnk => Driver.driver.FindElement(By.CssSelector("input[value = 'Save']"));
                
        public void ShSkBtn()
        {
            Thread.Sleep(3000);
            ShSkLink.Click();
        }

        //Adding Title and Verifying the title 
         public void AddTitle(string title)
        {
            Title.SendKeys(title);
            Assert.AreEqual(title, "Selenium");
            Driver.TurnOnWait();
        }

        //Adding Description and Verifying Descrition
        public void AddDesc()
        {
            Description.SendKeys("Would like to provide Selenium Training to beginners");
            Debug.Assert(Description.Text.Equals("Would like to provide Selenium Training to beginners"));
         }

        //Selecting Skill Category and SubCategory
        public void SkillCategory()
        {
            Thread.Sleep(3000);
            var Categoryy = Driver.driver.FindElement(By.Name("categoryId"));
            var selectelm = new SelectElement(Categoryy);
            selectelm.SelectByValue("6");
            var selectedValue = selectelm.SelectedOption.GetAttribute("Value");
            Assert.AreEqual("6", selectedValue);
                        
            Thread.Sleep(5000);
            var SubCategoryy = Driver.driver.FindElement(By.Name("subcategoryId"));
            var selectSub = new SelectElement(SubCategoryy);
            selectSub.SelectByText("QA");
            var selectedTxt = selectSub.SelectedOption.Text;
            Assert.AreEqual("QA", selectedTxt);
        }

       // Entering Tag and SkillExchangeTag
         public void Skilltags(string Tag, string SkillExchangeTag)
         {
            Tags.SendKeys(Tag);
            Tags.SendKeys(Keys.Enter);
            String Expectedtxt1 = "Testing";
            Assert.AreEqual(Expectedtxt1, Tag);
            Thread.Sleep(5000);

            SkillTags.SendKeys(SkillExchangeTag);
            SkillTags.SendKeys(Keys.Enter);
            String Expectedtxt2 = "Performance";
            Assert.AreEqual(Expectedtxt2, SkillExchangeTag);
            Thread.Sleep(5000);
         }

        //Entering the Start and End Dates
        public void StartEndDates()
        {
            string Stdate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy");
            Console.WriteLine(Stdate);
            StartDateLnk.SendKeys(Stdate);
            Thread.Sleep(5000);
            string enddate = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");
            Console.WriteLine(enddate);
            EndDateLnk.SendKeys(enddate);
            Thread.Sleep(5000);
        }
        //Saving the Entered Data
        public void SaveBtn() => SaveLnk.Click();

    }
}
