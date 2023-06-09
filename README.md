# MunicipalityTax
Užduotis
C# Coding Task

We expect you to create a small application which manages taxes applied in different municipalities. The taxes
are scheduled in time. Application should allow the user to get taxes applied in certain municipalities at the
given day.
Example: Municipality Vilnius has its taxes scheduled like this:
• yearly tax = 0.2 (for period 2021.01.01-2021.12.31),
• monthly tax = 0.4 (for period 2021.05.01-2021.05.31),
• weekly tax is not set for the period
• and it has two daily taxes scheduled = 0.1 (at days 2021.01.01 and 2021.12.25).
The result according to provided example would be:
Municipality (Input) Date (Input) Result
Vilnius 2021.01.01 0.1
Vilnius 2021.05.02 0.4
Vilnius 2021.07.10 0.2
Vilnius 2021.03.16 0.2
Result is returned in the following priority: Daily, Weekly, Monthly, Yearly.
Full requirements for the application:
• It has its own database where municipality taxes are stored
• Taxes should have ability to be scheduled (yearly, monthly, weekly, daily) for each municipality
• Application should have ability to Create/Update/Delete records for municipality taxes (one record at
a time)
• User can ask for a specific municipality tax by entering municipality name and date
• Handle as many errors as You think it’s required
• You should ensure that application works correctly
• Application should be deployed as a self-hosted windows service
• Update record functionality is exposed via API
Application has no visible user interface, requests are given directly to application as a service (producer service).
Also, there should be a consumer service created to demonstrate how the producer service can be used.
Bonus tasks - write code tests
Please try to manage the task in separate logical Git commits.