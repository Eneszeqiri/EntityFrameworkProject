<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EFProject.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:black">

    <form id="form1" runat="server" style= "text-align:center; padding-left: 300px; padding-right: 300px; padding-top: 150px; font-family:Arial;" >
        <div style="background-color:dimgray; color:aliceblue; padding:20px">
            <h1 style="font-family:Arial; text-decoration: underline; border:dotted 3px; padding:10px">
             Entity framework mini-project
        </h1>
        <p>
            This project is made for personal use to exercise entity framework.
            <br /><br />
            <b style="color:aquamarine">INSERTING</b> button is used to insert the places
            <br />
            <b style="color:aquamarine">SEARCHING</b> button is used to search the places
        </p>
        </div>
        
        <div style="padding:30px; border:solid black 1px; background-color: aquamarine">
            <asp:Button ID="Button1" runat="server" Text="Inserting" PostBackUrl="InsertingWebForm.aspx" Height="50px" Width="200px"/>

            <br /><br />
            <asp:Button ID="Button2" runat="server" Text="Searching" PostBackUrl="SearchingWebForm.aspx" Height="50px" Width="200px"/>
        </div>
    </form>
</body>

</html>
