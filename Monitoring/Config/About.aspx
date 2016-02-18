<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="About.aspx.vb" Inherits="Config_About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Config/Default.aspx">Configuration</asp:HyperLink>&gt;About</h2>
    <br />
    <table class="StaticTable">
        <tr>
            <th>Monitoring Server</th>
        </tr>
        <tr>
            <td>
                Monitoring Server 0.6.5B<br />
                GitHub Project Page: <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="https://github.com/philipcwhite">https://github.com/philipcwhite</asp:HyperLink><br />
                Copyright 2016 Phil White, PCW Soft<br />
            </td>
        </tr>
    </table>
</asp:Content>

