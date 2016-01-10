<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GlobalThresholds.aspx.vb" Inherits="Options_GlobalThresholds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
        <h2><asp:HyperLink ID="OptionsHyperLink" runat="server" NavigateUrl="~/Config/Default.aspx">Configuration</asp:HyperLink>&gt;Thresholds</h2>
  <br />
    <asp:PlaceHolder ID="ThresholdPlaceHolder" runat="server"></asp:PlaceHolder>
    <br />
    <asp:Button ID="AddThresholdButton" runat="server" Text="Add Threshold" CssClass="Button" PostBackUrl="~/Config/Thresholds/GlobalThresholdsAdd.aspx" />&nbsp;<asp:Button ID="RestoreButton" runat="server" Text="Restore Defaults" CssClass="Button" />&nbsp;<asp:Button ID="ReturnButton" runat="server" Text="Return" CssClass="Button" PostBackUrl="~/Config/Default.aspx" />
<br />
    <br />
    <br />
    <br />

</asp:Content>

