<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Reports_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Reports</h2>
    <br />
    <table class='HoverTable' style="width:100%">
        <thead>
            <tr>
            <th>Report Name</th>
            <th>Report Description</th>
            <th style="width:50px;"></th>
            </tr>
                    </thead>
              <tr>
                <td>Agent Device Report</td>
                <td>Export basic system information on all hosts</td>
                <td>
                    <asp:Button ID="webButton1" runat="server" Text="web" CssClass="ReportButton" />&nbsp;<asp:Button ID="csvButton1" runat="server" Text="csv" CssClass="ReportButton" /></td>
            </tr>
             <tr>
                <td>Agent Event Report</td>
                <td>Export all open agent events</td>
                <td><asp:Button ID="web2Button" runat="server" Text="web" CssClass="ReportButton" />&nbsp;<asp:Button ID="csv2Button" runat="server" Text="csv" CssClass="ReportButton" /></td>
            </tr>
            <tr>
                <td>Agent Performance Report (1 hour)</td>
                <td>Average performace summary for all hosts (1 hour)</td>
                <td><asp:Button ID="web3Button" runat="server" Text="web" CssClass="ReportButton" />&nbsp;<asp:Button ID="csv3Button" runat="server" Text="csv" CssClass="ReportButton" /></td>
            </tr>
                <tr>
                <td>Agent Performance Report (1 day)</td>
                <td>Average performace summary for all hosts (1 day)</td>
                <td><asp:Button ID="web4Button" runat="server" Text="web" CssClass="ReportButton" />&nbsp;<asp:Button ID="csv4Button" runat="server" Text="csv" CssClass="ReportButton" /></td>
            </tr>
                <tr>
                <td>Agent Performance Report (Previous 7 days)</td>
                <td>Average performace summary for all hosts (Previous 7 days)</td>
                <td><asp:Button ID="web5Button" runat="server" Text="web" CssClass="ReportButton" />&nbsp;<asp:Button ID="csv5Button" runat="server" Text="csv" CssClass="ReportButton" /></td>
            </tr>
                <tr>
                <td>Agent Performance Report (Previous 30 days)</td>
                <td>Average performace summary for all hosts (Previous 30 days)</td>
                <td><asp:Button ID="web6Button" runat="server" Text="web" CssClass="ReportButton" />&nbsp;<asp:Button ID="csv6Button" runat="server" Text="csv" CssClass="ReportButton" /></td>
            </tr>
        </table>
</asp:Content>

