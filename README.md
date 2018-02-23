# Monitoring Server 1.0.3

## About

This repository contains the code for the Monitoring Server Application.  The Monitoring Server contains 4 parts.  MonitoringCollector is a Windows service that collects data from the Monitoring Agent and inserts it into the database.  MonitoringDataEngine processes the data and moves it to the correct tables.  MonitoringEventEngine creates events when thresholds have been crossed.  Monitoring is the Website component that is used to view and Administer the Monitoring solution.  It also creates the database when the site is loaded for the first time.  


For setup and configuration please see the new Wiki


## Screenshots

### Home

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Home.png)

### Event View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Events.png)
 
### Device View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Device.png)
 
### Reporting View

![WebSite](https://raw.githubusercontent.com/philipcwhite/MonitoringServer/master/Screenshots/Reports.png)


## Change Log

### Changes for Version 1.0.3 (2018/02/23):

Updated database model.  Added Network traffic monitoring for Windows.  Please use the latest Monitoring Agent.

### Changes for Version 1.0.2 (2017/02/12):

I fixed the event engine and added back custom thresholds for agents and linked Windows Service Status.

### Changes for Version 1.0.2 (2017/02/12):

If you are doing an update please update all components (agent, server, and database).  The database has changed slightly with the addition of the AgentUptime field in AgentSystem table.  You need to either add this column or reinstall. 

1. Changed Agent poll period from 5 minutes to 1 minute.  
2. Data storage has now been reduced to 1 hour of fast data and 14 days of long data.
3. Device views have been updated significantly.  New graphs and statistics.
4. Colors have been slightly modified.
5. I will be updating the event engine next.  You may notice that some features are disabled temporarily.  This is do to an error that is occuring with the Active Disk Time monitor.


### Changes for Version 1.0.1 (2017/01/22):

1. Changed service data to only keep one record (up/down) to save space and reduce overhead.

### Changes for Version 0.7.2 (2017/01/21):

I feel like this is the yes we are still alive update...  And yes we are.  Life just got a little busy in 2016 and it probably is going to get even crazier this year.  That being said I migrated to Windows 10, fired up Visual Studio, and started coding this week.

Updates have been made to the agent to correct a bug with how IPv4 was calculated.  The agent will now work on Windows 10 machines.  Please download the agent from the Monitoring Agent Github page.

I have also discovered a few outstanding issues with how events are currently being processed on the server.  I hope to resolve these in a future release.  Data processing will also be refined.  The current data model is still database heavy and needs some refinement.  Retained data will most likely be scaled back initially.  I hope to broaden what is monitored in the long run. 

There will be more changes as time permits including updates to the web interface.  I plan on making some changes to give users a better snapshot of the health of a server.

About 8 months ago I also tested sending data from MacOS to Windows successfully.  It was unencrypted but it did work.  If there is interest in this or adding other OS support please let me know.


### Changes for Version 0.7.2 (2016/03/10):

1.  Updated the alert donut code.  Now if there are no alerts, the donut will be gray.  


### Changes for Version 0.7.1b (2016/02/24):

1.  Minor changes.  Changed availability donut to 10 minutes instead of 15 to correspond to the default thresholds.


### Changes for Version 0.7.0b (2016/02/23):

1.  This update is mostly css and html fixes.  Add rounded corners and fixed some spacing issues.


### Changes for Version 0.6.8b (2016/02/22):

1.  Small fix to notification config saving.


### Changes for Version 0.6.7b (2016/02/22):

1.  Small fix to xml export on event engine.


### Changes for Version 0.6.6b (2016/02/22):
 
This update brings a lot of changes.  

1.  The three server services are now configured to run as local system by default.  You will need to grant database permissions to this account in addition to network service.  This eliminates the issue of having to deal with folder permissions in the Program Files directory.

2.  I have changed how files are stored in the install directory.  I have seperated the config, log, and executables, and I have created a new folder called export.

3.  I have made a lot of changes to processing notifications.  I now added the option to export notifications to a file  in the export directory.  Exported notifications are stored as xml files and use a GUID for the filename ensuring uniqueness.

4.  I fixed a bug that stoped new notifications from being send on escallation.  Now if an event escallates another notification is sent.  All notifications are based off thresholds.  So for example if you do not want a notification to send for an info alert then disable the threshold.


### Changes for Version 0.6.5b (2016/02/17):

1.  Updated Spacing issue in Mozilla Firefox.


### Changes for Version 0.6.4b (2016/02/17):

1.  Added 3 performance reports.

2.  Updated Screenshots.


### Changes for Version 0.6.3b (2016/02/14):

1.  Added csv export to graphs.



-Monitoring Server Copyright Phil White 2018