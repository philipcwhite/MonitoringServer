<%@ Page Title="" Language="VB" MasterPageFile="~/Devices/DevicesMasterPage.master" AutoEventWireup="false" CodeFile="MyDevices.aspx.vb" Inherits="Devices_MyDevices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="width:100%;padding-bottom:10px;padding-right:0px">
        <tr>
        <td style="text-align:left;vertical-align:top;color:#485385;font-size:10pt;font-weight:bold"><asp:HyperLink ID="DevicesHyperLink" runat="server" NavigateUrl="~/Devices/Default.aspx">Devices</asp:HyperLink>&gt;<asp:Label ID="HostNameLabel" runat="server" Text="Device"></asp:Label></td>
        <td style="text-align:right"><asp:Button ID="DevicesButton" runat="server" Text="Devices" CssClass="Button" PostBackUrl="~/Devices/Default.aspx" /></td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server">
            </asp:Timer>
            <asp:PlaceHolder ID="DevicesPlaceHolder" runat="server"></asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

