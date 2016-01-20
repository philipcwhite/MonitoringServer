<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AgentThreshold.aspx.vb" Inherits="Config_Thresholds_AgentThreshold" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Configuration&gt;Agent Thresholds</h2>
      <br />
    <asp:PlaceHolder ID="ThresholdPlaceHolder" runat="server"></asp:PlaceHolder>
    <br />
    <asp:Button ID="AddThresholdButton" runat="server" Text="Add" CssClass="Button" Width="100px" />&nbsp;<asp:Button ID="ReturnButton" runat="server" Text="Return" CssClass="Button" Width="100px" />
<br />
    <br />
    <br />
    <br />

</asp:Content>

