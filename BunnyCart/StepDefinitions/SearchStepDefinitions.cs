using BunnyCart.Hooks;
using BunnyCart.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
   
    [Binding]
    public class SearchStepDefinitions : CoreCodes
    {
        IWebDriver? driver = BeforeHooks.driver;
       
        [Given(@"User will be on the Homepage")]
        public void GivenUserWillBeOnTheHomepage()
        {
            driver.Url = "https://www.bunnycart.com";
            driver.Manage().Window.Maximize();
        }
        
       
        [When(@"User will type the '([^']*)' in the searchbox")]
        public void WhenUserWillTypeTheInTheSearchbox(string searchtext)
        {
            IWebElement? searchInput = driver.FindElement(By.Id("search"));
            searchInput?.SendKeys(searchtext);
            Log.Information("Typed search text " + searchtext);
            searchInput?.SendKeys(Keys.Enter);
        }

        [When(@"User clicks on search button")]
        public void WhenUserClicksOnSearchButton()
        {
            IWebElement? searchButton = driver.FindElement(By.XPath("//button[span[text()='Search']]"));
            searchButton.Click();
        }

        [Then(@"Search results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            TakeScreenShot(driver);
            Log.Information("Screenshot taken");
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
        }
    }
}
