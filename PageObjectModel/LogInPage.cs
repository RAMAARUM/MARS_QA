using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QA_MARSOnboarding.PageObjectModel
{
    public class LogInPage
    {
        IWebDriver driver;
        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Navigate to Skill Exchange Portal
        public void navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        //Adding Credentials to Login
        public void addCred(string userName, string Password)
        {
            var signIn = driver.FindElement(By.XPath(("//*[contains(text(),'Sign In')]")));
            signIn.Click();

            var username = driver.FindElement(By.CssSelector("input[type='text'][placeholder='Email address']")) ;
            username.SendKeys(userName);

            var password = driver.FindElement(By.CssSelector("input[type='password'][placeholder='Password']"));
            password.SendKeys(Password);

            var logIn = driver.FindElement(By.CssSelector("button[class='fluid ui teal button']"));
            logIn.Click();
        }

        //Opening Home Page and verifying that
        public string homePg()
        {
            //var isSellerPresent = new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(
            //ExpectedConditions.ElementIsVisible(By.CssSelector("span[class='item ui dropdown link ']"))).Text;
            Thread.Sleep(2000);
            var isSellerPresent = new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(
            ExpectedConditions.ElementIsVisible(By.XPath("//*[span] //*[contains(@class,'dropdown') and contains(@class,'link')]"))).Text;

            if (isSellerPresent == "Hi Ramapriya")
            {
                return isSellerPresent;
            }
            return string.Empty;

        }


    }
}
