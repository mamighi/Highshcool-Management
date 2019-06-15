<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="EditModule.aspx.vb" Inherits="EditModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>

    <div style="margin-left:25%; width:50%; background-color: #0099FF;" class="text-center">
            <br />
            <br />
            <strong>
            <asp:Label ID="Label2" runat="server" style="font-size: x-large; color: #FFFFFF" Text="ADD MODULE"></asp:Label>
            </strong>
            <br />
            <br />
            <strong><span style="color: #FFFFFF">MODULE CODE<br />
            <asp:DropDownList ID="DropDownList5" runat="server" Width="60%" AutoPostBack="True">
            </asp:DropDownList>
            </span>
            <br />
            <br />
            <span style="color: #FFFFFF">MODULE NAME<br />
            <asp:TextBox ID="TextBox2" runat="server" Width="60%" ReadOnly="True"></asp:TextBox>
            </span></strong>
            <br />

            <br />
            <strong><span style="color: #FFFFFF">LECTURER<br />
            </span>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="60%">
            </asp:DropDownList>
            <br />
            <br />
            <span style="color: #FFFFFF">INTAKE<br />
            <asp:DropDownList ID="DropDownList4" runat="server" Width="60%">
            </asp:DropDownList>
            </span>
            <br />
            <br />
            <span style="color: #FFFFFF">DAY</span><br />
            <asp:DropDownList ID="DropDownList2" runat="server" ValidateRequestMode="Enabled" Width="60%">
                <asp:ListItem>MONDAY</asp:ListItem>
                <asp:ListItem>TUESDAY</asp:ListItem>
                <asp:ListItem>WEDNESDAY</asp:ListItem>
                <asp:ListItem>THURSDAY</asp:ListItem>
                <asp:ListItem>FRIDAY</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <span style="color: #FFFFFF">DURATION</span><br />
            <asp:DropDownList ID="DropDownList3" runat="server" Width="60%">
                <asp:ListItem>00:30</asp:ListItem>
                <asp:ListItem>01:00</asp:ListItem>
                <asp:ListItem>01:30</asp:ListItem>
                <asp:ListItem>02:00</asp:ListItem>
                <asp:ListItem>02:30</asp:ListItem>
                <asp:ListItem>03:00</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="ERROR" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" BackColor="White" Font-Bold="True" Text="SUBMIT" Width="60%" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" BackColor="White" Font-Bold="True" Text="BACK" Width="60%" />
            <br />
            <br />
            </strong>
            <br />
            <br />
            <br />

        </div>

    </div>
</asp:Content>

