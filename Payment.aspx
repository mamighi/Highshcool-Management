<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Payment.aspx.vb" Inherits="Payment" %>

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
                </strong>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="40%">
                </asp:DropDownList>
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
                NEW PAYMENT AMOUNT<br />
                <asp:TextBox ID="TextBox4" runat="server" Width="40%"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="ERROR" Visible="False"></asp:Label>
                <br />
                <asp:Button ID="Button1" runat="server" BackColor="White" Font-Bold="True" Text="PAY" Width="40%" />
                <br />
                </strong></span>
                <br />
                <span style="color: #FFFFFF"><strong>NEW CHARGE AMOUNT</strong></span><br />
                <span style="color: #FFFFFF"><strong>
                <asp:TextBox ID="TextBox5" runat="server" Width="40%"></asp:TextBox>
                <br />
                <br />
                NEW CHARGE DESCRIPTION</strong></span><br />
                <span style="color: #FFFFFF"><strong>
                <asp:TextBox ID="TextBox6" runat="server" Width="40%"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="ERROR" Visible="False"></asp:Label>
                <br />
                <asp:Button ID="Button2" runat="server" BackColor="White" Font-Bold="True" Text="ADD" Width="40%" />
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

