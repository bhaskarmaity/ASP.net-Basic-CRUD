using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb1
{
    public partial class addStudent : System.Web.UI.Page {
       private void BindDropDown(DropDownList ddl, string query, string text, string value, string defaultText, string fieldName) {
            try {
                string conString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                SqlCommand cmd = new SqlCommand(query);
                SqlConnection con = new SqlConnection(conString);
                SqlDataAdapter sda = new SqlDataAdapter();

                cmd.Connection = con;
                con.Open();
                ddl.DataSource = cmd.ExecuteReader();
                if ((ddl.Items.Count) > 0) {
                    ddl.DataTextField = text;
                    ddl.DataValueField = value;
                    ddl.DataBind();
                    con.Close();
                    ddl.Items.Insert(0, new ListItem(defaultText, "0"));
                }
            }
            catch (Exception ex){
                if (fieldName == "Country") lblCountryPerErr.Text = "Failed to load " + fieldName;
                if (fieldName == "State") lblStatePerErr.Text = "Failed to load " + fieldName;
                if (fieldName == "City") lblCityPerErr.Text = "Failed to load " + fieldName;
                if (fieldName == "Pin") lblPinPerErr.Text = "Failed to load " + fieldName;
            }
        }

       protected void Page_Load(object sender, EventArgs e) {

           if (!IsPostBack)
           {
               this.BindDropDown(ddlCountryPer, "select * from Country;", "Country_name", "Country_Id", "-- SELECT --", "Country");
               this.BindDropDown(ddlStatePer, "select * from State;", "State_name", "State_Id", "-- SELECT --", "State");
               this.BindDropDown(ddlCityPer, "select * from city;", "City_name", "City_Id", "-- SELECT --", "City");
               this.BindDropDown(ddlPinPer, "select * from city;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");

               this.BindDropDown(ddlCountryTemp, "select * from Country;", "Country_name", "Country_Id", "-- SELECT --", "Country");
               this.BindDropDown(ddlStateTemp, "select * from State;", "State_name", "State_Id", "-- SELECT --", "State");
               this.BindDropDown(ddlCityTemp, "select * from city;", "City_name", "City_Id", "-- SELECT --", "City");
               this.BindDropDown(ddlPinTemp, "select * from city;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");
           }
        }

       protected void Country_Changed_Per(object sender, EventArgs e) {
           this.BindDropDown(ddlStatePer, "select * from State where Country_Id =" + ddlCountryPer.SelectedItem.Value  + " ;", "State_name", "State_Id", "-- SELECT --", "State");
       }

       protected void State_Changed_Per(object sender, EventArgs e) {

           if (Convert.ToInt32(ddlCountryPer.SelectedItem.Value) != 0) {
               this.BindDropDown(ddlCityPer, "select * from City where State_Id =" + ddlStatePer.SelectedItem.Value + " ;", "City_name", "City_Id", "-- SELECT --", "City");
           }
           else {
               this.BindDropDown(ddlCountryPer, "select distinct * from Country c inner join State s on c.Country_Id = s.Country_Id and s.State_Id = " + ddlStatePer.SelectedItem.Value + ";", "Country_name", "Country_Id", "-- SELECT --", "Country");
               this.BindDropDown(ddlCityPer, "select distinct c.* from City c inner join State s on c.State_Id = s.State_Id and s.State_Id =" + ddlStatePer.SelectedItem.Value + " ;", "City_name", "City_Id", "-- SELECT --", "City");
               this.BindDropDown(ddlPinPer, "select distinct c.* from City c inner join State s on c.State_Id = s.State_Id and s.State_Id =" + ddlStatePer.SelectedItem.Value, "Pin_Code", "City_Id", "-- SELECT --", "Pin");
               Label0.Text = "Country : " + ddlCountryPer.SelectedItem.Text + " |||| State : " + ddlStatePer.SelectedItem.Text;
           }
       }

       protected void City_Changed_Per(object sender, EventArgs e) {
           this.BindDropDown(ddlPinPer, "select * from City where City_Id =" + ddlCityPer.SelectedItem.Value + " ;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");
       }

        /// ///////////////////////////////////////////////////////////////////////
       protected void Country_Changed_Temp(object sender, EventArgs e) {
           this.BindDropDown(ddlStateTemp, "select * from State where Country_Id =" + ddlCountryTemp.SelectedItem.Value + " ;", "State_name", "State_Id", "-- SELECT --", "State");
       }

       protected void State_Changed_Temp(object sender, EventArgs e) {
           this.BindDropDown(ddlCityTemp, "select * from City where State_Id =" + ddlStateTemp.SelectedItem.Value + " ;", "City_name", "City_Id", "-- SELECT --", "City");
       }

       protected void City_Changed_Temp(object sender, EventArgs e) {
           this.BindDropDown(ddlPinTemp, "select * from City where City_Id =" + ddlCityTemp.SelectedItem.Value + " ;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");
       }


        protected void Submit1_Click(object sender, EventArgs e) {
            string fname = null, lname = null, email = null, course = null, gender = "";
            fname = firstname.Text;
            lname = lastname.Text;
            email = em.Text;
            if (RadioButton1.Checked) gender = "Male";
            if (RadioButton2.Checked) gender = "Female";
            course = courseList.SelectedValue;
 
            string sql = "INSERT INTO [dbo].[student] ([first_name], [last_name], [email], [course], [gender]) VALUES ('" + fname + "','"+lname +"','" + email + "','" +course+"','" + gender +"');";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            try {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                int x = cmd.ExecuteNonQuery();
                con.Close();

                if (x > 0) Label0.Text = "Successfully added";
                else Label0.Text = "Failed to add";
            }
            catch {
                Label0.Text = "Failed to add";
            }
        }

        protected void btnresetPer_Click(object sender, EventArgs e) {
            this.BindDropDown(ddlCountryPer, "select * from Country;", "Country_name", "Country_Id", "-- SELECT --", "Country");
            this.BindDropDown(ddlStatePer, "select * from State;", "State_name", "State_Id", "-- SELECT --", "State");
            this.BindDropDown(ddlCityPer, "select * from city;", "City_name", "City_Id", "-- SELECT --", "City");
            this.BindDropDown(ddlPinPer, "select * from city;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");
        }

        protected void btnresettemp_Click(object sender, EventArgs e) {
            this.BindDropDown(ddlCountryTemp, "select * from Country;", "Country_name", "Country_Id", "-- SELECT --", "Country");
            this.BindDropDown(ddlStateTemp, "select * from State;", "State_name", "State_Id", "-- SELECT --", "State");
            this.BindDropDown(ddlCityTemp, "select * from city;", "City_name", "City_Id", "-- SELECT --", "City");
            this.BindDropDown(ddlPinTemp, "select * from city;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");
        }

       
    }
}