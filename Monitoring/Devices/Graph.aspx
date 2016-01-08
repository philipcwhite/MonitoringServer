<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Graph.aspx.vb" Inherits="Devices_Graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
        <h2><asp:HyperLink ID="DevicesHyperLink" runat="server" NavigateUrl="~/Devices/Default.aspx">Devices</asp:HyperLink>&gt;<asp:HyperLink ID="DeviceHyperLink" runat="server"><asp:Label ID="HostNameLabel" runat="server" Text="Device"></asp:Label></asp:HyperLink>&gt;<asp:Label ID="GraphLabel" runat="server" Text="Graph"></asp:Label></h2>
 <br />
       <table class='StaticTable' style='width: 100%'><thead><tr><th>Graphing</th></tr></thead><tr><td style="width:100%;padding-right:40px;padding-left:40px;">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                   <div style="background-color:#ffffff; border-radius:4px;width:100%;text-align:center;font-size:10px">
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
                       <asp:Label ID="ClassLabel" runat="server" Visible="False"></asp:Label>
                       <asp:Label ID="PropertyLabel" runat="server" Visible="False"></asp:Label>
                       <br />
                    </div>
               </ContentTemplate>
           </asp:UpdatePanel>
         
           </td></tr></table>
</asp:Content>

