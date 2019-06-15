<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <strong>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="LOGIN" style="font-size: xx-large"></asp:Label>



        <br />
        <br />
        USER NAME<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="207px"></asp:TextBox>
        <br />
        <br />
        PASSWORD<br />
        <asp:TextBox ID="TextBox2" runat="server" Width="207px" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="ERROR" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Font-Bold="True" Text="SIGN IN" Width="159px" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        </strong>



    </div>


</asp:Content>
