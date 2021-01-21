using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace QA_MARSOnboarding.PageObjectModel
{
    public class ProfilePage
    {
        IWebDriver driver;

        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Navigate to Profile page
        public void goToProfile()
        {
            var homePageDropdown = driver.FindElement(By.CssSelector("span[class='item ui dropdown link ']"));
            Actions action = new Actions(driver);
            action.MoveToElement(homePageDropdown).Perform();

            
            var goToProfile = new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(
            ExpectedConditions.ElementToBeClickable(By.XPath(("//*[contains(text(),'Go to Profile')]"))));

            
            goToProfile.Click();

        }

        //Verify the Profile Page got opened
        public string verifyProfilePage()
        {
            //var profileName = new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(
            //ExpectedConditions.ElementIsVisible(By.CssSelector(("div[class='title']"))));

            Thread.Sleep(2000);
            var profileName = new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(
            ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@class,'content')] //*[contains(@class,'accordion')] //*[contains(@class,'title')]")));

            string profileNameText = profileName.Text;
            Console.WriteLine(profileNameText);
            if (!String.IsNullOrEmpty(profileNameText))
            {
                return profileNameText;
            }
            return "nothing";
        }

        //Editing the Description
        public void editProfileDescription(string text)
        {
            var editIcon = new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(
            ExpectedConditions.ElementToBeClickable(By.CssSelector("span[class='button'] i")));

            editIcon.Click();

            var descriptionDetails = driver.FindElement(By.CssSelector("textarea[name='value']"));
            descriptionDetails.SendKeys(text);
        }

        //Save the Description
        public void saveProfileDescription()
        {
            var saveDescription = driver.FindElement(By.CssSelector("button[class='ui teal button'][type='button']"));
            saveDescription.Click();
        }

        //Verify the added description got displayed
        public string verifyProfileDescription()
        {

            var descriptionDetails = new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(
            ExpectedConditions.ElementToBeClickable(By.CssSelector(("span[style='padding-top: 1em;']")))).Text;
            return descriptionDetails;

        }

        //Navigate to Skill 
        public void selectSkillNavBar()
        {
            var selectSkillNavBar = driver.FindElement(By.CssSelector("a[class='item'][data-tab='second']"));
            selectSkillNavBar.Click();
        }

        //Edit Skill
        public void editProfileSkill(string skill, string level)
        {
            var addNewSkill = driver.FindElement(By.CssSelector("div[class='ui bottom attached tab segment tooltip-target active'][data-tab='second'] [class='ui teal button']"));
            addNewSkill.Click();

            var typeNewSkill = driver.FindElement(By.CssSelector("input[type='text'][placeholder='Add Skill']"));
            typeNewSkill.SendKeys(skill);

            var skillLevel = driver.FindElement(By.XPath("//*[contains(text(),'Choose Skill Level')]"));
            skillLevel.Click();

            //var selectedSkillLevel = driver.FindElement(By.XPath("//*[contains(text(),'Expert')]"));
            var selectedSkillLevel = driver.FindElement(By.XPath("//*[contains(text(),'" + level + "')]"));
            selectedSkillLevel.Click();

            var addTheEnteredSkill = driver.FindElement(By.CssSelector("input[type='button'][class='ui teal button '][value='Add']"));
            addTheEnteredSkill.Click();
        }

        //Verify whether the added skills got displayed
        public Skills verifyAddedSkillDetails ()
        {
            Skills skills = new Skills();

            Thread.Sleep(2000);

            var theEnteredSkilltype = new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(
            ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@class, 'bottom') and contains(@class, 'active')] //*[contains(@class, 'table')] //tbody[last()]//tr //td[1]")));
            string theNameOfEnteredSkilltype = theEnteredSkilltype.Text;
            //var theEnteredSkilltype = driver.FindElement(By.XPath("//*[contains(@class, 'bottom') and contains(@class, 'active')] //*[contains(@class, 'table')] //tbody[last()]//tr //td[1]")).Text;
            skills.EnteredSkilltype = theNameOfEnteredSkilltype;

            Thread.Sleep(2000);

            var theSelectedSkillLevel = new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(
            ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@class, 'bottom') and contains(@class, 'active')] //*[contains(@class, 'table')] //tbody[last()]//tr //td[2]")));
            string theNameOfSelectedSkillLevel = theSelectedSkillLevel.Text;
            //var theSelectedSkillLevel = driver.FindElement(By.XPath("//*[contains(@class, 'bottom') and contains(@class, 'active')] //*[contains(@class, 'table')] //tbody[last()]//tr //td[2]")).Text;
            skills.SelectedSkillLevel = theNameOfSelectedSkillLevel;

            return skills;
        }

        //Update the selected Skill
        public void updateProfileSkill(string p0,string p1)
        {
           
            var clickUpdateIcon = driver.FindElement(By.XPath("//*[contains(@class, 'bottom') and contains(@class, 'active')] //*[contains(@class, 'table')] //tbody //td[contains(text(),'" + p0 + "')] //parent::* //td[3] //*[contains(@class, 'write')]"));
            clickUpdateIcon.Click();
            IWebElement updateSkillType = driver.FindElement(By.CssSelector("input[type='text'][name='name'][placeholder='Add Skill'][value='" + p0 + "']"));
            updateSkillType.Clear();
            updateSkillType.SendKeys(p1);
            var clickUpdateButton = driver.FindElement(By.CssSelector("input[type='button'][class='ui teal button'][value='Update']"));
            clickUpdateButton.Click();
            //IReadOnlyCollection<IWebElement> tbodyList = driver.FindElements(By.XPath("//*[contains(@class, 'bottom') and contains(@class, 'active')] //*[contains(@class, 'table')] //tbody"));
            //for (int i = 0; i < tbodyList.Count; i++)
            //{
            //    IWebElement skillTypeInTable = tbodyList.ElementAt(i);
            //    string updateRequireSkill = skillTypeInTable.FindElement(By.XPath("//td[1]")).Text;
            //    if (updateRequireSkill == p0)
            //    {
            //        IWebElement updateIcon = skillTypeInTable.FindElement(By.XPath("//td[3] //*[contains(@class, 'write')]"));
            //        updateIcon.Click();
            //        IWebElement updateSkillType = driver.FindElement(By.CssSelector("input[type='text'][name='name'][placeholder='Add Skill'][value='"+ p0 +"']"));
            //        updateSkillType.SendKeys(p1);
            //        break;
            //    }
            //}

        }

        //Verify whether the updated skill got displayed
        public string verifyUpdatedProfileSkill(string p0)
        {
            
            var updatedSkill = driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'bottom')] //*[contains(@class,'fixed')] //*[contains(text(),'"+p0+"')]")).Text;
          
            return updatedSkill;
        }

        //Delete the selected Skill
            public string deleteProfileSkill(string p0)
        {
            
            var clickDeleteIcon = driver.FindElement(By.XPath("//*[contains(@class, 'bottom') and contains(@class, 'active')] //*[contains(@class, 'table')] //tbody //td[contains(text(),'" + p0 + "')] //parent::* //td[3] //*[contains(@class, 'remove')]"));
            clickDeleteIcon.Click();
           
            return "skillType1";

        }

        //Verify whether the selected skill got deleted
        public bool verifySelectedSkillGotDeleted(string p0)
        {
            Thread.Sleep(10000);
            //driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(60));
            IReadOnlyCollection <IWebElement> tbodyList = driver.FindElements(By.XPath("//*[contains(@class, 'bottom') and contains(@class, 'active')] //*[contains(@class, 'table')] //tbody"));
            Thread.Sleep(2000);
            bool isSkillDeleted = false;
            if (tbodyList.Count == 0)
            {
                isSkillDeleted = true;
                return isSkillDeleted;
            };
            
            return isSkillDeleted;
        }

        //Select availability type
        public void selectAvailability(string p0)
        {
            //Thread.Sleep(10000);
            var changeAvailability = driver.FindElement(By.XPath("//*[contains(text(),'Part Time')] //*[contains(@class, 'write')]"));
            changeAvailability.Click();

            var clickDropdown = driver.FindElement(By.CssSelector("select[class='ui right labeled dropdown'][name='availabiltyType']"));
            clickDropdown.Click();

            var selectAvailabilityFromDropdown = driver.FindElement(By.XPath("//*[contains(text(),'"+p0+"')]"));
            selectAvailabilityFromDropdown.Click();
        }

        //select availability hours
        public void selectHours(string p0)
        {
            By changeHours = By.XPath("//*[contains(text(),'Less than 30hours a week')] //*[contains(@class, 'write')]");
            IReadOnlyCollection<IWebElement> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(changeHours));
            driver.FindElement(changeHours).Click();

            var clickDropdown = driver.FindElement(By.CssSelector("select[class='ui right labeled dropdown'][name='availabiltyHour']"));
            clickDropdown.Click();

            var selectAvailabilityHourFromDropdown = driver.FindElement(By.XPath("//*[contains(text(),'" + p0 + "')]"));
            selectAvailabilityHourFromDropdown.Click();
        }

        //verify whether the selected availability got displayed
        public Availability verifyAvailabilityAndHour (string p0, string p1)
        {
            Availability availability = new Availability();
            string getAvailability = driver.FindElement(By.XPath("//*[contains(text(),'"+p0+"')]")).Text;
            availability.Type = getAvailability;

            string getHour = driver.FindElement(By.XPath("//*[contains(text(),'" + p0 + "')]")).Text;
            availability.Hour = getHour;

            return availability;
        }
    }
}
