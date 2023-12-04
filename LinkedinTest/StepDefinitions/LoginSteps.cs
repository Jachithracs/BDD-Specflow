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
        public static IWebDriver? driver;
        private IWebElement? passwordInput;


        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }
        [BeforeScenario]
        public static void LoadURL()
        {
            driver.Url = "https://www.linkedin.com";
        }
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://www.linkedin.com";
        }

        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }

        [When(@"User will enter username '(.*)'")]
        public void WhenUserWillEnterUsername(string un)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            emailInput.SendKeys(un);
        }

        [When(@"User will enter password '(.*)'")]
        public void WhenUserWillEnterPassword(string pwd)
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            passwordInput.SendKeys(pwd);
        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true);", driver?.FindElement(By.XPath("//button[@type='submit']")));

            Thread.Sleep(5000);
            js?.ExecuteScript("arguments[0].click();", driver?.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will be redirected to home page")]
        public void ThenUserWillBeRedirectedToHomePage()
        {
            Assert.That(driver.Title.Contains("Log In"));
        }

        [Then(@"Error message for password length should be thrown")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {
            IWebElement? alertPara = driver?.FindElement(By.XPath("//p[@for='session_password']"));
            string? alertText = alertPara?.Text;
            Console.WriteLine(alertText);
            Assert.That(alertText.Contains("password"));
        }

        [When(@"User will click on show button in the password text box")]
        public void WhenUserWillClickOnShowButtonInThePasswordTextBox()
        {
            IWebElement showButton = driver.FindElement(By.XPath("//button[text()='Show']"));
            showButton.Click();
        }

        [Then(@"The password characters should be shown")]
        public void ThenThePasswordCharactersShouldBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("text"));
        }

        [When(@"User will click on hide button in the password text box")]
        public void WhenUserWillClickOnHideButtonInThePasswordTextBox()
        {
            IWebElement hideButton = driver.FindElement(By.XPath("//button[text()='Hide']"));
            hideButton.Click();
        }

        [Then(@"The password characters should not be shown")]
        public void ThenThePasswordCharactersShouldNotBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("password"));
        }


    }
}
