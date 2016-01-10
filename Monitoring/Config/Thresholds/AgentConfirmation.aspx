<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AgentConfirmation.aspx.vb" Inherits="Config_Thresholds_AgentConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <h2> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Config/Default.aspx">Configuration</asp:HyperLink>&gt;Agent Confirmation</h2>

    <br />
         <table class='StaticTable' style='width: 100%'><thead><tr><th>Confirmation</th></tr></thead><tr><td style="text-align:center">

    <br />
             Are you sure you want to delete this threshold?<br />
             <asp:Label ID="ValueLabel" runat="server" Text="" Visible="False"></asp:Label>
             <br />

    <asp:Button ID="ReturnButton" runat="server" Text="Return" CssClass="Button" PostBackUrl="~/Config/Default.aspx" />&nbsp;<asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="Button" />
<br />

             </td></tr></table>

</asp:Content>

