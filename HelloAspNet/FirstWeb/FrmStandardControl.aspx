<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmStandardControl.aspx.cs" Inherits="FirstWeb.FrmStandardControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>표준 컨트롤</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>표준 컨트롤</h1>
            <asp:TextBox ID="TxtUserID" runat="server" TextMode="SingleLine" /><br />
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" /><br />
            <asp:TextBox ID="TxtDesc" runat="server" TextMode="MultiLine" /><br />

            <%--runat="Server" 없으면 자바스크립트 연동 ok, C#은 X--%>
            <asp:Label ID="LblDateTme" runat="server" Text="Sample" /><br />
            <input type="button" value="버튼1" id="BtnInput" /><br />
            <input type="button" value="버튼2" id="BtnHtml" runat="server" /><br />
            <asp:Button Text="버튼3" ID="BtnServer" runat="server" OnClick="BtnServer_Click" /><br />
            <%--랜더링되면 asp:button과 input은 같은 게 됨(asp->input 변경)--%>
        </div>
    </form>
</body>
</html>
