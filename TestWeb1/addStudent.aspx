<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addStudent.aspx.cs" Inherits="TestWeb1.addStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

</head>
<body>

    <form id="form1" runat="server">

        <a href="landing page.aspx"><= Back</a>
        <div>
            <h2>Add Student Information</h2>

            <asp:Label ID="Label0" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="First name : "></asp:Label>
            <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label2" runat="server" Text="Last name : "></asp:Label>
            <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label3" runat="server" Text="Email : "></asp:Label>
            <asp:TextBox ID="em" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Label ID="Label4" runat="server" Text="Course : "></asp:Label>
            <asp:DropDownList ID="courseList" runat="server">
                <asp:ListItem Selected="True" Value="Default">-- SELECT --</asp:ListItem>
                <asp:ListItem Value="BCA">BCA</asp:ListItem>
                <asp:ListItem Value="BBA">BBA</asp:ListItem>
                <asp:ListItem Value="MCA">MCA</asp:ListItem>
                <asp:ListItem Value="MBA">MBA</asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Gender : "></asp:Label>
            <asp:RadioButton ID="RadioButton1" Text="Male" GroupName="gender1" runat="server" />
            <asp:RadioButton ID="RadioButton2" Text="Female" GroupName="gender1" runat="server" />

            <br />

            <h4>Permanent Address</h4>
            <asp:Label ID="lbltest" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCountryPerErr" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCountryPer" runat="server" Text="Country : "></asp:Label>
            <asp:DropDownList ID="ddlCountryPer" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="Country_Changed_Per">
                <asp:ListItem Selected="True"></asp:ListItem>
            </asp:DropDownList>

            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblStatePerErr" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblStatePer" runat="server" Text="State : "></asp:Label>
            <asp:DropDownList ID="ddlStatePer" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="State_Changed_Per">
                <asp:ListItem Selected="True" Value="Default">-- SELECT --</asp:ListItem>
            </asp:DropDownList>

            &nbsp;&nbsp;&nbsp;

            <asp:Label ID="lblCityPerErr" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCityPer" runat="server" Text="City : "></asp:Label>
            <asp:DropDownList ID="ddlCityPer" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="City_Changed_Per">
                <asp:ListItem Selected="True" Value="Default">-- SELECT --</asp:ListItem>
            </asp:DropDownList>

            &nbsp;&nbsp;&nbsp;

            <asp:Label ID="lblPinPerErr" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblPinPer" runat="server" Text="PinCode : "></asp:Label>
            <asp:DropDownList ID="ddlPinPer" runat="server">
                <asp:ListItem Selected="True" Value="Default">-- SELECT --</asp:ListItem>
            </asp:DropDownList>

            &nbsp;
            <asp:Button ID="btnresetPer" runat="server" Text="Reset" OnClick="btnresetPer_Click" />

            <br />



            <h4>Temporary Address</h4>
            <asp:Label ID="lblCountryTempErr" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCountryTemp" runat="server" Text="Country : "></asp:Label>
            <asp:DropDownList ID="ddlCountryTemp" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="Country_Changed_Temp">
                <asp:ListItem Selected="True"></asp:ListItem>
            </asp:DropDownList>

            &nbsp;&nbsp;&nbsp;

            <asp:Label ID="lblStateTempErr" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblStateTemp" runat="server" Text="State : "></asp:Label>
            <asp:DropDownList ID="ddlStateTemp" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="State_Changed_Temp">
                <asp:ListItem Selected="True" Value="Default">-- SELECT --</asp:ListItem>
            </asp:DropDownList>

            &nbsp;&nbsp;&nbsp;

            <asp:Label ID="lblCityTempErr" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCityTemp" runat="server" Text="City : "></asp:Label>
            <asp:DropDownList ID="ddlCityTemp" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="City_Changed_Temp">
                <asp:ListItem Selected="True" Value="Default">-- SELECT --</asp:ListItem>
            </asp:DropDownList>

            &nbsp;&nbsp;&nbsp;

            <asp:Label ID="lblPinTempErr" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblPinTemp" runat="server" Text="PinCode : "></asp:Label>
            <asp:DropDownList ID="ddlPinTemp" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="City_Changed_Temp">
                <asp:ListItem Selected="True" Value="Default">-- SELECT --</asp:ListItem>
            </asp:DropDownList>

            &nbsp;<asp:Button ID="btnresettemp" runat="server" OnClick="btnresettemp_Click" Text="Reset" />

            <br /><br />

            <asp:Button ID="Submit1" runat="server" Text="Submit" OnClientClick="return validateForm()" OnClick="Submit1_Click" />
            <script>
                function validateForm() {
                    console.log('This is validate form');
                }
            </script>
            <br />
            <br />
        </div>

        <asp:Label ID="op" runat="server"></asp:Label>

    </form>
</body>
</html>
