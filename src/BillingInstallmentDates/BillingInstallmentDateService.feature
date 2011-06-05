Feature: Billing Installment Date Service
	<TODO>


Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2011 and today is 1/1/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|

	When requesting the installment date range for 1/1/2011
	Then the resulting range should be 1/1/2011 and 2/15/2011

Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2011 and today is 1/15/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		
	When requesting the installment date range for 1/15/2011
	Then the resulting range should be 1/1/2011 and 2/15/2011	
	
Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2011 and today is 2/15/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		
	When requesting the installment date range for 2/15/2011
	Then the resulting range should be 1/1/2011 and 5/15/2011		

Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2011 and today is 3/15/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		
	When requesting the installment date range for 3/15/2011
	Then the resulting range should be 1/1/2011 and 5/15/2011
	
Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2011 and today is 5/15/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		
	When requesting the installment date range for 5/15/2011
	Then the resulting range should be 1/1/2011 and 8/15/2011		
	
Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2011 and today is 5/20/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		
	When requesting the installment date range for 5/20/2011
	Then the resulting range should be 1/1/2011 and 8/15/2011	
	
Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2011 and today is 8/15/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		
	When requesting the installment date range for 8/15/2011
	Then the resulting range should be 1/1/2011 and 8/15/2011		
	
Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2011 and today is 9/1/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		
	When requesting the installment date range for 9/1/2011
	Then the resulting range should be 1/1/2011 and 9/1/2011	
	
Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2011 and today is 12/31/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		
	When requesting the installment date range for 12/31/2011
	Then the resulting range should be 1/1/2011 and 12/31/2011	
	
Scenario: Billing schedule starts on 1/1/2011 ending 1/1/2012 and today is 12/31/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		|ALK	 |1	                   |Q1         |1/1/2012 |		
		
	When requesting the installment date range for 12/31/2011
	Then the resulting range should be 1/1/2011 and 1/1/2012		
	
Scenario: Billing schedule starts on 1/1/2011 ending 1/1/2012 and today is 9/1/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		|ALK	 |1	                   |Q1         |1/1/2012 |
		
	When requesting the installment date range for 9/1/2011
	Then the resulting range should be 1/1/2011 and 1/1/2012
	
Scenario: Billing schedule starts on 1/1/2011 ending 1/1/2012 and today is 1/1/2012
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		|ALK	 |1	                   |Q1         |1/1/2012 |
		
	When requesting the installment date range for 1/1/2012
	Then the resulting range should be 1/1/2012 and 1/1/2012
	
Scenario: Billing schedule starts on 1/1/2011 ending 8/15/2012 and today is 1/1/2012
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date     |
		|ALK	 |1					   |Q1		   |1/1/2011 |
		|ALK	 |2					   |Q2		   |2/15/2011|
		|ALK	 |3					   |Q3		   |5/15/2011|
		|ALK	 |4					   |Q4		   |8/15/2011|
		|ALK	 |1	                   |Q1         |1/1/2012 |
		|ALK	 |2					   |Q2		   |2/15/2012|
		|ALK	 |3					   |Q3		   |5/15/2012|
		|ALK	 |4					   |Q4		   |8/15/2012|		
		
	When requesting the installment date range for 1/1/2012
	Then the resulting range should be 1/1/2012 and 2/15/2012		
	
	
	
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 5/25/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 5/25/2011
	Then the resulting range should be 7/1/2010 and 7/1/2011	

Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 7/1/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 7/1/2011
	Then the resulting range should be 7/1/2011 and 8/15/2011
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 7/10/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 7/10/2011
	Then the resulting range should be 7/1/2011 and 8/15/2011	
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 8/15/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 8/15/2011
	Then the resulting range should be 7/1/2011 and 11/15/2011	
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 9/13/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 9/13/2011
	Then the resulting range should be 7/1/2011 and 11/15/2011			
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 11/15/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 11/15/2011
	Then the resulting range should be 7/1/2011 and 2/15/2012		
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 12/15/2011
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 12/15/2011
	Then the resulting range should be 7/1/2011 and 2/15/2012		
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 1/1/2012
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 1/1/2012
	Then the resulting range should be 7/1/2011 and 2/15/2012		
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 2/15/2012
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 2/15/2012
	Then the resulting range should be 7/1/2011 and 2/15/2012		
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 2/28/2012
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 2/28/2012
	Then the resulting range should be 7/1/2011 and 2/28/2012	
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2012 and today is 3/28/2012
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |		
		
	When requesting the installment date range for 3/28/2012
	Then the resulting range should be 7/1/2011 and 3/28/2012	
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2013 and today is 2/28/2012
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |	
		|VLA	 |1	                   |Q1         |7/1/2012  |
		|VLA	 |2					   |Q2		   |8/15/2012 |
		|VLA	 |3					   |Q3		   |11/15/2012|
		|VLA	 |4					   |Q4		   |2/15/2013 |				
		
	When requesting the installment date range for 2/28/2012
	Then the resulting range should be 7/1/2011 and 7/1/2012
	
Scenario: Billing schedule starts on 7/1/2011 ending 2/15/2013 and today is 3/28/2012
	Given a billing schedule of:
		|ResortId|InstallmentDateTypeId|Description|Date      |
		|VLA	 |1					   |Q1		   |7/1/2010  |
		|VLA	 |2					   |Q2		   |8/15/2010 |
		|VLA	 |3					   |Q3		   |11/15/2010|
		|VLA	 |4					   |Q4		   |2/15/2010 |
		|VLA	 |1	                   |Q1         |7/1/2011  |
		|VLA	 |2					   |Q2		   |8/15/2011 |
		|VLA	 |3					   |Q3		   |11/15/2011|
		|VLA	 |4					   |Q4		   |2/15/2012 |	
		|VLA	 |1	                   |Q1         |7/1/2012  |
		|VLA	 |2					   |Q2		   |8/15/2012 |
		|VLA	 |3					   |Q3		   |11/15/2012|
		|VLA	 |4					   |Q4		   |2/15/2013 |				
		
	When requesting the installment date range for 3/28/2012
	Then the resulting range should be 7/1/2011 and 7/1/2012				