<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showStudents.aspx.cs" Inherits="TestWeb1.showStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

</head>
<body>
    <!-- ************************************************************************** -->

    <form id="form1" runat="server">
        <a href="landing page.aspx"><= Back</a>
        <div>
            <%if (flag)
              { %>
            <h2>List of students</h2>
            <div>
                <asp:Label ID="Label2" runat="server" Text="First name : "></asp:Label>
                <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="Label3" runat="server" Text="Last name : "></asp:Label>
                <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="Label4" runat="server" Text="Email : "></asp:Label>
                <asp:TextBox ID="em" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:Label ID="Label5" runat="server" Text="Course : "></asp:Label>
                <asp:DropDownList ID="courseList" runat="server">
                    <asp:ListItem Selected="True" Value="Default">-- SELECT --</asp:ListItem>
                    <asp:ListItem Value="BCA">BCA</asp:ListItem>
                    <asp:ListItem Value="BBA">BBA</asp:ListItem>
                    <asp:ListItem Value="MCA">MCA</asp:ListItem>
                    <asp:ListItem Value="MBA">MBA</asp:ListItem>
                </asp:DropDownList>

                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Gender : "></asp:Label>
                <asp:RadioButton ID="RadioButton1" Text="Male" GroupName="gender1" runat="server" />
                <asp:RadioButton ID="RadioButton2" Text="Female" GroupName="gender1" runat="server" />

                <br />
                <br />
                <asp:Button ID="Submit1" runat="server" Text="Submit" OnClientClick="return validateForm()" OnClick="Submit1_Click" />
                <script>
                    function validateForm() {
                        console.log('This is validate form');
                    }
                </script>
                <br />
                <br />

            </div>
            <% } %>
           <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>

            <!-- ******************************************************************** -->

            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="t_Std_Id" HeaderText="Id" />
                    <asp:BoundField DataField="first_name" HeaderText="First Name" />
                    <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="course" HeaderText="Course" />
                    <asp:BoundField DataField="gender" HeaderText="Gender" />


                    <asp:BoundField DataField="p_City_Name" HeaderText="P City" />
                    <asp:BoundField DataField="p_Pin_Code" HeaderText="P Pin" />
                    <asp:BoundField DataField="p_State_Name" HeaderText="P State" />
                    <asp:BoundField DataField="p_Country_name" HeaderText="P Country" />

                    <asp:BoundField DataField="t_City_Name" HeaderText="P City" />
                    <asp:BoundField DataField="t_Pin_Code" HeaderText="P Pin" />
                    <asp:BoundField DataField="t_State_Name" HeaderText="P State" />
                    <asp:BoundField DataField="t_Country_name" HeaderText="P Country" />



                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="editBtn" OnClick="editBtn_Click" CommandArgument='<%# Eval("first_name") + ";" + Eval("last_name") + ";" + Eval("email") + ";" + Eval("course") + ";" + Eval("gender") + ";" + Eval("t_Std_Id") + ";" + Eval("p_City_Name") + ";" + Eval("p_Pin_Code") + ";" + Eval("p_State_Name") + ";" + Eval("p_Country_name") + ";" + Eval("p_City_Id") + ";" + Eval("p_tempPart2") + ";" + Eval("t_Std_Id") + ";" + Eval("t_City_Name") + ";" + Eval("t_Pin_Code") + ";" + Eval("t_State_Name") + ";" + Eval("t_Country_name") + ";" + Eval("t_City_Id") + ";" + Eval("t_tempPart2") %>' runat="server">Edit</asp:LinkButton>
                            <asp:LinkButton ID="deleteBtn" OnClick="deleteBtn_Click" CommandArgument='<%# Eval("first_name") + ";" + Eval("last_name") + ";" + Eval("email") + ";" + Eval("course") + ";" + Eval("gender") + ";" + Eval("t_Std_Id") + ";" + Eval("p_City_Name") + ";" + Eval("p_Pin_Code") + ";" + Eval("p_State_Name") + ";" + Eval("p_Country_name") + ";" + Eval("p_City_Id") + ";" + Eval("p_tempPart2") + ";" + Eval("t_Std_Id") + ";" + Eval("t_City_Name") + ";" + Eval("t_Pin_Code") + ";" + Eval("t_State_Name") + ";" + Eval("t_Country_name") + ";" + Eval("t_City_Id") + ";" + Eval("t_tempPart2")%>' runat="server">Delete</asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>



        </div>
    </form>
</body>
</html>
