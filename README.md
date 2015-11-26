# MonitoringServer 0.1.0b

This repository contains the code for the Monitoring Server that the Monitoring Agent sends data to.  This is an extremely early beta so use at your own risk.  As of now it contains two projects.  One is the database installer and the second is a TCP listener that collects data and inserts it into the database.  This component currently runs as a console application.  The reason for releasing this as is, is to support the agent that I have already written.  This gives the agent somewhere to send data to.  This has been tested on SQL Express 2014.  

I plan on converting the listener to the service and improving the DB schema for the first official 1.0.0 release. Future plans for 2.0 release include a web interface and a statistical processing engine.  If there is support for this project, I will consider building an event manager and notification engine.

Phil White 