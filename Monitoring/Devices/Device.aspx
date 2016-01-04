<%@ Page Title="" Language="VB" MasterPageFile="~/Devices/DevicesMasterPage.master" AutoEventWireup="false" CodeFile="Device.aspx.vb" Inherits="Devices_Device" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="width:100%;padding-bottom:10px;padding-right:2px">
        <tr>
        <td style="text-align:left;vertical-align:top;color:#485385;font-size:10pt;font-weight:bold"><asp:HyperLink ID="DevicesHyperLink" runat="server" NavigateUrl="~/Devices/Default.aspx">Devices</asp:HyperLink>&gt;<asp:Label ID="HostNameLabel" runat="server" Text="Device"></asp:Label></td>
        <td style="text-align:right"><asp:Button ID="DevicesButton" runat="server" Text="Devices" CssClass="Button" PostBackUrl="~/Devices/Default.aspx" /></td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="DevicePlaceHolder" runat="server"></asp:PlaceHolder>
            <asp:Timer ID="DeviceTimer" runat="server"></asp:Timer>
        </ContentTemplate>
       
    </asp:UpdatePanel>
</asp:Content>

