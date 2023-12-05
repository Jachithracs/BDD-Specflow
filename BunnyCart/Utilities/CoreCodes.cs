using BunnyCart.Hooks;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.Utilities
{
    public class CoreCodes
    {
        //IWebDriver? driver = BeforeHooks.driver;
        public void TakeScreenShot(IWebDriver driver)
        {

            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot ss = screenshot.GetScreenshot();
            string currdir = Directory.GetParent(@"../../../").FullName;
            string filepath = currdir + "/ScreenShot/scs_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            ss.SaveAsFile(filepath);

        }
        protected void LogTestResult(string testName,string result,string errorMessage=null)
        {
            Log.Information(result);

            if(errorMessage == null)
            {
                Log.Information(testName + " Passed");
            }
            else
            {
                Log.Error($"Test failed for {testName}." 
                    + $"\n Exception:\n {errorMessage}");
            }
        }
    }
}
