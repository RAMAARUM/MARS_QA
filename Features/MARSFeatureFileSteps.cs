using System;
using TechTalk.SpecFlow;

namespace QA_MARSOnboarding.Features
{
    [Binding]
    public class MARSFeatureFileSteps
    {
        [When(@"I click update button for skillType(.*) and update skillType(.*)")]
        public void WhenIClickUpdateButtonForSkillTypeAndUpdateSkillType(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I verify that skillType(.*) got updated to skillType(.*)")]
        public void ThenIVerifyThatSkillTypeGotUpdatedToSkillType(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
