<%@ Page Title="" Language="VB" MasterPageFile="~/Devices/DevicesMasterPage.master" AutoEventWireup="false" CodeFile="Device.aspx.vb" Inherits="Devices_Device" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="DevicePlaceHolder" runat="server"></asp:PlaceHolder>
            <asp:Timer ID="DeviceTimer" runat="server"></asp:Timer>
        </ContentTemplate>
       
    </asp:UpdatePanel>
</asp:Content>

