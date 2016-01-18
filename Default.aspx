<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Classic ADO</title>
    <link href="ClassicADO.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Authors</h1>
        <hr />
        <p>Choose an author to see a a list of their books:</p>
        <asp:DropDownList 
            ID="AuthorDropDownList" 
            runat="server" 
            AutoPostBack="True"
            OnSelectedIndexChanged="AuthorDropDownList_SelectedIndexChanged"
            CssClass="list">

        </asp:DropDownList>
        <asp:GridView 
            ID="BooksGridView" 
            runat="server">

        </asp:GridView>
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
