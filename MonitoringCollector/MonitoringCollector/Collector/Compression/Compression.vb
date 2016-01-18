Imports System.IO

Public Class Compression

    Public Function CompressedData(ByVal Text As String) As String

        Dim Buffer As Byte() = System.Text.Encoding.Unicode.GetBytes(Text)
        Dim mStream As New MemoryStream()
        Using GZipStream As New IO.Compression.GZipStream(mStream, IO.Compression.CompressionMode.Compress, True)
            GZipStream.Write(Buffer, 0, Buffer.Length)
        End Using
        mStream.Position = 0
        Dim outStream As New MemoryStream()
        Dim Compressed As Byte() = New Byte(mStream.Length - 1) {}
        mStream.Read(Compressed, 0, Compressed.Length)
        Dim GZipBuffer As Byte() = New Byte(Compressed.Length + 3) {}
        System.Buffer.BlockCopy(Compressed, 0, GZipBuffer, 4, Compressed.Length)
        System.Buffer.BlockCopy(BitConverter.GetBytes(Buffer.Length), 0, GZipBuffer, 0, 4)
        Return Convert.ToBase64String(GZipBuffer)

    End Function

    Public Function DecompressData(ByVal CompressedText As String) As String

        Dim GZipBuffer As Byte() = Convert.FromBase64String(CompressedText)

        Using mStream As New MemoryStream()
            Dim msgLength As Integer = BitConverter.ToInt32(GZipBuffer, 0)
            mStream.Write(GZipBuffer, 4, GZipBuffer.Length - 4)
            Dim Buffer As Byte() = New Byte(msgLength - 1) {}
            mStream.Position = 0
            Using GZipStream As New System.IO.Compression.GZipStream(mStream, IO.Compression.CompressionMode.Decompress)
                GZipStream.Read(Buffer, 0, Buffer.Length)
            End Using
            Return Text.Encoding.Unicode.GetString(Buffer, 0, Buffer.Length)
        End Using
    End Function

End Class

