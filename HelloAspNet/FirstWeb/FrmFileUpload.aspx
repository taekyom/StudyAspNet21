<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmFileUpload.aspx.cs" Inherits="FirstWeb.FrmFileUpload" %>
<%@ OutputCache Duration="60" VaryByParam="None" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>파일업로드</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload runat="server" ID="CtlUpload" /><br />
            <asp:Button ID="BtnUpload" Text="Upload" runat="server" OnClick="BtnUpload_Click" /><br />
            <asp:Label ID="LblResult" runat="server" />
            <div>
                <asp:Label ID="LblCached" runat="server" /><br />
                <asp:Substitution ID="SttMain" runat="server" MethodName="GetCurrenTime" /><br />
            </div>
            <div>
                <asp:Localize ID="LblLocal1" runat="server" Text="안녕하세요"></asp:Localize><br />
                <asp:Localize ID="LblLocal2" runat="server" Text ="<hr /><b>안녕하세요</b>" Mode="Encode"></asp:Localize>
                <%--mode=encode : text의 ""안에 있는 내용 그대로 출력, mode=transform : text의 ""안 내용대로 변환되어 출력--%> 
            </div>
        </div>
    </form>
</body>
</html>
