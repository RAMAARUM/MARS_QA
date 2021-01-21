using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_MARSOnboarding.PageObjectModel;
using System;
using TechTalk.SpecFlow;

namespace QA_MARSOnboarding.Features
{
    [Binding]
    public class MARSSteps
    {
        IWebDriver driver;
        LogInPage login;
        ProfilePage profile;
        string skill;
        private readonly ScenarioContext context;

        [BeforeScenario]
        public void Setup()
        {
            
        }
        

        public MARSSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        //[TearDown]
        //public void closeBrowser()
        //{
        //    driver.Close();
        //}

       
        [Given(@"I navigate to skill exchange Portal")]
        public void GivenINavigateToSkillExchangePortal()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            login = new LogInPage(driver);
            profile = new ProfilePage(driver);
            skill = "skillType" + new Random().Next(0, 9);
            driver.Url = "http://192.168.1.69:5000/Home";
        }

        [When(@"I add username ""(.*)"" and password ""(.*)"" to the inputfield and press submit")]
        public void WhenIAddUsernameAndPasswordToTheInputfieldAndPressSubmit(string p0, string p1)
        {
            //Add credentials to Login the Skill Exchange Portal
            login.addCred(p0, p1);
        }

        [Then(@"I am able to navigate to skill exchange portal of user's login ""(.*)""")]
        public void ThenIAmAbleToNavigateToSkillExchangePortalOfUserSLogin(string p0)
        {
            //Check whether the Home page is loaded
            var user = login.homePg();
            Assert.AreEqual(p0, user);
        }

        [When(@"I select Profile option")]
        public void WhenISelectProfileOption()
        {
            //Go to Profilepage
            profile.goToProfile();
        }

        [Then(@"I am able to see Profile page of ""(.*)""")]
        public void ThenIAmAbleToSeeProfilePageOf(string p0)
        {
            //check whether the Profile page is displayed
            string profileName = profile.verifyProfilePage();
            Assert.AreEqual(p0, profileName);
        }

        [When(@"I enter ""(.*)"" to the textbox after clicking Edit icon")]
        public void WhenIEnterToTheTextboxAfterClickingEditIcon(string p0)
        {
            //Select edit icon of profile description and edit the details
            profile.editProfileDescription(p0);
        }

        [When(@"When I save the description")]
        public void WhenWhenISaveTheDescription()
        {
            //Save the added profile description
            profile.saveProfileDescription();
        }

        [Then(@"I verify that the""(.*)"" description is displayed in textbox")]
        public void ThenIVerifyThatTheDescriptionIsDisplayedInTextbox(string p0)
        {
            //Check whether the description is displayed 
            var descriptionDetail = profile.verifyProfileDescription();
            Assert.That(descriptionDetail, Does.Contain(p0).IgnoreCase);
        }

        [When(@"I navigate to skill table")]
        public void WhenINavigateToSkillTable()
        {
            //Navigate the SKill table
            profile.selectSkillNavBar();
        }

        [When(@"I click Add New button of Skill and add skill type ""(.*)"" and choose level ""(.*)"" from dropdown")]
        public void WhenIClickAddNewButtonOfSkillAndAddSkillTypeAndChooseLevelFromDropdown(string p0, string p1)
        {
            //Click Add New button of Skill and add skill details
            profile.editProfileSkill(p0, p1);
        }

        [Then(@"the added skill details ""(.*)"", ""(.*)"" got displayed in skill field\.")]
        public void ThenTheAddedSkillDetailsGotDisplayedInSkillField_(string p0, string p1)
        {
            //Check whether the added skill details got displayed
            var theAddedSkillDetails = profile.verifyAddedSkillDetails();
            Assert.AreEqual(p0, theAddedSkillDetails.EnteredSkilltype);
            Assert.AreEqual(p1, theAddedSkillDetails.SelectedSkillLevel);
        }

        [When(@"I click update button for skillType and update the skillType ""(.*)"" to ""(.*)""")]
        public void WhenIClickUpdateButtonForSkillTypeAndUpdateTheSkillTypeTo(string p0, string p1)
        {
            //Update the selected skill
            profile.updateProfileSkill(p0, p1);
        }

        [Then(@"I verify that selected skillType ""(.*)"" got updated")]
        public void ThenIVerifyThatSelectedSkillTypeGotUpdated(string p0)
        {
            //Check whether the selected skill got updated
            var updatedSkillType = profile.verifyAddedSkillDetails();
            Assert.AreEqual(p0, updatedSkillType.EnteredSkilltype);
        }

        [When(@"I click delete button for skillType ""(.*)""")]
        public void WhenIClickDeleteButtonForSkillType(string p0)
        {
            //Delete the selected skill
            profile.deleteProfileSkill(p0);
        }

        [Then(@"I verify that selected skillType ""(.*)"" got deleted")]
        public void ThenIVerifyThatSelectedSkillTypeGotDeleted(string p0)
        {
            //Check whether the selected skill got deleted
            var selectedSkillDeleted = profile.verifySelectedSkillGotDeleted(p0);
            Assert.IsTrue(selectedSkillDeleted);
        }

        [When(@"I click edit icon and change Availability to ""(.*)""")]
        public void WhenIClickEditIconAndChangeAvailabilityTo(string p0)
        {
            //Select availabile Type
            profile.selectAvailability(p0);
        }

        [When(@"I click edit icon and change Hours to ""(.*)""")]
        public void WhenIClickEditIconAndChangeHoursTo(string p0)
        {
            //Select availabile Hour
            profile.selectHours(p0);
        }

        [Then(@"I see the option ""(.*)"" for Availability and ""(.*)"" for Hours")]
        public void ThenISeeTheOptionForAvailabilityAndForHours(string p0, string p1)
        {
            //verifies availability Type and Hour
            var availability = profile.verifyAvailabilityAndHour(p0,p1);
            Assert.AreEqual(p0, availability.Type);
            Assert.AreEqual(p0, availability.Hour);
        }

        [AfterScenario]

        public void CloseDriver()
        {
            //closes chrome driver
            driver.Close();

            //Frees up the memory of chrome
            driver.Dispose();
        }

    }
}
