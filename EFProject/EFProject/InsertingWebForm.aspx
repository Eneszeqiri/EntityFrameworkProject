<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertingWebForm.aspx.cs" Inherits="EFProject.InsertingWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:black; font-family:Arial; color:aliceblue">
    <form id="form1" runat="server" style="padding-left:300px; padding-right:300px;" >
        <asp:Button ID="Backwards" runat="server" Text="Go back" postbackurl ="~/HomePage.aspx"/>
        <div style="background-color:dimgrey; text-align:center; padding-top:20px;">
            <div id="Regiondiv" style="border:solid 3px; padding: 10px; border-color:aquamarine"">
                <h1 style=" border:dotted 3px; padding:10px">Inserting region</h1>
            <p>Here we can insert the regions:</p>
            <br />
            Region: <asp:TextBox ID="RegionTextBox" runat="server" BackColor="Aquamarine" BorderColor="White" BorderStyle="Inset"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Button ID="InsertRegion" runat="server" Text="InsertRegion" OnClick="InsertRegion_Click" Height="30px" Width="200px" />
            </div>
            
            <br /><br />

            <div id="MunicipalityDiv" style="border:solid 3px; padding: 10px; border-color:aquamarine">
                <h1 style=" border:dotted 3px; padding:10px">Inserting Munipacility</h1>
            <p>Here we can insert the Municipality, but first choose the region which the municipality belongs to:</p>
            <br />
            Region:<asp:ListBox ID="RegionListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="RegionName" DataValueField="RegionName" BackColor="Aquamarine"></asp:ListBox>
            Munipacility: <asp:TextBox ID="MunipacilityTextBox" runat="server" BackColor="Aquamarine" BorderColor="White" BorderStyle="Inset"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="InsertMunicipality" runat="server" Text="InsertMunicipality" OnClick="InsertMunicipality_Click" Height="30px" Width="200px"/>
            </div>
            
            <br /><br />

            <div id="SettlementDiv" style="border:solid 3px; padding: 10px; border-color:aquamarine">
                <h1 style=" border:dotted 3px; padding:10px">Inserting Settlement</h1>
             <p>Here we can insert the Settlement, but first choose the region and the municipality which the Settlement belongs to:</p>
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
                        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate> 
                    Region: <asp:ListBox ID="RegionListBox2" runat="server" AutoPostBack="true" DataSourceID="SqlDataSource1" DataTextField="RegionName" DataValueField="RegionName"  OnSelectedIndexChanged="RegionListBox2_SelectedIndexChanged" BackColor="Aquamarine" ></asp:ListBox>   
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ModelsConnectionString %>" SelectCommand="SELECT [RegionName] FROM [RegionClasses]"></asp:SqlDataSource>
                    Munipacility: <asp:DropDownList ID="MunipacilityDropDown" runat="server" AutoPostBack="true" BackColor="Aquamarine" ></asp:DropDownList>
                    Settlement: <asp:TextBox ID="SettlementTextBox" runat="server" AutoPostBack="true" BackColor="Aquamarine" BorderColor="White" BorderStyle="Inset"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="InsertSettlement" runat="server" Text="InsertSettlement" OnClick="InsertSettlement_Click" Height="30px" Width="200px" />
                    <br /><br />
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            
        </div>
    </form>
</body>
</html>
