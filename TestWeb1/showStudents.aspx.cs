using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Configuration;
using System.Web.UI.WebControls;


namespace TestWeb1
{
    public partial class showStudents : System.Web.UI.Page
    {
        public static string selectedStdId, fname, lname, email, gender, course, city1, city2;
        public bool flag = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                string constr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                //string Sql = "select x.*,y.* from (select tempPart1.first_name,tempPart1.last_name,tempPart1.email,tempPart1.course,tempPart1.gender, tempPart1.t_Std_Id,tempPart2.City_Name as \"p_City_Name\",tempPart2.Pin_Code as \"p_Pin_Code\",tempPart2.State_Name as \"p_State_Name\",tempPart2.Country_name as \"p_Country_name\",tempPart2.City_Id as \"p_City_Id\",tempPart2.State_Id as \"p_tempPart2\" from(select std_addr.first_name,std_addr.last_name,std_addr.email,std_addr.course,std_addr.gender,std_addr.t_Std_Id,a.Country_Id as \"t_Country_Id\",a.State_Id as \"t_State_Id\",a.City_Id as \"t_City_Id\" from (select * from Student s inner join (select temp.t_Std_Id,temp.p_Addr_Id,t_Addr_Id from (select * from (Select sa.Std_Id as \"p_Std_Id\",sa.Addr_Id as \"p_Addr_Id\",sa.Addr_Type as \"p_Addr_Type\",sa.Std_Addr_Id as \"p_Std_Addr_Id\" from Std_Address sa where sa.Addr_Type = \'Permanent\' ) a inner join (Select sa.Addr_Id as \"t_Addr_Id\",sa.Addr_Type as \"t_Addr_Type\",sa.Std_Addr_Id as \"t_Std_Addr_Id\",sa.Std_Id as \"t_Std_Id\" from Std_Address sa where sa.Addr_Type = \'Temporary\') b on a.p_Std_Id = b.t_Std_Id and a.p_Std_Addr_Id != b.t_Std_Addr_Id) temp ) t on t.t_Std_Id = s.Id) std_addr inner join Address a on std_addr.p_Addr_Id = a.Addr_Id ) tempPart1 inner join (select s.* from (select addr_state_map.City_Id,addr_state_map.City_Name,addr_state_map.Pin_Code,addr_state_map.State_Id,addr_state_map.State_Name,addr_state_map.Country_name from ((select city_state.City_Id,city_state.City_Name,city_state.Pin_Code,city_state.State_Id,city_state.State_Name,city_state.Country_Id,co.Country_name from (select c.City_Id,c.City_Name,c.Pin_Code,s.State_Name,s.State_Id,s.Country_Id from City c inner join State s on s.State_Id = c.State_Id) city_state inner join Country co on co.Country_Id = city_state.Country_Id) addr_state_map inner join Country co on co.Country_Id = addr_state_map.Country_Id) ) s) tempPart2 on tempPart1.t_City_Id = tempPart2.City_Id) x inner join (select tempPart1.t_Std_Id,tempPart2.City_Name as \"t_City_Name\",tempPart2.Pin_Code as \"t_Pin_Code\",tempPart2.State_Name as \"t_State_Name\",tempPart2.Country_name as \"t_Country_name\",tempPart2.City_Id as \"t_City_Id\",tempPart2.State_Id as \"t_tempPart2\" from(select std_addr.first_name,std_addr.last_name,std_addr.email,std_addr.course,std_addr.gender,std_addr.t_Std_Id,a.Country_Id as \"t_Country_Id\",a.State_Id as \"t_State_Id\",a.City_Id as \"t_City_Id\" from (select * from Student s inner join (select temp.t_Std_Id,temp.p_Addr_Id,t_Addr_Id from (select * from (Select sa.Std_Id as \"p_Std_Id\",sa.Addr_Id as \"p_Addr_Id\",sa.Addr_Type as \"p_Addr_Type\",sa.Std_Addr_Id as \"p_Std_Addr_Id\" from Std_Address sa where sa.Addr_Type = \'Permanent\' ) a inner join (Select sa.Addr_Id as "\t_Addr_Id\",sa.Addr_Type as \"t_Addr_Type\",sa.Std_Addr_Id as \"t_Std_Addr_Id\",sa.Std_Id as \"t_Std_Id\" from Std_Address sa where sa.Addr_Type = \'Temporary\') b on a.p_Std_Id = b.t_Std_Id and a.p_Std_Addr_Id != b.t_Std_Addr_Id) temp ) t on t.t_Std_Id = s.Id) std_addr inner join Address a on std_addr.t_Addr_Id = a.Addr_Id ) tempPart1 inner join (select s.* from (select addr_state_map.City_Id,addr_state_map.City_Name,addr_state_map.Pin_Code,addr_state_map.State_Id,addr_state_map.State_Name,addr_state_map.Country_name from ((select city_state.City_Id,city_state.City_Name,city_state.Pin_Code,city_state.State_Id,city_state.State_Name,city_state.Country_Id,co.Country_name from (select c.City_Id,c.City_Name,c.Pin_Code,s.State_Name,s.State_Id,s.Country_Id from City c inner join State s on s.State_Id = c.State_Id) city_state inner join Country co on co.Country_Id = city_state.Country_Id) addr_state_map inner join Country co on co.Country_Id = addr_state_map.Country_Id) ) s) tempPart2 on tempPart1.t_City_Id = tempPart2.City_Id) y on x.t_Std_Id = y.t_Std_Id;";

                string Sql = "select x.*,y.* from (select tempPart1.first_name,tempPart1.last_name,tempPart1.email,tempPart1.course,tempPart1.gender, tempPart1.t_Std_Id,tempPart2.City_Name as \"p_City_Name\",tempPart2.Pin_Code as \"p_Pin_Code\",tempPart2.State_Name as \"p_State_Name\",tempPart2.Country_name as \"p_Country_name\",tempPart2.City_Id as \"p_City_Id\",tempPart2.State_Id as \"p_tempPart2\" from(select std_addr.first_name,std_addr.last_name,std_addr.email,std_addr.course,std_addr.gender,std_addr.t_Std_Id,a.Country_Id as \"t_Country_Id\",a.State_Id as \"t_State_Id\",a.City_Id as \"t_City_Id\" from (select * from Student s inner join (select temp.t_Std_Id,temp.p_Addr_Id,t_Addr_Id from (select * from (Select sa.Std_Id as \"p_Std_Id\",sa.Addr_Id as \"p_Addr_Id\",sa.Addr_Type as \"p_Addr_Type\",sa.Std_Addr_Id as \"p_Std_Addr_Id\" from Std_Address sa where sa.Addr_Type = \'Permanent\' ) a inner join (Select sa.Addr_Id as \"t_Addr_Id\",sa.Addr_Type as \"t_Addr_Type\",sa.Std_Addr_Id as \"t_Std_Addr_Id\",sa.Std_Id as \"t_Std_Id\" from Std_Address sa where sa.Addr_Type = \'Temporary\') b on a.p_Std_Id = b.t_Std_Id and a.p_Std_Addr_Id != b.t_Std_Addr_Id) temp ) t on t.t_Std_Id = s.Id) std_addr inner join Address a on std_addr.p_Addr_Id = a.Addr_Id ) tempPart1 inner join (select s.* from (select addr_state_map.City_Id,addr_state_map.City_Name,addr_state_map.Pin_Code,addr_state_map.State_Id,addr_state_map.State_Name,addr_state_map.Country_name from ((select city_state.City_Id,city_state.City_Name,city_state.Pin_Code,city_state.State_Id,city_state.State_Name,city_state.Country_Id,co.Country_name from (select c.City_Id,c.City_Name,c.Pin_Code,s.State_Name,s.State_Id,s.Country_Id from City c inner join State s on s.State_Id = c.State_Id) city_state inner join Country co on co.Country_Id = city_state.Country_Id) addr_state_map inner join Country co on co.Country_Id = addr_state_map.Country_Id) ) s) tempPart2 on tempPart1.t_City_Id = tempPart2.City_Id) x inner join (select tempPart1.t_Std_Id,tempPart2.City_Name as \"t_City_Name\",tempPart2.Pin_Code as \"t_Pin_Code\",tempPart2.State_Name as \"t_State_Name\",tempPart2.Country_name as \"t_Country_name\",tempPart2.City_Id as \"t_City_Id\",tempPart2.State_Id as \"t_tempPart2\" from(select std_addr.first_name,std_addr.last_name,std_addr.email,std_addr.course,std_addr.gender,std_addr.t_Std_Id,a.Country_Id as \"t_Country_Id\",a.State_Id as \"t_State_Id\",a.City_Id as \"t_City_Id\" from (select * from Student s inner join (select temp.t_Std_Id,temp.p_Addr_Id,t_Addr_Id from (select * from (Select sa.Std_Id as \"p_Std_Id\",sa.Addr_Id as \"p_Addr_Id\",sa.Addr_Type as \"p_Addr_Type\",sa.Std_Addr_Id as \"p_Std_Addr_Id\" from Std_Address sa where sa.Addr_Type = \'Permanent\' ) a inner join (Select sa.Addr_Id as \"t_Addr_Id\",sa.Addr_Type as \"t_Addr_Type\",sa.Std_Addr_Id as \"t_Std_Addr_Id\",sa.Std_Id as \"t_Std_Id\" from Std_Address sa where sa.Addr_Type = \'Temporary\') b on a.p_Std_Id = b.t_Std_Id and a.p_Std_Addr_Id != b.t_Std_Addr_Id) temp ) t on t.t_Std_Id = s.Id) std_addr inner join Address a on std_addr.t_Addr_Id = a.Addr_Id ) tempPart1 inner join (select s.* from (select addr_state_map.City_Id,addr_state_map.City_Name,addr_state_map.Pin_Code,addr_state_map.State_Id,addr_state_map.State_Name,addr_state_map.Country_name from ((select city_state.City_Id,city_state.City_Name,city_state.Pin_Code,city_state.State_Id,city_state.State_Name,city_state.Country_Id,co.Country_name from (select c.City_Id,c.City_Name,c.Pin_Code,s.State_Name,s.State_Id,s.Country_Id from City c inner join State s on s.State_Id = c.State_Id) city_state inner join Country co on co.Country_Id = city_state.Country_Id) addr_state_map inner join Country co on co.Country_Id = addr_state_map.Country_Id) ) s) tempPart2 on tempPart1.t_City_Id = tempPart2.City_Id) y on x.t_Std_Id = y.t_Std_Id;";
                SqlCommand cmd = new SqlCommand(Sql);
                SqlDataAdapter sda = new SqlDataAdapter();

                cmd.Connection = con;
                sda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if ((GridView1.DataSource as DataTable).Rows.Count < 1) {
                    Label1.Text = "No data fetched";
                }
            }
            catch(Exception ex){
                Label1.Text = "Something went to wrong";
            }

        }


        protected void editBtn_Click(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ';' });
            
            // Copying the values
            selectedStdId = commandArgs[0];

            // Setting the values
            firstname.Text = commandArgs[1];
            lastname.Text = commandArgs[2];
            em.Text = commandArgs[3];
            courseList.SelectedValue = commandArgs[4];
            if (commandArgs[5].ToString() == "Male") RadioButton1.Checked = true;
            if (commandArgs[5].ToString() == "Female") RadioButton2.Checked = true;
            
            flag = true;
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            string Ids = ((LinkButton)sender).CommandArgument.ToString();
            Label7.Text = Ids.ToString();


            int stdId = Ids[0], stdAddrId = Ids[1], addrId = Ids[2];
            string studentSql = "delete from Student where Id = " + stdId + ";";

            string addr_student_Sql = "delete from Std_Address where Std_Addr_Id = " + stdAddrId + ";";
            string addr_Sql = "delete from Address where Addr_Id = " + addrId + ";";

            string sql = "DeleteStudentData";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@stdId", SqlDbType.Int);
            param.Value = stdId;

            param = cmd.Parameters.Add("@stdAddrId", SqlDbType.Int);
            param.Value = stdAddrId;

            param = cmd.Parameters.Add("@addrId", SqlDbType.Int);
            param.Value = addrId;

            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected < 0) Label1.Text = "Successfully added";
                else Label1.Text = "Failed to add";
            }
            catch (Exception exc)
            {
                Label1.Text = "Failed to add!!!";
            }

            /*
            string constr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            int x = cmd.ExecuteNonQuery();
            con.Close();

            if (x > 0) {
            this.Page_Load(sender,e);
            Label1.Text = "Successfully deleted";
            }
            else Label1.Text = "Failed to delete";
           */
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Submit1_Click(object sender, EventArgs e)
        {
            string gender1 = null;
            if (RadioButton1.Checked) gender1 = "Male";
            if (RadioButton2.Checked) gender1 = "Female";

            course = courseList.SelectedValue;
  
            string sql = "update Student set first_name = '" + firstname.Text + "', last_name = '" + lastname.Text + "', gender = '" + gender1 + "', email = '" + em.Text + "', course = '" + courseList.Text + "'where id = " + Convert.ToInt32(selectedStdId) + ";";

            string constr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            int x = cmd.ExecuteNonQuery();
            con.Close();

            if (x > 0)
            {
                this.Page_Load(sender, e);
                Label1.Text = "Successfully updated";
                flag = false;
            }
            else Label1.Text = "Failed to update";
        }

      }
}
