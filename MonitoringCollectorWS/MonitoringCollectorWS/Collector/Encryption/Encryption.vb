Imports MonitoringCollectorWS.Server.ServerParameters
Imports System.Security.Cryptography


Public Class Encryption


    Public AES As New AesCryptoServiceProvider

    Public Function EncryptData(ByVal plaintext As String) As String

        Dim plaintextBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(plaintext)
        Dim ms As New System.IO.MemoryStream
        Dim encStream As New CryptoStream(ms, AES.CreateEncryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Write)
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        Dim x As String = Convert.ToBase64String(ms.ToArray)

        Return x
    End Function

    Public Function DecryptData(ByVal encryptedtext As String) As String

        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        Dim ms As New System.IO.MemoryStream
        Dim decStream As New CryptoStream(ms, AES.CreateDecryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Write)
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        Return System.Text.Encoding.ASCII.GetString(ms.ToArray)
    End Function


End Class

