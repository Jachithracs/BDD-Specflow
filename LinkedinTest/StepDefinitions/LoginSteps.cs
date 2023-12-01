using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkedinTest.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver? driver;

        private IWebElement? passwordInput;
        /*
        [BeforeScenario]
        public void InitializeBrowser()
        {
            
        }
        [AfterScenario]
        public void CleanupBrowser()
        {
            driver?.Quit();
        }
        */

        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver = new ChromeDriver();
            driver.Url = "https://linkedin.com";
        }

        [When(@"User will enter username")]
        public void WhenUserWillEnterUsername()
        {
            
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            emailInput.SendKeys("abc@xyz.com");
            
        }

        [When(@"User will enter password")]
        public void WhenUserWillEnterPassword()
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Elemet Not Found";
            passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));
            passwordInput.SendKeys("12345");
            Console.WriteLine(passwordInput.GetAttribute("value"));
        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver?.FindElement(
                By.XPath("//button[@type='submit']")));
            Thread.Sleep(5000);

            js.ExecuteScript("arguments[0].click();", driver?.FindElement(
                By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will be redirected to Homepage")]
        public void ThenUserWillBeRedirectedToHomepage()
        {
            Assert.That(driver.Title.Contains("Log In"));
        }
        [Then(@"Error message for Password Length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {
            IWebElement alertPara = driver.FindElement(By.XPath("//p[@for='session_password']"));
            string? alerttext = alertPara?.Text;
            Assert.That(alerttext.Equals("The password you provided must have at least 6 characters"));
        }

        [When(@"User will click on Show link in the password textbox")]
        public void WhenUserWillClickOnShowLinkInThePasswordTextbox()
        {
            IWebElement showButton = driver.FindElement(By.XPath("//button[text()='Show']"));
            showButton.Click();
        }

        [Then(@"the password characters should be shown")]
        public void ThenThePasswordCharactersShouldBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("text"));
        }

        [When(@"User will click on Hide link in the password textbox")]
        public void WhenUserWillClickOnHideLinkInThePasswordTextbox()
        {
            IWebElement hideButton = driver.FindElement(By.XPath("//button[text()='Hide']"));
            hideButton.Click();
        }

        [Then(@"the password characters should not be shown")]
        public void ThenThePasswordCharactersShouldNotBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("password"));
        }

    }
}
