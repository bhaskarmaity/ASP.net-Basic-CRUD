<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landing page.aspx.cs" Inherits="TestWeb1.landing_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Welcome to student portal</h2>
        
        <asp:LinkButton ID="LinkButton1" PostBackUrl="~/addStudent.aspx" runat="server">Add Student Details</asp:LinkButton>

         &nbsp;  &nbsp;
        <asp:LinkButton ID="LinkButton2" PostBackUrl="~/showStudents.aspx" runat="server">Show Students</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
