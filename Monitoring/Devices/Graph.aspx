<%@ Page Title="" Language="VB" MasterPageFile="~/Devices/DevicesMasterPage.master" AutoEventWireup="false" CodeFile="Graph.aspx.vb" Inherits="Devices_Graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <table style="width:100%;padding-bottom:10px;padding-right:0px">
        <tr>
        <td style="text-align:left;vertical-align:top;color:#485385;font-size:10pt;font-weight:bold"><asp:HyperLink ID="DevicesHyperLink" runat="server" NavigateUrl="~/Devices/Default.aspx">Devices</asp:HyperLink>&gt;<asp:HyperLink ID="DeviceHyperLink" runat="server"><asp:Label ID="HostNameLabel" runat="server" Text="Device"></asp:Label></asp:HyperLink>&gt;<asp:Label ID="GraphLabel" runat="server" Text="Graph"></asp:Label></td>
        <td style="text-align:right"><asp:Button ID="DevicesButton" runat="server" Text="Devices" CssClass="Button" PostBackUrl="~/Devices/Default.aspx" /></td>
        </tr>
        </table>
       <table class='StaticTable' style='width: 100%'><thead><tr><th>Graphing</th></tr></thead><tr><td style="width:100%;padding-right:40px;padding-left:40px;">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                   <div style="background-color:#ffffff; border-radius:4px;width:100%;text-align:center">
                  <asp:PlaceHolder ID="GraphPlaceHolder" runat="server"></asp:PlaceHolder>
                       <br />
                       Time Range: 
                       <asp:DropDownList ID="TimeRangeDropDownList" runat="server">
                           <asp:ListItem Value="1">1 Hour</asp:ListItem>
                           <asp:ListItem Value="6">6 Hours</asp:ListItem>
                           <asp:ListItem Value="12">12 Hours</asp:ListItem>
                           <asp:ListItem Value="24">24 Hours</asp:ListItem>
                       </asp:DropDownList>
                       <asp:Button ID="SubmitButton" runat="server" Text="Graph" CssClass="Button" />
                       <br />
                       <br />
                    </div>
               </ContentTemplate>
           </asp:UpdatePanel>
         
           </td></tr></table>
</asp:Content>

