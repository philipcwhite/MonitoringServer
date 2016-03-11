# Monitoring Server 0.7.2 

##About

This repository contains the code for the Monitoring Server Application.  The Monitoring Server contains 4 parts.  MonitoringCollector is a Windows service that collects data from the Monitoring Agent and inserts it into the database.  MonitoringDataEngine processes the data and moves it to the correct tables.  MonitoringEventEngine creates events when thresholds have been crossed.  Monitoring is the Website component that is used to view and Administer the Monitoring solution.  It also creates the database when the site is loaded for the first time.  


For setup and configuration please see the new Wiki


##Screenshots

###Home

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Home.png)

###Event View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Events.png)
 
###Device View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Device.png)
 
###Graphing View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Graphing.png)
 
###Reporting View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Reports.png)


##Change Log


###Changes for Version 0.7.2 (2016/03/10):

1.  Updated the alert donut code.  Now if there are no alerts, the donut will be gray.  


###Changes for Version 0.7.1b (2016/02/24):

1.  Minor changes.  Changed availability donut to 10 minutes instead of 15 to correspond to the default thresholds.


###Changes for Version 0.7.0b (2016/02/23):

1.  This update is mostly css and html fixes.  Add rounded corners and fixed some spacing issues.


###Changes for Version 0.6.8b (2016/02/22):

1.  Small fix to notification config saving.


###Changes for Version 0.6.7b (2016/02/22):

1.  Small fix to xml export on event engine.


###Changes for Version 0.6.6b (2016/02/22):

This update brings a lot of changes.  

1.  The three server services are now configured to run as local system by default.  You will need to grant database permissions to this account in addition to network service.  This eliminates the issue of having to deal with folder permissions in the Program Files directory.

2.  I have changed how files are stored in the install directory.  I have seperated the config, log, and executables, and I have created a new folder called export.

3.  I have made a lot of changes to processing notifications.  I now added the option to export notifications to a file  in the export directory.  Exported notifications are stored as xml files and use a GUID for the filename ensuring uniqueness.

4.  I fixed a bug that stoped new notifications from being send on escallation.  Now if an event escallates another notification is sent.  All notifications are based off thresholds.  So for example if you do not want a notification to send for an info alert then disable the threshold.


###Changes for Version 0.6.5b (2016/02/17):

1.  Updated Spacing issue in Mozilla Firefox.


###Changes for Version 0.6.4b (2016/02/17):

1.  Added 3 performance reports.

2.  Updated Screenshots.


###Changes for Version 0.6.3b (2016/02/14):

1.  Added csv export to graphs.


###Changes for Version 0.6.2b (2016/02/12):

1.  Changed bullets to use small images for better alignment.

2.  Added an event count to the events page.

3.  Updated the Wiki.


###Changes for Version 0.6.1b (2016/02/12):

1.  Updated the Event view to allow filtering by status and severity.

2.  Corrected spelling bugs


-Monitoring Server Copyright Phil White 2016