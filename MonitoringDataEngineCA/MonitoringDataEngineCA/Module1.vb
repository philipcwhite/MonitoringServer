Module Module1

    Sub Main()
        Dim MAgents As New MoveAgents
        MAgents.QueryDatabase()
        MAgents.InsertAgents()
        MAgents.UpdateAgents()

        Dim MAgentData As New MoveAgentData
        MAgentData.QueryDataBase()
        MAgentData.InsertAgentData()

    End Sub

End Module
