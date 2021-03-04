using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecShareSkill.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecShareSkill.Specflow_Steps
{
    [Binding]
    public class ShareSkillSteps
    {

        
        readonly ShareSkillPage sskillpage = new ShareSkillPage();
        readonly ManageListPage managelist = new ManageListPage();

       
       
        [Given(@"I Navigate to ShareSkill Page from Profile Page")]
        public void GivenINavigateToShareSkillPageFromProfilePage()
        {
            sskillpage.ShSkLink.Click();
        }

        [Given(@"I  add Title '(.*)'")]
        public void GivenIAddTitle(string title)
        {
            sskillpage.AddTitle(title);
            
        }

        [Given(@"I add Description")]
        public void GivenIAddDescription()
        {
            sskillpage.AddDesc();
        }

        [Given(@"I add Category and sub category")]
        public void GivenIAddCategoryAndSubCategory()
        {
            sskillpage.SkillCategory();
        }

        [Given(@"I add tags and Skilltags")]
        public void GivenIAddTagsAndSkilltags(Table table)
        {
            
         dynamic data = table.CreateDynamicInstance();
           sskillpage.Skilltags((string)data.Tag, (string)data.SkillExchangeTag);
        }

        [Given(@"I add StartDate and EndDate")]
        public void GivenIAddStartDateAndEndDate()
        {
            sskillpage.StartEndDates();
        
        }
        [Then(@"Save the Added datas")]
        public void ThenSaveTheAddedDatas()
        {
            sskillpage.SaveBtn();
        }

        [Given(@"I have navigated to Manage listing Page")]
        public void GivenIHaveNavigatedToManageListingPage()
        {
            managelist.MngListtab();
            Thread.Sleep(3000);
            String currentURL = Driver.driver.Url;
            Assert.AreEqual(currentURL, "http://localhost:5000/Home/ListingManagement");

        }

        [Given(@"I click on edit Icon navigating to ShareSkill Page")]
        public void GivenIClickOnEditIconNavigatingToShareSkillPage()
        {
            managelist.EditIcn();
        }
        [Given(@"I add one more tag '(.*)' and Change Skilltrade")]
        public void GivenIAddOneMoreTagAndChangeSkilltrade(string tag)
        {
            managelist.TagAdd(tag);
        }   

        [Given(@"to update available days I select monday")]
        public void GivenToUpdateAvailableDaysISelectMonday()
        {
            managelist.DaySelect();
        }
        [Given(@"I update StartTime and EndTime")]
        public void GivenIUpdateStartTimeAndEndTime()
        {
            managelist.Wrktime();
        }

        [Then(@"Save the updated data\.")]
        public void ThenSaveTheUpdatedData_()
        {
            sskillpage.SaveBtn();
            
         //   Thread.Sleep(8000);
         //   webDriver.Quit();
        }

        [Given(@"I am on manage listing page")]
        public void GivenIAmOnManageListingPage()
        {
            managelist.MngListtab();
        }

        [Given(@"I try deleting service from Manage Listing Page")]
        public void GivenITryDeletingServiceFromManageListingPage()
        {
            managelist.DeleteIcon();
        }

              
        [Given(@"I should get a confirmation yes or no and i click NO")]
        public void GivenIShouldGetAConfirmationYesOrNoAndIClickNO()
        {
            managelist.NoConfirmation();
        }

        [Then(@"I click yes the service should be deleted")]
        public void ThenIClickYesTheServiceShouldBeDeleted()
        {
            //Console.WriteLine("Alert");
            managelist.DeleteIcon();
            Thread.Sleep(3000);
            managelist.Confirmation();
        }

        
    }
}
