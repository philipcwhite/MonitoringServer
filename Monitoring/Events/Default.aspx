<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Events_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>  
   <h2>Events</h2>
   <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="EventsLeftLegend">
                   <asp:LinkButton ID="OpenLinkButton" runat="server">Open</asp:LinkButton> | 
                   <asp:LinkButton ID="ClosedLinkButton" runat="server">Closed</asp:LinkButton>
            </div>
            <div class="EventsRightLegend">
                <table>
                <tr>
                    <td style="width:10px"><img src="../App_Themes/Monitoring/box-gray.png" style="height:8px;width:8px;" /></td>
                    <td style="width:22px"><asp:LinkButton ID="AllLinkButton" runat="server">All</asp:LinkButton></td>
                    <td style="width:10px"><img src="../App_Themes/Monitoring/box-red.png" style="height:8px;width:8px;" /></td>
                    <td style="width:40px"><asp:LinkButton ID="CriticalLinkButton" runat="server">Critical</asp:LinkButton></td>
                    <td style="width:10px"><img src="../App_Themes/Monitoring/box-yellow.png" style="height:8px;width:8px;" /></td>
                    <td style="width:45px"><asp:LinkButton ID="WarningLinkButton" runat="server">Warning</asp:LinkButton></td>
                    <td style="width:10px"><img src="../App_Themes/Monitoring/box-aqua.png" style="height:8px;width:8px;" /></td>
                    <td style="width:23px"><asp:LinkButton ID="InfoLinkButton" runat="server">Info</asp:LinkButton></td>
              </tr>
                </table>
            </div>
            <br />
            <br />
            <br />
            <asp:PlaceHolder ID="EventPlaceHolder" runat="server"></asp:PlaceHolder>
            <br />
            <div class="EventsTotalLegend">
                <asp:Label ID="TotalLabel" runat="server" Text="Total"></asp:Label></div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Timer ID="EventsTimer" runat="server" Interval="30000">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>

    </asp:Content>

