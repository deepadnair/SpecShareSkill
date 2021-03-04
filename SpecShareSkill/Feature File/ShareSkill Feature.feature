Feature: ShareSkill Feature
	Adding Data to Share Skill feature and Manage Listings


Scenario: 1 Adding datas On ShareSkill Page
Given I Navigate to ShareSkill Page from Profile Page
And I  add Title 'Selenium' 
And I add Description 
And I add Category and sub category
And I add tags and Skilltags
| Tag     | SkillExchangeTag |
| Testing | Performance       |
And I add StartDate and EndDate
Then Save the Added datas

 Scenario: 2 Updating Using ManageListing Page
 Given I have navigated to Manage listing Page
 And I click on edit Icon navigating to ShareSkill Page
 And I add one more tag 'Automation' and Change Skilltrade
 And I Select checkboxes for available days
 And I update StartTime and EndTime
 Then Save the updated data.

 Scenario: 3 Delete the Service In Manage listing page
 Given I am on manage listing page 
 And I try deleting service from Manage Listing Page
 And I should get a confirmation yes or no and i click NO
 Then I click yes the service should be deleted
 
