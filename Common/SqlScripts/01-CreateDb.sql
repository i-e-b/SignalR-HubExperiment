USE master
IF EXISTS(select * from sys.databases where name='SignalR_Backplane_Demo')
DROP DATABASE SignalR_Backplane_Demo

CREATE DATABASE SignalR_Backplane_Demo
GO

ALTER DATABASE SignalR_Backplane_Demo SET ENABLE_BROKER