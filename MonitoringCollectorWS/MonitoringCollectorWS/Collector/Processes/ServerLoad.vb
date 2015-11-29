Imports MonitoringCollectorWS.ServerParameters
Imports MonitoringCollectorWS.ServerConfigDB
Imports System.IO
Imports System.Xml
Imports System.Text

Public Class ServerLoad

    Public NetworkLog As New NetworkLog

    Public Sub LoadParameters()
        'Configuration Parameters
        CreateXML()
        LoadXML()

        'Log Parameters
        NetworkLog.InitializeLog()

    End Sub

    Public Sub CreateXML()
        If Not File.Exists(ServerPath & "\ServerConfiguration.xml") Then
            Dim Settings As XmlWriterSettings = New XmlWriterSettings()
            Settings.Indent = True
            Settings.NewLineOnAttributes = False
            Settings.OmitXmlDeclaration = True
            Dim SB As New StringBuilder()

            Using SW As New StringWriter(SB)
                Using writer = XmlWriter.Create(SW, Settings)
                    writer.WriteStartDocument()
                    writer.WriteStartElement("server-config")

                    writer.WriteStartElement("object")
                    writer.WriteAttributeString("class", "server")
                    writer.WriteAttributeString("parameter", "version")
                    writer.WriteAttributeString("value", "2.0.1")
                    writer.WriteEndElement()

                    'For testing we are sending to the localhost
                    writer.WriteStartElement("object")
                    writer.WriteAttributeString("class", "server")
                    writer.WriteAttributeString("parameter", "server")
                    writer.WriteAttributeString("value", "localhost")
                    writer.WriteEndElement()

                    writer.WriteStartElement("object")
                    writer.WriteAttributeString("class", "server")
                    writer.WriteAttributeString("parameter", "tcp_listen")
                    writer.WriteAttributeString("value", "10001")
                    writer.WriteEndElement()

                    writer.WriteEndElement()
                    writer.WriteEndDocument()
                End Using
            End Using

            File.WriteAllText(ServerPath & "\ServerConfiguration.xml", SB.ToString)

        End If

    End Sub

    Public Sub LoadXML()

        Try

            Dim xelement As XElement = XElement.Load(ServerPath & "\ServerConfiguration.xml")
            Dim xmlobjects As IEnumerable(Of XElement) = xelement.Elements("object")

            For Each i In xmlobjects
                ServerConfigurationList.Add(New ServerConfiguration With {.ServerClass = i.Attribute("class").Value, .ServerParameter = i.Attribute("parameter").Value, .ServerValue = i.Attribute("value").Value})
            Next

            Dim Q = From T In ServerConfigurationList
                    Where T.ServerClass.Contains("server")
                    Select T

            For Each i In Q
                Select Case i.ServerParameter
                    Case "tcp_listen"
                        TCPListenPort = i.ServerValue
                    Case "encryption_key"
                        Key = System.Text.Encoding.ASCII.GetBytes(i.ServerValue)
                End Select
            Next

        Catch ex As Exception
        End Try

    End Sub


End Class
