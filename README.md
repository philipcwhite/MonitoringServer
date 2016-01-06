# MonitoringServer 0.4.3b

##About

This repository contains the code for the Monitoring Server Application.  The Monitoring Server contains 4 parts.  MonitoringCollector is a Windows service that collects data from the Monitoring Agent and inserts it into the database.  MonitoringDataEngine processes the data and moves it to the correct tables.  MonitoringEventEngine creates events when thresholds have been crossed.  Monitoring is the Website component that is used to view and Administer the Monitoring solution.  It also creates the database when the site is loaded for the first time.  Please note that this is Beta software and the full functionality has not been coded yet.  


For setup and configuration please see the new Wiki


##Screenshots

###New Flat Design

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/FlatDesign.png)

###Device View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Device.png)
 
###Graphing View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Graph.png)
 


##Change Log


###Changes for Version 0.4.3b (2016/01/06):

I posted an image of something I've been working on for a possible new design.  I am trying to remove as many of the layout tables as I can and replace them with a more fluid design that fits with more display resolutions.  


###Changes for Version 0.4.3b (2016/01/05):

1.  Added basic user customization to the website.  Users can now build their own device/event view by selecting what assets they want to see.

2.  Updated graphing to include 1 Hr, 6 Hr, 12 Hr, and 24 Hr ranges.  The ranges above 1 Hr are just points from on the hour, not averaged.  

3.  General bug fixes.  Corrected an issue when no events are shown, the event and device tables display correctly.


###Changes for Version 0.4.2b (2016/01/04):

1.  Added Monitors for Local Disk performance and pagefile.  Redesigned Device page to fit these.  Mostly a spacing issue.  So yes the screenshots are out of date again.  I will be adding services to this page eventually in some format. I also plan on adding a Ping availabiity that will probably run at 1 minute intervals.  I also fixed an Entity Framework issue that affected changing tables.  


###Changes for Version 0.4.1b (2016/01/02):

1.  Added Basic Graphing.  Clicking on one of the performance monitors in the Device view will now bring you to a graphing page.  This is still early and only supports the past hour of data.  I plan on adding new ranges up to 24 hours as time permits.  For older performance I will add features in the Reporting section.  

2.  Updated appearance, fixed tables.


###Changes for Version 0.4.0b (2015/12/31):

1.  Several changes have been made to data processing and lots of bug fixes.  I am currently having some issues with performance on the event manager.  It could be my 1 CPU VM I'm developing this on is just a bit weak but I'm trying to stay lightweight so that when people start expanding they don't have to mortgage their business to buy server resources.  

2.  I am currently working on graphing and hope to have something released early January.  I am developing graphs using HTML5 SVG so they look pretty good.  The Monitoring agent has been set to collect every 5 minutes.  This will be a firm poll period going forward.  I will probably put in a ping or availability metric that hits servers sooner than that but for CPU, etc. 5 minutes is a good time.  This will also keep database sizes smaller.


###Changes for Version 0.4.0b (2015/12/27):

1.  Completely retooled the dataflow between the agent and the collector.  

2.  Updated Agent to send new xml format.  Updated collector to process it.

3.  Added control to add new thresholds.

4.  Added Search capability.

5.  Installer for services is one install instead of 3.

###Changes for Version 0.3.7b (2015/12/21):

1.  Significantly improved performance on the services.  Changed Delete clauses to not fetch.  

2.  Added the ability to edit, delete, and restore, Global Thresholds via the website.  I will be adding an add Page soon.  Also Local thresholds do work as overrides but can only be entered directly into the database as of now.

###Changes for Version 0.3.6b (2015/12/21):

1.  Updates to support agent changes

###Changes for Version 0.3.5b (2015/12/21):

1.  Updated Event Engine.  Corrected several issues.  

2.  Added default global thresholds to website.  Edit functions will be added.  Agent override thresholds do work (via database insert) as well but have not been added to the website yet.  Processor/Memory are working. I may need to do more testing on disk and services. 

3.  Updated database schema.  Removed some group tables.

###Changes for Version 0.3.4b (2015/12/20):

1.  Website user authentication done.  Default user created (admin/password).

2.  Graphic Update.  Still some legacy code to prune.

3.  All apps correctly updated to 64 bit default.

4.  DBInstaller no longer needed.  Replaced by a first run script on the Website.


###Changes for Version 0.3.3b (2015/12/17):

1.  Added in Update User Profile.

Changes for Version 0.3.2b (2015/12/17):

1.  Fixed a bug in the data engine.  Cleanup was not performing properly.

2.  Added link for updating profile.  


###Changes for Version 0.3.1b (2015/12/15):

1.  Updated graphics.

2.  Added logout in User Options.


###Changes for Version 0.3.0b (2015/12/13):

1.  Updated Binaries to x64.  

2.  Added Monitoring Website.

3.  Updated code first data models.


###Changes for Version 0.2.2b (2015/12/11):

1. Updated tables for website compatibility.   


###Changes for Version 0.2.1b (2015/12/07):

1. Added in group thresholds.  Agent Thresholds are now set to override group thresholds.  


###Changes for Version 0.2.0b (2015/12/07):

1.  Added the Event Engine.  It currently processes Agent Thresholds.  I will be adding in support for groups soon.

2.  Updated Database Schema for thresholds and events.



-Monitoring Server Copyright Phil White 2016