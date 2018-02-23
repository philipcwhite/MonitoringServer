Imports MonitoringCollector.MonitoringDatabase
Imports System.Xml
Public Class DataLoad

    Public Sub TranslateXML(ByVal xmlMessage As String)

        Dim db As New DBModel


        Dim doc As New XmlDocument
        doc.LoadXml(xmlMessage)

        Dim AgentSystemNode As XmlNodeList = doc.DocumentElement.SelectNodes("/Agent/AgentSystem")
        Dim AgentDataNode As XmlNodeList = doc.DocumentElement.SelectNodes("/Agent/AgentData")
        Dim AgentStateNode As XmlNodeList = doc.DocumentElement.SelectNodes("/Agent/AgentState")

        Dim AgentName As String = Nothing
        Dim AgentDomain As String = Nothing
        Dim AgentIP As String = Nothing
        Dim AgentOSName As String = Nothing
        Dim AgentOSBuild As String = Nothing
        Dim AgentOSArchitecture As String = Nothing
        Dim AgentProcessors As String = Nothing
        Dim AgentMemory As String = Nothing
        Dim AgentUptime As String = Nothing
        Dim AgentDate As String = Nothing




        For Each node As XmlNode In AgentSystemNode
            AgentName = node.SelectSingleNode("AgentName").InnerText
            AgentDomain = node.SelectSingleNode("AgentDomain").InnerText
            AgentIP = node.SelectSingleNode("AgentIP").InnerText
            AgentOSName = node.SelectSingleNode("AgentOSName").InnerText
            AgentOSBuild = node.SelectSingleNode("AgentOSBuild").InnerText
            AgentOSArchitecture = node.SelectSingleNode("AgentOSArchitecture").InnerText
            AgentProcessors = node.SelectSingleNode("AgentProcessor").InnerText
            AgentMemory = node.SelectSingleNode("AgentMemory").InnerText
            AgentUptime = node.SelectSingleNode("AgentUptime").InnerText
            AgentDate = node.SelectSingleNode("AgentDate").InnerText


            'Dim NLog As New NetworkLog
            'NLog.WriteToLog("Uptime=" & AgentUptime)


            Dim Q = (From T In db.AgentSystem
                     Where T.AgentName = AgentName
                     Select T).FirstOrDefault

            If Q IsNot Nothing Then

                Q.AgentDomain = AgentDomain
                Q.AgentIP = AgentIP
                Q.AgentOSName = AgentOSName
                Q.AgentOSBuild = AgentOSBuild
                Q.AgentOSArchitecture = AgentOSArchitecture
                Q.AgentProcessors = AgentProcessors
                Q.AgentMemory = AgentMemory
                Q.AgentUptime = AgentUptime
                Q.AgentDate = AgentDate
                db.SaveChanges()
            Else
                db.AgentSystem.Add(New AgentSystem With {.AgentName = AgentName, .AgentDomain = AgentDomain, .AgentIP = AgentIP, .AgentOSName = AgentOSName, .AgentOSBuild = AgentOSBuild, .AgentOSArchitecture = AgentOSArchitecture, .AgentProcessors = .AgentProcessors, .AgentMemory = .AgentMemory, .AgentUptime = AgentUptime, .AgentDate = AgentDate})
                db.SaveChanges()
            End If

        Next


        'Load Data


        Dim AgentClass As String = Nothing
        Dim AgentProperty As String = Nothing
        Dim AgentValue As String = Nothing

        For Each node As XmlNode In AgentDataNode

            AgentClass = node.SelectSingleNode("AgentClass").InnerText
            AgentProperty = node.SelectSingleNode("AgentProperty").InnerText
            AgentValue = node.SelectSingleNode("AgentValue").InnerText

            db.AgentData.Add(New AgentData With {.AgentName = AgentName, .AgentClass = AgentClass, .AgentProperty = AgentProperty, .AgentValue = AgentValue, .AgentCollectDate = AgentDate})
            db.SaveChanges()

        Next


        'Load State

        db.AgentState.RemoveRange(db.AgentState.Where(Function(o) o.AgentName = AgentName))
        db.SaveChanges()

        For Each node As XmlNode In AgentStateNode

            AgentClass = node.SelectSingleNode("AgentClass").InnerText
            AgentProperty = node.SelectSingleNode("AgentProperty").InnerText
            AgentValue = node.SelectSingleNode("AgentValue").InnerText

            db.AgentState.Add(New AgentState With {.AgentName = AgentName, .AgentClass = AgentClass, .AgentProperty = AgentProperty, .AgentValue = AgentValue, .AgentCollectDate = AgentDate})
            db.SaveChanges()
        Next


    End Sub

End Class
