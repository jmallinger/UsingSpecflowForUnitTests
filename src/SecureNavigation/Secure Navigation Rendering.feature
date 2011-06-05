Feature: Secure navigation rendering

	In order to prevent a user from accessing a feature they are not meant to access
	The system will need to restrict features the user is able to navigate to


Background:
	Given a feature-to-privilege mapping of:
		| Permission     | Module    | DisplayName | GroupName          | Section     |
		| AccessFeature1 | FrontDesk | Feature 1   | Front Desk Apps    | Application |
		| AccessFeature2 | FrontDesk | Feature 2   | Owner Apps         | Application |
		| AccessFeature3 | FrontDesk | Feature 3   | Customer Apps      | Application |
		| ViewReport1    | FrontDesk | Report 1    | Front Desk Reports | Reports     |
		| AccessFeature4 | FrontDesk | Feature 4   | Front Desk Apps    | Application |
		| ViewReport2    | FrontDesk | Report 2    | Front Desk Reports | Reports     |
		| ViewReport3    | Sales     | Report 3    | Sales Reports      | Reports     |
		| AccessUtility1 | Sales     | Utility 1   | Sales Utils        | Utilities   |
		| AccessFeature5 | Hoa       | Feature 5   | HOA Apps           | Application |
		| AccessUtility2 | Hoa       | Utility 2   | HOA Utils          | Utilities   |
		| ViewReport4    | Hoa       | Report 4    | HOA Reports        | Reports     |

	Given a set of ETickets of:
		| Name     | Url                 |
		| Eticket1 | http://www.url1.com |
		| Eticket2 | http://www.url2.com |
		| Eticket3 | http://www.url3.com |
		| Eticket4 | http://www.url4.com |
		| Eticket5 | http://www.url5.com |
		| Eticket6 | http://www.url6.com |
		| Eticket7 | http://www.url7.com |



Scenario: No access to features

	Given the privileges of the user accessing the system is:
		|Permission										|
	When requesting the FrontDesk hyperlinks the current user can access
	Then the following hyperlinks should be available:
		"""
		ApplicationSection
			E-tickets
				Eticket1
				Eticket2
				Eticket3
				Eticket4
				Eticket5
				Eticket6
				Eticket7
		"""



Scenario: Partial access to Front Desk features

	Given the privileges of the user accessing the system is:
		| Permission     |
		| AccessFeature4 |
		| AccessFeature1 |
		| AccessFeature2 |
		| AccessFeature3 |
		| ViewReport2    |
		| ViewReport3    |
		| AccessUtility1 |
	When requesting the FrontDesk hyperlinks the current user can access
	Then the following hyperlinks should be available:
		"""
		ApplicationSection
			Customer Apps
				Feature 3
			Front Desk Apps
				Feature 1
				Feature 4
			Owner Apps
				Feature 2
			E-tickets
				Eticket1
				Eticket2
				Eticket3
				Eticket4
				Eticket5
				Eticket6
				Eticket7
		ReportsSection
			Front Desk Reports
				Report 2
		"""



Scenario: Full access to Hoa features

	Given the privileges of the user accessing the system is:
		| Permission     |
		| AccessFeature4 |
		| AccessFeature1 |
		| AccessFeature2 |
		| AccessFeature3 |
		| ViewReport2    |
		| ViewReport3    |
		| AccessUtility1 |
		| AccessFeature5 |
		| AccessUtility2 |
		| ViewReport4    |
	When requesting the Hoa hyperlinks the current user can access
	Then the following hyperlinks should be available:
		"""
		ApplicationSection
			HOA Apps
				Feature 5
		UtilitiesSection
			HOA Utils
				Utility 2
		ReportsSection
			HOA Reports
				Report 4
		"""
