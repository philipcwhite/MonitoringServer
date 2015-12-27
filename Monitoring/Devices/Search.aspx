<%@ Page Title="" Language="VB" MasterPageFile="~/Devices/DevicesMasterPage.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Devices_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h2>
        <asp:HyperLink ID="OptionsHyperLink" runat="server" NavigateUrl="~/Devices/Default.aspx">Devices</asp:HyperLink>&gt;Search</h2>
    
  
        <table class='StaticTable' style='width: 100%'><thead><tr><th>Search</th></tr></thead><tr><td style="text-align:center">
       
            <table style="width:600px">
                <tr><td>You Searched For: <asp:Label ID="SearchLabel" runat="server" Text=""></asp:Label></td></tr>
                <tr><td>

                    <asp:PlaceHolder ID="ResultsPlaceHolder" runat="server"></asp:PlaceHolder>

                </td></tr>
            </table>

            </td>
            </tr>
            </table>

</asp:Content>

