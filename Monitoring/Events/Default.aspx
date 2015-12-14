<%@ Page Title="" Language="VB" MasterPageFile="~/Events/EventsMasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Events_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        Event Management</h2>
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="EventPlaceHolder" runat="server"></asp:PlaceHolder>
            <asp:Timer ID="EventsTimer" runat="server" Interval="10000">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>

    </asp:Content>

