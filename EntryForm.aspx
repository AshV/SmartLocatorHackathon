<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntryForm.aspx.cs" Inherits="EntryForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
        .auto-style2
        {
        }
        .auto-style3
        {
            width: 239px;
        }
        .auto-style4
        {
            height: 34px;
        }
        .auto-style5
        {
            width: 231px;
            height: 34px;
        }
        .auto-style6
        {
            width: 239px;
            height: 34px;
        }
        .auto-style7
        {
            height: 325px;
        }
        .auto-style9
        {
            width: 222px;
        }
        .auto-style10
        {
            width: 222px;
            height: 34px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style4"></td>
                <td class="auto-style5">
                </td>
                <td class="auto-style6">
                </td>
                <td class="auto-style10"></td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">Longitude<br />
                    <asp:TextBox ID="tbLong" runat="server">78.4691053</asp:TextBox>
                </td>
                <td class="auto-style3">Latitude<br />
                    <asp:TextBox ID="tbLatitude" runat="server">17.4059416</asp:TextBox>
                </td>
                <td class="auto-style9">Amount of Time Stayed<br />
                    <asp:TextBox ID="tbAmntTime" runat="server">20</asp:TextBox>
                </td>
                <td class="auto-style9">Current Time<br />
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="07:00">Morning</asp:ListItem>
                        <asp:ListItem Value="14:00">Afternoon</asp:ListItem>
                        <asp:ListItem Value="12:00">Noon</asp:ListItem>
                        <asp:ListItem Value="18:00">Evening</asp:ListItem>
                        <asp:ListItem Value="20:00">Night</asp:ListItem>
                        <asp:ListItem Value="10:00">Late Night</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="Button1" runat="server" Text="Visit" OnClick="Button1_Click" />
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style7" colspan="3">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style7"></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
