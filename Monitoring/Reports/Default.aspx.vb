
Partial Class Reports_Default
    Inherits System.Web.UI.Page

    Protected Sub webButton1_Click(sender As Object, e As EventArgs) Handles webButton1.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=1&Type=web")
    End Sub

    Protected Sub csvButton1_Click(sender As Object, e As EventArgs) Handles csvButton1.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=1&Type=csv")
    End Sub

    Protected Sub web2Button_Click(sender As Object, e As EventArgs) Handles web2Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=2&Type=web")
    End Sub

    Protected Sub csv2Button_Click(sender As Object, e As EventArgs) Handles csv2Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=2&Type=csv")
    End Sub

    Protected Sub web3Button_Click(sender As Object, e As EventArgs) Handles web3Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=3&Type=web")
    End Sub

    Protected Sub csv3Button_Click(sender As Object, e As EventArgs) Handles csv3Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=3&Type=csv")
    End Sub

    Protected Sub web4Button_Click(sender As Object, e As EventArgs) Handles web4Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=4&Type=web")
    End Sub
    Protected Sub csv4Button_Click(sender As Object, e As EventArgs) Handles csv4Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=4&Type=csv")
    End Sub
    Protected Sub web5Button_Click(sender As Object, e As EventArgs) Handles web5Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=5&Type=web")
    End Sub
    Protected Sub csv5Button_Click(sender As Object, e As EventArgs) Handles csv5Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=5&Type=csv")
    End Sub
    Protected Sub web6Button_Click(sender As Object, e As EventArgs) Handles web6Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=6&Type=web")
    End Sub
    Protected Sub csv6Button_Click(sender As Object, e As EventArgs) Handles csv6Button.Click
        Response.Redirect("~/Reports/Reports.aspx?ReportID=6&Type=csv")
    End Sub
End Class
