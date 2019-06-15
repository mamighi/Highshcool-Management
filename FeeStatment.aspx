<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="FeeStatment.aspx.vb" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <div style="width:100%">
            <div style="margin-left:20%; width:60%; background-color: #0099FF;" class="text-center">
           
                <br />
                <br />
                <strong>
                <asp:Label ID="Label2" runat="server" style="font-size: large; color: #FFFFFF" Text="PAYMENT"></asp:Label>
                <br />
                <br />
                <span style="color: #FFFFFF">STUDENT</span><br />
                <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True" Width="40%"></asp:TextBox>
                </strong>
                <br />
                <br />
                <span style="color: #FFFFFF"><strong>TIUTION FEE</strong></span><br />
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" Width="40%"></asp:TextBox>
                <br />
                <br />
                <span style="color: #FFFFFF"><strong>OTHER FEES</strong></span><asp:Table ID="Table1" runat="server" CellPadding="1" CellSpacing="1" GridLines="Both" HorizontalAlign="Center" Width="40%">
                </asp:Table>
                <br />
                <span style="color: #FFFFFF"><strong>TOTAL PAYABLE<br />
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Width="40%"></asp:TextBox>
                <br />
                <br />
                TOTAL PAYMENTS<br />
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True" Width="40%"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" BackColor="White" Font-Bold="True" Text="BACK" Width="40%" />
                <br />
                <br />
                <br />
                <br />
                </strong></span>
           
            </div>
       </div>
</asp:Content>

