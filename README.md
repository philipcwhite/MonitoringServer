# MonitoringServer 0.4.0b

About

This repository contains the code for the Monitoring Server.  The Monitoring Server contains 4 parts.  MonitoringCollector is a Windows service that collects data from the Monitoring Agent and inserts it into the database.  MonitoringDataEngine processes the data and moves it to the correct tables.  MonitoringEventEngine creates events when thresholds have been crossed.  Monitoring is the Website component that is used to view and Administer the Monitoring solution.  It also creates the database when the site is loaded for the first time.  Please note that this is Beta software and the full functionality has not been coded yet.  


I am currently working on finishing the base code for the website.  After this is done I will most likely make the install a little friendlier before adding graphs, reports, etc.  I also plan on packaging the services as one installer making the server simpler to deploy.


For setup and configuration please see the new Wiki


![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Website.png)
 

##Changes for Version 0.4.0b (2015/12/31):

1.  Several changes have been made to data processing and lots of bug fixes.  I am currently having some issues with performance on the event manager.  It could be my 1 CPU VM I'm developing this on is just a bit weak but I'm trying to stay lightweight so that when people start expanding they don't have to mortgage their business to buy server resources.  

2.  I am currently working on graphing and hope to have something released early January.  I am developing graphs using HTML5 SVG so they look pretty good.  The Monitoring agent has been set to collect every 5 minutes.  This will be a firm poll period going forward.  I will probably put in a ping or availability metric that hits servers sooner than that but for CPU, etc. 5 minutes is a good time.  This will also keep database sizes smaller.


##Changes for Version 0.4.0b (2015/12/27):

1.  Completely retooled the dataflow between the agent and the collector.  

2.  Updated Agent to send new xml format.  Updated collector to process it.

3.  Added control to add new thresholds.

4.  Added Search capability.

5.  Installer for services is one install instead of 3.

##Changes for Version 0.3.7b (2015/12/21):

1.  Significantly improved performance on the services.  Changed Delete clauses to not fetch.  

2.  Added the ability to edit, delete, and restore, Global Thresholds via the website.  I will be adding an add Page soon.  Also Local thresholds do work as overrides but can only be entered directly into the database as of now.

##Changes for Version 0.3.6b (2015/12/21):

1.  Updates to support agent changes

##Changes for Version 0.3.5b (2015/12/21):

1.  Updated Event Engine.  Corrected several issues.  

2.  Added default global thresholds to website.  Edit functions will be added.  Agent override thresholds do work (via database insert) as well but have not been added to the website yet.  Processor/Memory are working. I may need to do more testing on disk and services. 

3.  Updated database schema.  Removed some group tables.

##Changes for Version 0.3.4b (2015/12/20):

1.  Website user authentication done.  Default user created (admin/password).

2.  Graphic Update.  Still some legacy code to prune.

3.  All apps correctly updated to 64 bit default.

4.  DBInstaller no longer needed.  Replaced by a first run script on the Website.

##Changes for Version 0.3.3b (2015/12/17):

1.  Added in Update User Profile.

Changes for Version 0.3.2b (2015/12/17):

1.  Fixed a bug in the data engine.  Cleanup was not performing properly.

2.  Added link for updating profile.  

##Changes for Version 0.3.1b (2015/12/15):

1.  Updated graphics.

2.  Added logout in User Options.

##Changes for Version 0.3.0b (2015/12/13):

1.  Updated Binaries to x64.  

2.  Added Monitoring Website.

3.  Updated code first data models.

##Changes for Version 0.2.2b (2015/12/11):

1. Updated tables for website compatibility.   

##Changes for Version 0.2.1b (2015/12/07):

1. Added in group thresholds.  Agent Thresholds are now set to override group thresholds.  

##Changes for Version 0.2.0b (2015/12/07):

1.  Added the Event Engine.  It currently processes Agent Thresholds.  I will be adding in support for groups soon.

2.  Updated Database Schema for thresholds and events.

##Changes for Version 0.1.8b (2015/12/06):

1. Updated DB Schema to account for large datasets and added in new tables for event and policy management.

##Changes for Version 0.1.7b (2015/12/05):

1.  I continued to address scalability by creating archive data tables.  The existing Agent data tables will hold 24 hours of data for active event processing and data viewing.  The archive tables will hold data that is over 24 hours old.  I moved the cut off date to 30 days in the archive.  Tables here could still potentially grow to 100 million plus rows depending on collection intervals and number of items collected.  I will eventually add a configuration file for this so that it can be configured manually.

2.  I also updated exisiting tables and reduced their column sizes.  If you are using short host names over 50 characters, then your out of luck. 

##Changes for Version 0.1.6b (2015/12/04):

This update mostly addresses database scaling.  My goal is to be able to handle 1000+ agents at an average poll period of 5 minutes with decent database response time.

1.  Updated the database schema by seperating system components to their own tables.  This was done to improve SQL performance by shrinking large tables.

2.  Set the cleanup period to 7 days.  This will change after archive tables are created.  The main processing table will be set to 24 hours and then the archive will receive data after that.  There may be a third archive table if I decide to scale large.  

##Changes for Version 0.1.5b (2015/12/03):

1.  Converted the data engine to a Windows Service.

2.  Added a cleanup cycle to the data engine.  

##Changes for Version 0.1.4b (2015/12/02):

1.  Updated database schema.

2.  For the DataEngine, I added in queries to move data from the AgentCollection table to the Agent and AgentData tables.

##Changes for Version 0.1.3b (2015/12/01):

1. Updated database schema. 

2. Started work on the DataEngine.  This will eventually run as a service.  

##Changes for Version 0.1.2b (2015/11/29):

1. Converted the Listener (collector) to a Windows Service.

2. Set default listen port to 10001.


-Phil White