using SpecShareSkill.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecShareSkill.Hook
{
    [Binding]
    public  class Hooks1 : Driver
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
           //Initializing browser
            Initialize();
            Thread.Sleep(5000);

            //Call the Login Class            
            SpecShareSkill.Pages.Loginpage.LoginStep();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
