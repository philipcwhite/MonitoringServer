# MonitoringServer 0.2.2b

About

This repository contains the code for the Monitoring Collector that the Monitoring Agent sends data to.  This is an extremely early beta so use at your own risk.  As of now it contains four projects.  One is the database installer, the second is a TCP listener that collects data and inserts it into the database, the third is a data processing app, and the fourth is an event engine.  The reason for releasing this as is, is to support the agent that I have already written.  This gives the agent somewhere to send data to.  This has been tested on Windows 8.1 with SQL Express 2014.  


Website coming soon! (2015/12/11)

![WebSite](https://github.com/philipcwhite/MonitoringServer/master/WebSite.png)


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


Setup

1. Install SQL Server (Express is fine).  

2. Compile the DBInstallerCA project and run this once.  This will create the Monitoring database.

3. Assign "Network Service" write access to the database.  I currently have my test set up as SysAdmin.  

4. Compile the service and installer for the MonitoringCollectorWS project or use the binary release.

5. Run the MonitoringCollectorWS installer.  Run the MonitoringDataEngine installer.

6. The Collector needs access to read and write to the installation folder.  You must grant the "Network Service" account these rights.  

7. If your firewall is enabled, you need allow the collector access to the network.
 


Future Notes 

Future plans for 1.0 and 2.0 releases include a web interface.

Phil White 