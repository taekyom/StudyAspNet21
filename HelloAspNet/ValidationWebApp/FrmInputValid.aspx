<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInputValid.aspx.cs" Inherits="ValidationWebApp.FrmInputValid" %>
<%@ Register Src="~/Copyright.ascx" TagPrefix="uc1" TagName="Copyright" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>유효성 검사</title>
    <%--유효성검사는 굉장히 중요/필수적인 부분!--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TxtAge" runat="server" />
            <asp:RangeValidator ID="ValAge" runat="server" ControlToValidate="TxtAge"
                ErrorMessage="나이는 1~150사이의 정수입니다." ForeColor="Blue" 
                MinimumValue="1" MaximumValue="150" Type="Integer"
                Display="Dynamic" SetFocusOnError="true" />
            <asp:RequiredFieldValidator ID="ValAge2" runat="server" ControlToValidate="TxtAge"
                ErrorMessage="나이를 입력하세요" ForeColor="Red" Display="Dynamic" />(필수)<br />
            <asp:TextBox ID="TxtScore" runat="server" />
            <asp:RangeValidator ID="ValScore" runat="server" ControlToValidate="TxtScore"
                ErrorMessage="학점은 A~F입니다." MinimumValue="A" MaximumValue="F" 
                Type="String" Display="Dynamic" SetFocusOnError="true"/><br />
            <asp:TextBox ID="TxtUserID" runat="server" />
            <asp:RequiredFieldValidator ID="ValUserID" runat="server" ControlToValidate="TxtUserID"
                ErrorMessage="아이디를 입력하세요" ForeColor="Red" Display="Dynamic" />(필수)<br />
            <asp:TextBox ID="TxtPassword" runat="server" TextMode ="Password" />
            <asp:RequiredFieldValidator ID="ValPassword" runat="server" ControlToValidate="TxtPassword"
                ErrorMessage="암호를 입력하세요" ForeColor="Red" Display="Dynamic" />(필수)<br />
            <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode ="Password" />
            <asp:RequiredFieldValidator ID="ValConfirmPassword" runat="server" ControlToValidate="TxtConfirmPassword"
                ErrorMessage="암호를 확인하세요" ForeColor="Red" Display="Dynamic" />(필수)
            <asp:CompareValidator ID="ValComparPassword" runat="server" ControlToValidate="TxtPassword"
                ControlToCompare="TxtConfirmPassword" SetFocusOnError="true" ForeColor="Blue"
                ErrorMessage="암호가 일치하지 않습니다." Display="Dynamic" /><br />

            <asp:TextBox ID="TxtEmail" runat="server" />
            <asp:RegularExpressionValidator ID="ValEmail" runat="server" ControlToValidate="TxtEmail"
                 ErrorMessage="이메일을 정확히 입력하세요." SetFocusOnError="true" ForeColor="Red" 
                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" /><br />

            <asp:Button ID="BtnLogin" Text="회원가입" runat="server" OnClick="BtnLogin_Click" />
            <asp:ValidationSummary ID="ValSummary" runat="server" ShowMessageBox="true" ShowSummary="false" DisplayMode="BulletList" />
        </div>
    </form>
    <uc1:Copyright runat="server" id="Copyright" />
</body>
</html>
