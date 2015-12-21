<%@ Page Title="" Language="VB" MasterPageFile="~/Options/OptionsMasterPage.master" AutoEventWireup="false" CodeFile="GlobalThresholds.aspx.vb" Inherits="Options_GlobalThresholds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h2>
        <asp:HyperLink ID="OptionsHyperLink" runat="server" NavigateUrl="~/Options/Default.aspx">Options</asp:HyperLink>&gt;Global Thresholds</h2>

    <asp:PlaceHolder ID="ThresholdPlaceHolder" runat="server"></asp:PlaceHolder>
    <br />
     
    <asp:Button ID="RestoreButton" runat="server" Text="Restore Defaults" CssClass="Button" />&nbsp;<asp:Button ID="ReturnButton" runat="server" Text="Return" CssClass="Button" PostBackUrl="~/Options/Default.aspx" />
</asp:Content>

