Feature: Booking

@api
Scenario: 01 Create a new booking with valid data
	Given Request body is prepared with valid data
	When Request is sent to CREATE a booking
	Then Response should be 200 and OK
@api
Scenario: 02 Create a new booking with incomplete data
	Given Request body is prepared with invalid data
	When Request is sent to CREATE a booking
	Then Response should be 500 and InternalServerError

@api
Scenario: 03 Create a new booking without header
	Given Request body is prepared with valid data
	When Request is sent to CREATE a booking without header
	Then Response should be 418 and 418

@api
Scenario: 04 Get existing booking
	Given Request body is prepared with valid data
	When Request is sent to GET a booking
	Then Response should be 200 and OK
	And Response data corresponds with Created data

@api
Scenario: 05 Get non-existing booking
	When Request is sent to GET a booking with id 000
	Then Response should be 404 and NotFound

@api
Scenario: 06 Update existing booking
	Given Request is sent to GET a token
	And Request body is prepared with valid data
	When Request is sent to UPDATE a booking
	Then Response should be 200 and OK
	And Response data corresponds with Updated data

@api
Scenario: 07 Delete existing booking without token
	Given Request is sent to DELETE a booking
	Then Response should be 403 and Forbidden

@api
Scenario: 08 Delete existing booking
	Given Request is sent to GET a token
	When Request is sent to DELETE a booking
	Then Response should be 201 and Created
	And Response for checking deleted booking should be 404 and Not Found



