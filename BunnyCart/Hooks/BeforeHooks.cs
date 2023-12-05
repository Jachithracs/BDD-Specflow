using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.Hooks
{
    [Binding]
    public sealed class BeforeHooks
    {
        public static IWebDriver? driver;

        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();

        }
        [BeforeFeature]
        public static void LogFileCreation()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/SearchFeature_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            driver?.Navigate().GoToUrl("https://www.bunnycart.com/");
        }
        [AfterFeature]
        public static void CleanupBrowser()
        {
            driver?.Quit();
        }
    }
}
