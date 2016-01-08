<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AddThreshold.aspx.vb" Inherits="Options_AddThreshold" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      
        <h2><asp:HyperLink ID="OptionsHyperLink" runat="server">Configuration</asp:HyperLink>&gt;<asp:HyperLink ID="ThresholdsHyperLink" runat="server" NavigateUrl="~/Options/Thresholds/Default.aspx">Thresholds</asp:HyperLink>&gt;Add Threshold</h2>
    <br />
         <table class='StaticTable' style='width: 450px'><thead><tr><th>Add Threshold</th></tr></thead><tr><td>
         
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>


                      <table style="width:450px">
              <tr>

                  <td>Class:</td>
                  <td>
                      <asp:DropDownList ID="ClassDropDownList" runat="server" Width="150px" AutoPostBack="True" CssClass="TextBox">
                          <asp:ListItem Value="Processor">Processor</asp:ListItem>
                          <asp:ListItem Value="Memory">Memory</asp:ListItem>
                          <asp:ListItem Value="PageFile">Pagefile</asp:ListItem>
                          <asp:ListItem Value="Local Disk">Local Disk</asp:ListItem>
                          <asp:ListItem Value="Services">Services</asp:ListItem>
                      </asp:DropDownList>
                      <asp:DropDownList ID="LDDropDownList" runat="server" Visible="False" CssClass="TextBox">
                          <asp:ListItem Value="A"></asp:ListItem>
                          <asp:ListItem Value="B"></asp:ListItem>
                          <asp:ListItem Value="C">C</asp:ListItem>
                          <asp:ListItem Value="D">D</asp:ListItem>
                          <asp:ListItem Value="E">E</asp:ListItem>
                          <asp:ListItem Value="F">F</asp:ListItem>
                          <asp:ListItem Value="G">G</asp:ListItem>
                          <asp:ListItem Value="H">H</asp:ListItem>
                          <asp:ListItem Value="I">I</asp:ListItem>
                          <asp:ListItem Value="J">J</asp:ListItem>
                          <asp:ListItem Value="K">K</asp:ListItem>
                          <asp:ListItem Value="L">L</asp:ListItem>
                          <asp:ListItem Value="M">M</asp:ListItem>
                          <asp:ListItem Value="N">N</asp:ListItem>
                          <asp:ListItem Value="O">O</asp:ListItem>
                          <asp:ListItem Value="P">P</asp:ListItem>
                          <asp:ListItem Value="Q">Q</asp:ListItem>
                          <asp:ListItem Value="R">R</asp:ListItem>
                          <asp:ListItem Value="S">S</asp:ListItem>
                          <asp:ListItem Value="T">T</asp:ListItem>
                          <asp:ListItem Value="U">U</asp:ListItem>
                          <asp:ListItem Value="V">V</asp:ListItem>
                          <asp:ListItem Value="W">W</asp:ListItem>
                          <asp:ListItem Value="X">X</asp:ListItem>
                          <asp:ListItem Value="Y">Y</asp:ListItem>
                          <asp:ListItem Value="Z">Z</asp:ListItem>
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>

                  <td>Property:</td>
                  <td>
                      <asp:DropDownList ID="PropertyDropDownList" runat="server" CssClass="TextBox" Width="150px">
                      </asp:DropDownList>
                      <asp:TextBox ID="ServicesTextBox" runat="server" CssClass="TextBox" Visible="False"></asp:TextBox>
                  </td>
              </tr>
                            <tr>

                  <td>Operator</td>
                  <td>
                      <asp:DropDownList ID="OperatorDropDownList" runat="server" CssClass="TextBox">
                          <asp:ListItem Value="=" >=</asp:ListItem>
                          <asp:ListItem Value=">">&gt;</asp:ListItem>
                          <asp:ListItem Value=">=">&gt;=</asp:ListItem>
                          <asp:ListItem Value="<">&lt;</asp:ListItem>
                          <asp:ListItem Value="<=">&lt;=</asp:ListItem>
                          <asp:ListItem Value="<>">&lt;&gt;</asp:ListItem>
                      </asp:DropDownList></td>
              </tr>
                            <tr>

                  <td>Threshold:</td>
                  <td>
                      <asp:TextBox ID="ThresholdTextBox" runat="server" CssClass="TextBox" Width="150px" TextMode="Number"></asp:TextBox></td>
              </tr>
                            <tr>

                  <td>Duration (Min.):</td>
                  <td>
                      <asp:TextBox ID="DurationTextBox" runat="server" CssClass="TextBox" Width="150px" TextMode="Number"></asp:TextBox></td>
              </tr>
                            <tr>

                  <td>Severity:</td>
                  <td>
                      <asp:DropDownList ID="SeverityDropDownList" runat="server" CssClass="TextBox" Width="110px">
                          <asp:ListItem Value="3">Critical</asp:ListItem>
                          <asp:ListItem Value="2">Warning</asp:ListItem>
                          <asp:ListItem Value="1">Informational</asp:ListItem>
                      </asp:DropDownList></td>
              </tr>
                          <tr>
                              <td>Enabled:</td>
                              <td>
                                  <asp:RadioButtonList ID="EnabledRadioButtonList" runat="server" RepeatDirection="Horizontal" Width="100px">
                                      <asp:ListItem Value="True" Selected="True">Yes</asp:ListItem>
                                      <asp:ListItem Value="False">No</asp:ListItem>
                                  </asp:RadioButtonList></td>

                          </tr>


              <tr>
                  <td colspan="2">

                      <asp:Label ID="ValidatorLabel" runat="server" ForeColor="Red"></asp:Label>
                  </td>

              </tr>
                            <tr>

                  <td>
                      <asp:Label ID="IDLabel" runat="server" Visible="False"></asp:Label>
                                </td>
                  <td>
                      <asp:Button ID="ReturnButton" runat="server" CssClass="Button" PostBackUrl="~/Config/Thresholds/Default.aspx" Text="Return" UseSubmitBehavior="False" />&nbsp;<asp:Button ID="AddButton" runat="server" CssClass="Button" Text="Add Threshold" />
                                </td>
              </tr>


          </table>

                 </ContentTemplate>
             </asp:UpdatePanel>
             </td>
             </tr>
             </table>

</asp:Content>

