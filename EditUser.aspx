<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="EditUser.aspx.vb" Inherits="EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="margin-left:0; width:100%">
        <div style="margin-left:10%; width:80%; background-color: #0099FF;" class="text-center">

            <br />
            <br />
            <strong>
            <asp:Label ID="Label2" runat="server" style="font-size: large; color: #FFFFFF" Text="ADD NEW USER"></asp:Label>
            </strong>
            <div style="width:100%; background-color: #0099FF; float:left">
                <div style="width:50%; float:left; background-color: #0099FF; " class="text-center">

                    <br />
                    <br />
&nbsp;<strong><span style="color: #FFFFFF">USER NAME<br />
                    <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" Width="70%">
                    </asp:DropDownList>
                    <br />
                    <br />
                    FIRST NAME<br />
                    <asp:TextBox ID="TextBox2" runat="server" Width="70%"></asp:TextBox>
                    <br />
                    <br />
                    LAST NAME<br />
                    <asp:TextBox ID="TextBox3" runat="server" Width="70%"></asp:TextBox>
                    <br />
                    <br />
                    PASSWORD<br />
                    <asp:TextBox ID="TextBox4" runat="server" Width="70%" TextMode="Password"></asp:TextBox>
                    <br />
                    <br />
                    RE PASSWORD<br />
                    <asp:TextBox ID="TextBox5" runat="server" Width="70%" TextMode="Password"></asp:TextBox>
                    <br />
                    <br />
                    USER TYPE<br />
                    <asp:TextBox ID="TextBox6" runat="server" Width="70%" ReadOnly="True"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="ERROR" Visible="False"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" BackColor="White" Font-Bold="True" Text="UPDATE" Width="70%" />
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" BackColor="White" Font-Bold="True" Text="BACK" Width="70%" />
                    </span></strong>
                    <br />
                    <br />

                </div>
                <div style="width:50%; float:left; height:100%;bottom:0; background-color: #0099FF;">



                    <strong>
                    <br />
                    <br style="color: #FFFFFF" />
                    <span style="color: #FFFFFF">
                    <asp:Label ID="Label5" runat="server" Text="INTAKE" Visible="False"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="70%" ValidateRequestMode="Enabled" Visible="False">
                        <asp:ListItem>INTAKES</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="STUDENT" Visible="False"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="70%" ValidateRequestMode="Enabled" Visible="False">
                        <asp:ListItem>STUDENTS</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    </span></strong>



                </div>
            </div>


        </div>
    </div>
</asp:Content>

