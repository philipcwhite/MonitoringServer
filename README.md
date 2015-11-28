# MonitoringServer 0.1.1b

About

This repository contains the code for the Monitoring Collector that the Monitoring Agent sends data to.  This is an extremely early beta so use at your own risk.  As of now it contains two projects.  One is the database installer and the second is a TCP listener that collects data and inserts it into the database.  This component currently runs as a Windows Service.  The reason for releasing this as is, is to support the agent that I have already written.  This gives the agent somewhere to send data to.  This has been tested on SQL Express 2014.  


Updates (11/28/2015)

1. Converted the Listener (collector) to a Windows Service.

Setup

1. Install SQL Server (Express is fine).  

2. Compile the DBInstallerCA project and run this once.  This will create the Monitoring database.

3. Assign Network Service write access to the database.  I currently have my test set up as SysAdmin.

4.  Compile the service and installer for the MonitoringCollectorWS project.

5.  Run the MonitoringCollector installer.

6.  If your firewall is enabled, you need allow the collector access to the network.


Future Notes 

Future plans for 2.0 release include a web interface and a statistical processing engine.  If there is support for this project, I will consider building an event manager and notification engine.

Phil White 