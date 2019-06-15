<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ReportCard.aspx.vb" Inherits="ReportCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <div style="width:100%">
        <div style="margin-left:20%; width:60%; background-color: #0099FF;" class="text-center">

            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="REPORT CARD"></asp:Label>
            <br />
            <span style="color: #FFFFFF"><strong>
            <br />
            STUDENT<br />
            <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" Width="183px"></asp:TextBox>
            <br />
            <br />
            </strong></span>
            <br />

        </div>
        <div style="margin-left:20%; width:60%; background-color: #0099FF;" class="text-center">

            <br />
            <span style="color: #FFFFFF"><strong>ATTENDENCE</strong></span><br />
            <asp:Table ID="Table1" runat="server" GridLines="Both" HorizontalAlign="Center">
            </asp:Table>

            <br />
            <br />
            <span style="color: #FFFFFF"><strong>RESULTS
            <br />
            <asp:Table ID="Table2" runat="server" GridLines="Both" HorizontalAlign="Center" style="color: #000000">
            </asp:Table>

            </strong></span>

            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" BackColor="White" Font-Bold="True" Text="BACK" Width="60%" />
            <br />

        </div>


    </div>
</asp:Content>

