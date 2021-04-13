<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDBConn.aspx.cs" Inherits="DBHandlingWebApp.FrmDBConn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DB 연결확인</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BtnConn" runat="server" Text="데이터 입력" OnClick="BtnConn_Click" />
            <br />
            <asp:Label ID="LblResult" runat="server" />
        </div>
    </form>
</body>
</html>
