<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Graph.aspx.vb" Inherits="Devices_Graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
        <h2><asp:HyperLink ID="DevicesHyperLink" runat="server" NavigateUrl="~/Devices/Default.aspx">Devices</asp:HyperLink>&gt;<asp:HyperLink ID="DeviceHyperLink" runat="server"><asp:Label ID="HostNameLabel" runat="server" Text="Device"></asp:Label></asp:HyperLink>&gt;<asp:Label ID="GraphLabel" runat="server" Text="Graph"></asp:Label></h2>
 <br />
       <table class="StaticTable" style="width: 100%">
           <thead><tr><th>Graphing</th></tr></thead>
           <tr><td style="width:100%;padding-right:40px;padding-left:40px;text-align:center">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                   
                  <asp:PlaceHolder ID="GraphPlaceHolder" runat="server"></asp:PlaceHolder>
                       <br />
                      <asp:Label ID="AgentLabel" runat="server" Visible="False"></asp:Label>
                       <asp:Label ID="PropertyLabel" runat="server" Visible="False"></asp:Label>


                         <span style="font-weight:bold;">Time Range:&nbsp;</span>
                           <asp:DropDownList ID="TimeRangeDropDownList" runat="server" CssClass="DropDownList" Width="75px">
                           <asp:ListItem Value="1">1 hour</asp:ListItem>
                           <asp:ListItem Value="6">6 hours</asp:ListItem>
                           <asp:ListItem Value="12">12 hours</asp:ListItem>
                           <asp:ListItem Value="24">24 hours</asp:ListItem>
                       </asp:DropDownList>&nbsp;
                       <asp:Button ID="SubmitButton" runat="server" Text="Graph" CssClass="Button" Width="50px" />&nbsp;
                        <asp:Button ID="csvButton" runat="server" Text="Export" CssClass="Button" Width="50px" />
              
               </ContentTemplate>
               <Triggers>
                   <asp:PostBackTrigger ControlID="csvButton" />
               </Triggers>
           </asp:UpdatePanel>
                         
               <br /><br />
           </td></tr></table>
</asp:Content>

