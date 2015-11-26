Public Class DataClass

    Public Shared wDataList As New List(Of wData)
    Public Shared xmlSendList As New List(Of xmlSend)

    Public Shared wAgentVersion As String = Nothing
    Public Shared wAgentServer As String = Nothing
    Public Shared wAgentTCPPort As String = Nothing
    Public Shared wAgentPollPeriod As Integer = 1
    Public Shared wPath As String = Nothing

    'Cryptography
    Public Shared Key As Byte() = System.Text.Encoding.ASCII.GetBytes("abcdefghijklmnop")
    Public Shared IV As Byte() = System.Text.Encoding.ASCII.GetBytes("abcdefghijklmnop")

End Class

Public Class xmlSend
    Public Property wClass As String
    Public Property wParameter As String
    Public Property wValue As String
End Class

Public Class wData
    Public Property wName As String
    Public Property wDate As String
    Public Property wClass As String
    Public Property wProperty As String
    Public Property wInstance As String
    Public Property wValue As String
    '<object name="hostname" date="4/5/2015 12:35:17 AM" class="root\CIMV2\Win32_OperatingSystem" property="BuildNumber" instance="0" value="9600" />
End Class

