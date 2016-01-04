<%@ Page Title="" Language="VB" MasterPageFile="~/Events/EventsMasterPage.master" AutoEventWireup="false" CodeFile="MyEvents.aspx.vb" Inherits="Events_MyEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>  
    <table style="width:100%;padding-bottom:10px;padding-right:0px">
        <tr>
        <td style="text-align:left;vertical-align:top;color:#485385;font-size:10pt;font-weight:bold">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Events/Default.aspx">Events</asp:HyperLink>&gt;My Events</td>
        <td style="text-align:right"><asp:Button ID="EventsButton" runat="server" Text="Events" CssClass="Button" PostBackUrl="~/Events/Default.aspx" /></td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="EventPlaceHolder" runat="server"></asp:PlaceHolder>
            <asp:Timer ID="EventsTimer" runat="server" Interval="10000">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>

    </asp:Content>

