# MonitoringServer 0.3.2b

About

This repository contains the code for the Monitoring Server.  The Monitoring Server contains 4 parts and a database installer.  MonitoringCollectorWS is a Windows service that collects data from the Monitoring Agent and inserts it into the database.  MonitoringDataEngineWS processes the data and moves it to the correct tables.  MonitoringEventEngineWS creates events when thresholds have been crossed.  Monitoring is the Website component that is used to view and Administer the Monitoring solution.  And lastly DBInstallerCA is a simple console App to install the database.  Please note that this is Beta software and the full functionality has not been coded yet.  

I am currently working on finishing the base code for the website.  After this is done I will most likely make the install a little friendlier before adding graphs, reports, etc.  

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Website.png)

Setup Instructions

You may use the compiled binaries or compile the code yourself.  Security settings on the MonitoringCollectorWS project and MonitoringAgent project should be updated if you plan on eventually using this in production.

1. Install SQL Server (Express is fine).  

2. Compile the DBInstallerCA project and run DBInstallerCA.exe once with a user account that has create rights in SQL.  This will create the Monitoring database.

3. Assign "Network Service" write access to the database.  For testing I am assigning it the role SysAdmin.  It should not need SysAdmin privilages.  

4. Compile the service and installer for the MonitoringCollectorWS, MonitoringDataEngineWS, and MonitoringEventEngineWS project or use the binary releases.

5. Run the MonitoringCollectorWS installer.  Run the MonitoringDataEngineWS installer.  Run the MonitoringEventEngineWS installer.

6. The Collector needs access to read and write to the installation folder.  You must grant the "Network Service" account these rights.  

7. If your firewall is enabled, you need allow the collector access to the network.

8. Copy the Monitoring folder to C:\inetpub\wwwroot.  Set this up as an ASP.Net Projuct and make sure it's App Pool is Running as Network Service.

9.  Users are not currently set up.  When you log into the Website for the first time it will redirect you to the login page.  There is a link to register users.  Follow that and create a User.  You will then need to assign the Role Administrators to the user in the UserRoles Table.  After this, your user will have access.
 

Changes for Version 0.3.2b (2015/12/17):

1.  Fixed a bug in the data engine.  Cleanup was not performing properly.

2.  Added link for updating profile.  

Changes for Version 0.3.1b (2015/12/15):

1.  Updated graphics.

2.  Added logout in User Options.

Changes for Version 0.3.0b (2015/12/13):

1.  Updated Binaries to x64.  

2.  Added Monitoring Website.

3.  Updated code first data models.

Changes for Version 0.2.2b (2015/12/11):

1. Updated tables for website compatibility.   

Changes for Version 0.2.1b (2015/12/07):

1. Added in group thresholds.  Agent Thresholds are now set to override group thresholds.  

Changes for Version 0.2.0b (2015/12/07):

1.  Added the Event Engine.  It currently processes Agent Thresholds.  I will be adding in support for groups soon.

2.  Updated Database Schema for thresholds and events.

Changes for Version 0.1.8b (2015/12/06):

1. Updated DB Schema to account for large datasets and added in new tables for event and policy management.

Changes for Version 0.1.7b (2015/12/05):

1.  I continued to address scalability by creating archive data tables.  The existing Agent data tables will hold 24 hours of data for active event processing and data viewing.  The archive tables will hold data that is over 24 hours old.  I moved the cut off date to 30 days in the archive.  Tables here could still potentially grow to 100 million plus rows depending on collection intervals and number of items collected.  I will eventually add a configuration file for this so that it can be configured manually.

2.  I also updated exisiting tables and reduced their column sizes.  If you are using short host names over 50 characters, then your out of luck. 

Changes for Version 0.1.6b (2015/12/04):

This update mostly addresses database scaling.  My goal is to be able to handle 1000+ agents at an average poll period of 5 minutes with decent database response time.

1.  Updated the database schema by seperating system components to their own tables.  This was done to improve SQL performance by shrinking large tables.

2.  Set the cleanup period to 7 days.  This will change after archive tables are created.  The main processing table will be set to 24 hours and then the archive will receive data after that.  There may be a third archive table if I decide to scale large.  

Changes for Version 0.1.5b (2015/12/03):

1.  Converted the data engine to a Windows Service.

2.  Added a cleanup cycle to the data engine.  

Changes for Version 0.1.4b (2015/12/02):

1.  Updated database schema.

2.  For the DataEngine, I added in queries to move data from the AgentCollection table to the Agent and AgentData tables.

Changes for Version 0.1.3b (2015/12/01):

1. Updated database schema. 

2. Started work on the DataEngine.  This will eventually run as a service.  

Changes for Version 0.1.2b (2015/11/29):

1. Converted the Listener (collector) to a Windows Service.

2. Set default listen port to 10001.


-Phil White