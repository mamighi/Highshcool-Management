<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PublishResults.aspx.vb" Inherits="PublishResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <div style="width:100%">
        <div style="margin-left:20%; width:60%; background-color: #0099FF;" class="text-center">

            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="PUBLISH RESULT"></asp:Label>
            <br />
            <br />
            <span style="color: #FFFFFF"><strong>INTAKE<br />
            <asp:DropDownList ID="DropDownList1" runat="server" Width="50%" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            MODULE<br />
            <asp:DropDownList ID="DropDownList2" runat="server" Width="50%">
            </asp:DropDownList>
            </strong></span>
            <br />

        </div>
        <div style="margin-left:20%; width:60%; background-color: #0099FF;" class="text-center">

            <br />
            <asp:Table ID="Table1" runat="server" GridLines="Both" HorizontalAlign="Center" ViewStateMode="Enabled">
            </asp:Table>

            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Text="ERROR" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" BackColor="White" Font-Bold="True" Text="SUBMIT" Width="60%" UseSubmitBehavior="False" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" BackColor="White" Font-Bold="True" Text="BACK" Width="60%" />
            <br />

        </div>


    </div>
</asp:Content>

