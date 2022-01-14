<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchingWebForm.aspx.cs" Inherits="EFProject.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:black">
    
    <form id="form1" runat="server" style="font-family:Arial; color:aliceblue; padding-left:300px; padding-right:300px">
            <asp:Button ID="Backwards" runat="server" Text="Go back" postbackurl ="~/HomePage.aspx"/>
        <div style="border: 1px aquamarine solid; padding: 10px; vertical-align:central; background-color:dimgray">
            <h1 style="text-align:center">Searching</h1>
            <div style="padding:30px; text-align:center;">
                <asp:DropDownList ID="DropDownList" runat="server" BackColor="Aquamarine">
                <asp:ListItem>Region</asp:ListItem>
                <asp:ListItem>Municipality</asp:ListItem>
                <asp:ListItem>Settlement</asp:ListItem>
            </asp:DropDownList>
                <asp:DropDownList ID="SearchDropDown" runat="server" BackColor="Aquamarine">
                <asp:ListItem>Name</asp:ListItem>
                <asp:ListItem>StartsWith</asp:ListItem>
                <asp:ListItem>Contains</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="SearchTextBox" runat="server" BackColor="Aquamarine" BorderColor="White" BorderStyle="Inset"></asp:TextBox>

            <asp:Button ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" BackColor="White" Height="30px" Width="200px" />

            <asp:Label ID="Label1" runat="server" Text="This name can not be found!!" Visible="False"></asp:Label>
            <br />
            </div>
            <div style="padding:20px; text-align:center;">
                <asp:ListBox ID="RegionListBox" runat="server" Height="100" Width="100" BackColor="Aquamarine"></asp:ListBox>
                <asp:ListBox ID="MunicipalityListBox" runat="server" Height="100" Width="100" BackColor="Aquamarine"></asp:ListBox>
                <asp:ListBox ID="SettlementsListBox" runat="server" Height="100" Width="100" BackColor="Aquamarine"></asp:ListBox>
            </div>
            <br />
            <asp:Label ID="SQLstring" runat="server" Text="Generated sql code for the region:" ForeColor="#00FFCC"></asp:Label>
            <br /><br />
            <asp:Label ID="RegionLabel" runat="server" Text="Label" ForeColor="White" ></asp:Label>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="Generated sql code for the Municipality:" ForeColor="#00FFCC"></asp:Label>
            <br /><br />
            <asp:Label ID="MunicipalityLabel" runat="server" Text="Label" ForeColor="White"></asp:Label>
            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="Generated sql code for the Settlement textbox:" ForeColor="#00FFCC"></asp:Label>
            <br /><br />
            <asp:Label ID="SettlementLabel" runat="server" Text="Label" ForeColor="White"></asp:Label>

        </div>

    </form>
</body>
</html>
