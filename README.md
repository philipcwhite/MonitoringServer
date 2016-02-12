# Monitoring Server 0.6.1b 

##About

This repository contains the code for the Monitoring Server Application.  The Monitoring Server contains 4 parts.  MonitoringCollector is a Windows service that collects data from the Monitoring Agent and inserts it into the database.  MonitoringDataEngine processes the data and moves it to the correct tables.  MonitoringEventEngine creates events when thresholds have been crossed.  Monitoring is the Website component that is used to view and Administer the Monitoring solution.  It also creates the database when the site is loaded for the first time.  

I am nearing the end of the Version 1 development cycle.  If you are beta testing, the database should not change farther leading up to the 1.0.0 release.  I may not need an additional 39 releases before version 1.0.0 but I do plan on releasing a very stable product so I plan on doing a lot of testing.  If there is enough interest in the product I will open up discussion for a version 2 of the Monitoring Server and take community feedback.


For setup and configuration please see the new Wiki


##Screenshots

###Home

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Home.png)

###Event View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Events.png)
 
###Device View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Device.png)
 
###Graphing View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Graph.png)
 


##Change Log


###Changes for Version 0.6.1b (2016/02/09):

1.  Updated the Event view to allow filtering by status and severity.

2.  Corrected spelling bugs


###Changes for Version 0.6.0b (2016/02/09):

1.  Fixed a bug where Agent system data did not display if the agent hadn't reported in 24 hours.


###Changes for Version 0.5.9b (2016/02/06):

1.  Updated installation to pcwsoft instead of wcpsoft.  

2.  Added About page and bullets to the config page.

3.  Added NOTICE file.  Rebadged agent as 1.0.0.  


###Changes for Version 0.5.8b (2016/02/04):

1.  Corrected spelling of Architecture.  This does effect the database.  

2.  Started working on a Mac OSX Agent written in Swift.  I hope to have a new project page for this soon.  Preliminary TCP tests are working.  

3.  The monitoring agent will probably receive an update soon to update a few WMI queries.


###Changes for Version 0.5.7b (2016/01/27):

1.  Updated DataEngine to remove miliseconds and changed web time display to minutes.  


###Changes for Version 0.5.6b (2016/01/27):

1.  Minor style changes.  Updated agent naming for consistancy.

###Changes for Version 0.5.5b (2016/01/26):

1.  Updated Tables.  Removed AgentStatus from AgentSystem and renamed the column in AgentEvents.  This will break previous versions.

2.  Added three reports for Devices, Events, and Performance.  Reports have both CSV and Web versions.


###Changes for Version 0.5.3b (2016/01/22):

1.  Fixed a number of issues with the Event engine.

2.  Fixed the database installer.

3.  Added a log out button to the master page.

4.  Added alerts for agent status.  If the agent hasn't responded in x number of minutes, alerts will be generated.


###Changes for Version 0.5.2b (2016/01/22):

1.  Fixed a bug with the data engine.  Old data should now be averaged and archived on the hour.

2.  Updated graphing screenshot.


###Changes for Version 0.5.1b (2016/01/21):

1.  Updated the Line graphs to reflect the new theme.
 
2.  Updated the AgentServiceArchive table value to be a float so that decimals can be entered.


###Changes for Version 0.5.0b (2016/01/20):

1.  Added a page to view service status.  Fixed return link on Agent threshold page.

2.  Fixed an issue with the Data Engine not recognizing the time to execute.


###Changes for Version 0.4.9b (2016/01/19):

1.  Updated the data engine to sumarize old data.  Once hour 25 hits the last hour of data will be averaged and archived for 30 days.  This will help keep the database a manageable size.  This will reduce storage by 12 fold.  It's not a big deal for someone with less than 100 agents but at the higher end tables like the services table will grow to millions of records.  


###Changes for Version 0.4.8b (2016/01/18):

1.  Added GZip compression to the Agent Collector.  Network packets are approximately 1/10th the size.  You must update to the latest agent for compatibility.  All  Windows services set to automatic are now monitored by default.

2.  I plan on updating the Data engine next to average data over an hourly period to reduce storage capacity.
  

###Changes for Version 0.4.7b (2016/01/15):

1.  Huge Update!!!  I changed the underlying network infrastructure.  Instead of using AES packets, I switched TLS 1.2.  By default SSL is turned off.  It can be enabled through the ServerConfiguration.xml file that is created when the Collector starts.  Just change property="ssl_enabled" value="False" to True and do so on the agents in the AgentConfiguration.xml file as well.  Right now it is set up to use a self signed pfx certificate with the password "password".  I suggest you set up your own certificate.  The application requires it to be named certificate.pfx and have both a public and private key in the cert.  You can set the password in the ServerConfiguration.xml file.  As far as security the Agents do not care if the cert is valid.  I will add an option for cert checking at a later time.   

2.  The Event engine is having some stability issues right now.  It may be my testing system.  I added some try catch blocks to prevent some of the crashes.  I haven't had time to check this.

3.  If you read the change log you may notice a lot of messages that point out untested code.  This will all be tested before we hit 1.0 and we will hopefully have a pretty stable product.  Also I appoligize if you have been using the beta builds because I have been re-architecting a lot of code and causing a lot of breakage.  Once we hit 1.0 this repository will be locked except bug fixes and any new betas will be in a new branch or a new project folder.

4.  The agent build number will be brought inline with the server before the 1.0 release.  I started working on it prior to the server which is why the numbers do not line up.  


###Changes for Version 0.4.6b (2016/01/12):

1. Added a column to the subscriptions table for notifications and implemented buttons to toggle this.  This will eventually be for email notifications but that portion is not yet implemented.  I will be setting this to forward email to a SMTP server


###Changes for Version 0.4.5b (2016/01/09):

1.  Updated Home page to include new summary donut graphs for device and events.

2.  Added pages for setting Agent thresholds.  This has not been tested.  


###Changes for Version 0.4.4b (2016/01/08):

1.  Updated theme to new flat design.  There may be a few bugs due to dead links that I still have to troubleshoot.  The new theme is not 100% complete but the master page is done and most of the css has been updated.  I have tested in IE11 and Safari and both work fine.  I'll probably add a few more icon and spice things up a bit.  The home page is not complete.  Right now it displays devices that a user has subscribed too.  I plan on making some overview stat boxes and perhaps an event list as well.


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