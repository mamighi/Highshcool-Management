<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="AdminHome.aspx.vb" Inherits="AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="margin-left:0; width:100%">
        <div style="margin-left:25%; width:50%; background-color: #0099FF;" class="text-center">
            <br />
            <br />
            <strong>
            <asp:Label ID="Label2" runat="server" style="font-size: x-large; color: #FFFFFF" Text="Label"></asp:Label>
            </strong>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="ADD NEW USER" BackColor="White" Font-Bold="True" Width="80%" />

            <br />
            <br />
            <asp:Button ID="Button2" runat="server" BackColor="White" Font-Bold="True" Text="UPDATE/DELETE USER" Width="80%" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" BackColor="White" Font-Bold="True" Text="ADD MODULE" Width="80%" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" BackColor="White" Font-Bold="True" Text="EDIT MODULE" Width="80%" />
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" BackColor="White" Font-Bold="True" Text="ADD INTAKE" Width="80%" />
            <br />
            <br />
            <asp:Button ID="Button6" runat="server" BackColor="White" Font-Bold="True" Text="EDIT INTAKE" Width="80%" />
            <br />
            <br />
            <asp:Button ID="Button7" runat="server" BackColor="White" Font-Bold="True" Text="ATTENDENCE" Width="80%" />
            <br />
            <br />
            <asp:Button ID="Button8" runat="server" BackColor="White" Font-Bold="True" Text="PAYMENT" Width="80%" />
            <br />
            <br />
            <asp:Button ID="Button9" runat="server" BackColor="White" Font-Bold="True" Text="PUBLISH RESULTS" Width="80%" />
            <br />
            <br />
            <asp:Button ID="Button10" runat="server" BackColor="White" Font-Bold="True" Text="STUDENT REPORT CARD" Width="80%" />
            <br />
            <br />
            <asp:Button ID="Button11" runat="server" BackColor="White" Font-Bold="True" Text="LOG OUT" Width="80%" />
            <br />
            <br />

        </div>

    </div>
</asp:Content>

