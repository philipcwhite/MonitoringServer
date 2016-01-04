<%@ Page Title="" Language="VB" MasterPageFile="~/Options/OptionsMasterPage.master" AutoEventWireup="false" CodeFile="UpdateProfile.aspx.vb" Inherits="Options_UpdateProfile"  UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="width:100%;padding-bottom:10px;padding-right:0px">
        <tr>
        <td style="text-align:left;vertical-align:top;color:#485385;font-size:10pt;font-weight:bold"><asp:HyperLink ID="OptionsHyperLink" runat="server" NavigateUrl="~/Options/Default.aspx">Options</asp:HyperLink>&gt;Update Profile</td>
        <td style="text-align:right"><asp:Button ID="OptionsButton" runat="server" Text="Options" CssClass="Button" PostBackUrl="~/Options/Default.aspx" /></td>
        </tr>
    </table>
        <table class='StaticTable' style='width: 100%'><thead><tr><th>Update Profile</th></tr></thead><tr><td>
          
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                        <table style="width:500px">
        <tr>
            <td>User Name:</td>
            <td>
                <asp:TextBox ID="UserNameTextBox" runat="server" Enabled="False" Width="100px" CssClass="TextBox" BackColor="#EFEFEF"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Reset Password</td>
            
            <td>
                <asp:RadioButtonList ID="PasswordRadioButtonList" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="100px">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

                </td>
        </tr>


                <tr>
            <td>New Password:</td>
            <td>
 <asp:TextBox ID="NewPasswordTextBox" runat="server" TextMode="Password" Width="100px"  Enabled="False"  CssClass="TextBox" BackColor="#EFEFEF"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td>First Name:</td>
            <td> <asp:TextBox ID="FirstNameTextBox" runat="server" Width="100px" CssClass="TextBox"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td>Last Name:</td>
            <td> <asp:TextBox ID="LastNameTextBox" runat="server" Width="100px" CssClass="TextBox"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td>Email Address:</td>
            <td> <asp:TextBox ID="EmailAddressTextBox" runat="server" Width="170px" CssClass="TextBox"></asp:TextBox>
                    </td>
        
        </tr>
                <tr>
            <td></td>
            <td><asp:Label ID="StatusLabel" runat="server" ForeColor="Red"></asp:Label> </td>
      
        </tr>
        <tr>
           <td colspan="2">
               <asp:Button ID="ReturnButton" runat="server" Text="Return" CssClass="Button"  /> &nbsp;<asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="Button" /></td>

        
        </tr>
        </table>

                </ContentTemplate>


            </asp:UpdatePanel>
            



    </td></tr></table>
</asp:Content>

