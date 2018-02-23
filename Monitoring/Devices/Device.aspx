<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Device.aspx.vb" Inherits="Device" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       
        <h2><asp:HyperLink ID="DevicesHyperLink" runat="server" NavigateUrl="~/Devices/Default.aspx">Devices</asp:HyperLink>&gt;<asp:Label ID="HostNameLabel" runat="server" Text="Device"></asp:Label></h2>
 <br />
                 
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
               
                  <asp:PlaceHolder ID="PerformancePlaceHolder" runat="server"></asp:PlaceHolder>
                   <br />
                   <asp:PlaceHolder ID="SystemPlaceHolder" runat="server"></asp:PlaceHolder>
                   <br />
                   <asp:PlaceHolder ID="DiskPlaceHolder" runat="server"></asp:PlaceHolder>
                   <br />
                   <asp:PlaceHolder ID="NetworkPlaceHolder" runat="server"></asp:PlaceHolder>
                   <asp:Timer ID="Timer1" runat="server">
                   </asp:Timer>
                      

                      </ContentTemplate>
               <Triggers>
                  
               </Triggers>
           </asp:UpdatePanel>

    <br />
    <div style="text-align:right">
    <asp:button runat="server" text="Windows Services" ID="ServicesButton" CssClass="Button" />&nbsp;
    <asp:button runat="server" text="Agent Thresholds" ID="ThresholdButton" CssClass="Button" Visible="False" />
    </div>
</asp:Content>

