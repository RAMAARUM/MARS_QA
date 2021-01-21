Feature: MARSFeatureFile


@mytag
Scenario:  Verify seller is able to Login to portal

Given I navigate to skill exchange Portal
When I add username "priya24rama@gmail.com" and password "AruPriya@29" to the inputfield and press submit
Then I am able to navigate to skill exchange portal of user's login "Hi Ramapriya"

When I select Profile option 
Then I am able to see Profile page of "Ramapriya Arumugam"

When I enter "I am an IT Analyst." to the textbox after clicking Edit icon
And When I save the description
Then I verify that the"I am an IT Analyst." description is displayed in textbox

When I navigate to skill table
And I click Add New button of Skill and add skill type "Cobol" and choose level "Expert" from dropdown
Then the added skill details "Cobol", "Expert" got displayed in skill field.

When I click update button for skillType and update the skillType "Cobol" to "C#"
Then I verify that selected skillType "C#" got updated 

When I click delete button for skillType "C#" 
Then I verify that selected skillType "C#" got deleted

When I click edit icon and change Availability to "Full Time"
And I click edit icon and change Hours to "More than 30hours a week"
Then I see the option "Full Time" for Availability and "More than 30hours a week" for Hours
