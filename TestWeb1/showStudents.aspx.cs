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
                string Sql = "select * from Student;";
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
            string stdId = ((LinkButton)sender).CommandArgument.ToString();
            string sql = "delete from Student where Id = " + stdId + ";";

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
