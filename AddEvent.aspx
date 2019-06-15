<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="AddEvent.aspx.vb" Inherits="AddEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
        <div>

    <div style="margin-left:25%; width:50%; background-color: #0099FF;" class="text-center">
            <br />
            <br />
            <strong>
            <asp:Label ID="Label2" runat="server" style="font-size: x-large; color: #FFFFFF" Text="ADD EVENT"></asp:Label>
            </strong>
            <br />
            <strong><span style="color: #FFFFFF">
            <br />
            INTAKE CODE<br />
            </span>
            <asp:TextBox ID="TextBox1" runat="server" Width="60%"></asp:TextBox>
            <br />
            <br />
            <span style="color: #FFFFFF">DESCRIPTION<br />
            <asp:TextBox ID="TextBox2" runat="server" Width="60%" Height="71px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            DATE<br />
            <div class="text-right">
                <asp:Calendar ID="Calendar1" runat="server" Width="100%"></asp:Calendar>
            </div>
            </span>
            <br />
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
            <br />
            <br />

        </div>

    </div>

</asp:Content>

