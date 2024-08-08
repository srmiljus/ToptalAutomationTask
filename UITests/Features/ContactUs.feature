Feature: Contact Us

@smoke
Scenario: 01 User send a meesage with valid file
	Given User opened the home page
	When User click on Contact us header menu button
	Then User can see title CUSTOMER SERVICE - CONTACT US
	When User choose Webmaster from Subject Heading
	And User enter valid details for the form 
	And User attach valid file 
	And User send message
	Then User verify success message Your message has been successfully sent to our team.
		
@smoke
Scenario: 02 User send a meesage with invalid file
	Given User opened the home page
	When User click on Contact us header menu button
	Then User can see title CUSTOMER SERVICE - CONTACT US
	When User choose Customer service from Subject Heading
	And User enter valid details for the form 
	And User attach invalid file
	And User send message
	Then User verify alert message There is 1 error
	And User verify reason for error Bad file extension

@smoke
Scenario: 03 User send a meesage with invalid mail
	Given User opened the home page
	When User click on Contact us header menu button
	Then User can see title CUSTOMER SERVICE - CONTACT US
	When User choose Customer service from Subject Heading
	And User enter invalid email details for the form 
	And User send message
	Then User verify alert message There is 1 error
	And User verify reason for error Invalid email address.

@smoke
Scenario: 04 User send a meesage without sbuject heading
	Given User opened the home page
	When User click on Contact us header menu button
	Then User can see title CUSTOMER SERVICE - CONTACT US
	When User enter valid details for the form 
	And User attach valid file
	And User send message
	Then User verify alert message There is 1 error
	And User verify reason for error Please select a subject from the list provided.

@smoke
Scenario: 05 User send a meesage without entering Message text
	Given User opened the home page
	When User click on Contact us header menu button
	Then User can see title CUSTOMER SERVICE - CONTACT US
	When User enter valid details without message
	And User attach valid file
	And User send message
	Then User verify alert message There is 1 error
	And User verify reason for error The message cannot be blank.

