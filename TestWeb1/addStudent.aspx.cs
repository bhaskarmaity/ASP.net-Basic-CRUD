﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb1
{
    public partial class addStudent : System.Web.UI.Page
    {
        private void BindDropDown(DropDownList ddl, string query, string text, string value, string defaultText, string fieldName)
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                SqlCommand cmd = new SqlCommand(query);
                SqlConnection con = new SqlConnection(conString);
                SqlDataAdapter sda = new SqlDataAdapter();

                cmd.Connection = con;
                con.Open();
                ddl.DataSource = cmd.ExecuteReader();
                if ((ddl.Items.Count) > 0)
                {
                    ddl.DataTextField = text;
                    ddl.DataValueField = value;
                    ddl.DataBind();
                    con.Close();
                    ddl.Items.Insert(0, new ListItem(defaultText, ""));
                }
            }
            catch (Exception ex)
            {
                if (fieldName == "Country") lblCountryPerErr.Text = "Failed to load " + fieldName;
                if (fieldName == "State") lblStatePerErr.Text = "Failed to load " + fieldName;
                if (fieldName == "City") lblCityPerErr.Text = "Failed to load " + fieldName;
                if (fieldName == "Pin") lblPinPerErr.Text = "Failed to load " + fieldName;
            }
        }

        private void associateData(DropDownList ddl, string value)
        {
            ddl.ClearSelection();
            ddl.Items.FindByValue(value).Selected = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void Country_Changed_Per(object sender, EventArgs e)
        {
            string stateQry = "select distinct s.* from Country c inner join State s on s.Country_Id = c.Country_Id and c.Country_Id = "+ ddlCountryPer.SelectedItem.Value+";";
          //  lbl1.Text = stateQry;
            this.BindDropDown(ddlStatePer, stateQry, "State_name", "State_Id", "-- SELECT --", "State");
            ddlStatePer.Enabled = true;
        }

        protected void State_Changed_Per(object sender, EventArgs e)
        {
            this.BindDropDown(ddlCityPer, "select * from City where State_Id =" + ddlStatePer.SelectedItem.Value + " ;", "City_name", "City_Id", "-- SELECT --", "City");
            ddlCityPer.Enabled = true;
            ddlPinPer.Enabled = true;
        }

        protected void City_Changed_Per(object sender, EventArgs e)
        {
            this.BindDropDown(ddlPinPer, "select * from City c where c.City_Name = '" + ddlCityPer.SelectedItem.Text +"';", "Pin_Code", "City_Id", "-- SELECT --", "Pin");
        }

        protected void Pin_Changed_Per(object sender, EventArgs e)
        {
           // fillOtherFields();
        }

        protected void fillOtherFields()
        {
            try
            {
                if (Convert.ToInt32(ddlCountryPer.SelectedItem.Value) != 0 && Convert.ToInt32(ddlPinPer.SelectedItem.Value) != 0)
                {
                    associateData(ddlCountryPer, ddlCountryPer.SelectedItem.Value);


                    this.BindDropDown(ddlCityPer, "select c.* from state s inner join City c on s.State_Id = c.State_Id and c.Pin_Code = " + ddlPinPer.SelectedItem.Text + ";", "City_Name", "City_Id", "-- SELECT --", "City");

                    string stateQry = "select s.* from state s inner join City c on s.State_Id = c.State_Id and c.Pin_Code = " + ddlPinPer.SelectedItem.Text + ";";
                    //lbl1.Text = stateQry;
                    this.BindDropDown(ddlStatePer, "select s.* from state s inner join City c on s.State_Id = c.State_Id and c.Pin_Code = " + ddlPinPer.SelectedItem.Text + ";", "State_Name", "State_Id", "-- SELECT --", "State");

                    //string cityQry =;
                    associateData(ddlPinPer, ddlPinPer.SelectedItem.Value);
                    //lbl2.Text = "select c.* from state s inner join City c on s.State_Id = c.State_Id and c.Pin_Code = " + ddlPinPer.SelectedItem.Text + ";";
                }

                if (Convert.ToInt32(ddlCountryPer.SelectedItem.Value) != 0 && Convert.ToInt32(ddlCityPer.SelectedItem.Value) != 0)
                {
                    associateData(ddlCountryPer, ddlCountryPer.SelectedItem.Value);
                    associateData(ddlCityPer, ddlCityPer.SelectedItem.Value);

                    string stateQry = "select distinct s.* from City c inner join State s on c.State_Id = s.State_Id and c.City_Name = '" + ddlCityPer.SelectedItem.Text + "';";
                    this.BindDropDown(ddlStatePer, stateQry, "State_Name", "State_Id", "-- SELECT --", "State");

                    this.BindDropDown(ddlPinPer, "select * from City c where c.City_Name = '" + ddlCityPer.SelectedItem.Text + "';", "Pin_Code", "City_Id", "-- SELECT --", "City");
                }

                else if (Convert.ToInt32(ddlCountryPer.SelectedItem.Value) != 0 && Convert.ToInt32(ddlStatePer.SelectedItem.Value) != 0) {
                    associateData(ddlCountryPer, ddlCountryPer.SelectedItem.Value);
                    associateData(ddlStatePer, ddlStatePer.SelectedItem.Value);

                    string q1 = "select distinct c.* from city c inner join State s on s.State_Id = c.State_Id and s.State_Name = '" + ddlStatePer.SelectedItem.Text + "'";

                    this.BindDropDown(ddlCityPer, q1, "City_Name", "City_Id", "-- SELECT --", "City");
                    string stateQry = "select distinct s.* from State s inner join Country c on s.Country_Id = c.Country_Id where c.Country_name='" + ddlStatePer.SelectedItem.Text + "';";
                   
                    this.BindDropDown(ddlPinPer, q1, "Pin_Code", "City_Id", "-- SELECT --", "City");
                }
                //------------------------------------------------------------------------------------------------------------------------

                else if (Convert.ToInt32(ddlCountryPer.SelectedItem.Value) != 0)
                {
                    associateData(ddlCountryPer, ddlCountryPer.SelectedItem.Value);

                    string q1 = "select c.* from city c inner join (select distinct s.* from State s inner join Country c on s.Country_Id = c.Country_Id where c.Country_name='" + ddlCountryPer.SelectedItem.Text + "') jd on jd.State_Id = c.State_Id;";
                    this.BindDropDown(ddlPinPer, q1, "Pin_Code", "City_Id", "-- SELECT --", "City");
                    this.BindDropDown(ddlCityPer, q1, "City_Name", "City_Id", "-- SELECT --", "City");
                    string stateQry = "select distinct s.* from State s inner join Country c on s.Country_Id = c.Country_Id where c.Country_name='" + ddlCountryPer.SelectedItem.Text + "';";
                    this.BindDropDown(ddlStatePer, stateQry, "State_Name", "State_Id", "-- SELECT --", "State");
                }


                else if (Convert.ToInt32(ddlStatePer.SelectedItem.Value) != 0)
                {
                    associateData(ddlStatePer, ddlStatePer.SelectedItem.Value);
                    this.BindDropDown(ddlPinPer, "select distinct c.* from State s inner join City c on c.State_Id = s.State_Id and s.State_Name = '" + ddlStatePer.SelectedItem.Text + "' ;", "Pin_Code", "City_Id", "-- SELECT --", "City");
                    this.BindDropDown(ddlCityPer, "select distinct c.* from State s inner join City c on c.State_Id = s.State_Id and s.State_Name = '" + ddlStatePer.SelectedItem.Text + "' ;", "City_Name", "City_Id", "-- SELECT --", "City");
                    string countryQry = "select distinct c.* from State s inner join Country c on s.Country_Id = c.Country_Id where s.State_Name='" + ddlStatePer.SelectedItem.Text + "';";
                    this.BindDropDown(ddlCountryPer, countryQry, "Country_name", "Country_Id", "-- SELECT --", "Country");
                }

                else if (Convert.ToInt32(ddlCityPer.SelectedItem.Value) != 0)
                {
                    associateData(ddlCountryPer, ddlCountryPer.SelectedItem.Value);
                    this.BindDropDown(ddlPinPer, "select * from city c where c.City_Name = '" + ddlCityPer.SelectedItem.Text + "' ;", "Pin_Code", "City_Id", "-- SELECT --", "City");
                    this.BindDropDown(ddlStatePer, "select distinct s.* from State s inner join City c on c.State_Id = s.State_Id where c.City_Name='" + ddlCityPer.SelectedItem.Text + "' ;", "State_name", "State_Id", "-- SELECT --", "State");
                    string countryQry = "select co.* from Country co inner join (select distinct s.* from State s inner join City c on c.State_Id = s.State_Id where c.City_Name='" + ddlCityPer.SelectedItem.Text + "') jd on co.Country_Id = jd.Country_Id;";
                    this.BindDropDown(ddlCountryPer, countryQry, "Country_name", "Country_Id", "-- SELECT --", "Country");
                }

                else if (Convert.ToInt32(ddlPinPer.SelectedItem.Value) != 0)
                {
                    this.BindDropDown(ddlCityPer, " select * from City c where c.Pin_Code = " + ddlPinPer.SelectedItem.Text + " ;", "City_Name", "City_Id", "-- SELECT --", "City");
                    this.BindDropDown(ddlStatePer, "select distinct s.* from State s inner join City c On s.State_Id = c.State_Id and c.Pin_Code = " + ddlPinPer.SelectedItem.Text + " ;", "State_name", "State_Id", "-- SELECT --", "State");
                    string countryQry = "select co.* from Country co inner join (select distinct s.* from State s inner join City c On s.State_Id = c.State_Id and c.Pin_Code =" + ddlPinPer.SelectedItem.Text + " ) jr on co.Country_Id = jr.Country_Id ;";
                    this.BindDropDown(ddlCountryPer, countryQry, "Country_name", "Country_Id", "-- SELECT --", "Country");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Something went to wrong...');</script>");

                lblexception.Text = ex.ToString();
            }

        }





        /// ///////////////////////////////////////////////////////////////////////
        /// 


        protected void Country_Changed_Temp(object sender, EventArgs e)
        {
            this.BindDropDown(ddlStateTemp, "select * from State where Country_Id =" + ddlCountryTemp.SelectedItem.Value + " ;", "State_name", "State_Id", "-- SELECT --", "State");
            ddlStateTemp.Enabled = true;            
        }

        protected void State_Changed_Temp(object sender, EventArgs e)
        {
            this.BindDropDown(ddlCityTemp, "select * from City where State_Id =" + ddlStateTemp.SelectedItem.Value + " ;", "City_name", "City_Id", "-- SELECT --", "City");
            ddlCityTemp.Enabled = true;
            ddlPinTemp.Enabled = true;
        }

        protected void City_Changed_Temp(object sender, EventArgs e)
        {
            //lbl1.Text = "select * from City where City_Id =" + ddlCityTemp.SelectedItem.Value + " ;";
            this.BindDropDown(ddlPinTemp, "select * from City where City_Id =" + ddlCityTemp.SelectedItem.Value + " ;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");
        }

        protected void Pin_Changed_Temp(object sender, EventArgs e)
        {
            //lbl1.Text = "select * from City where City_Id =" + ddlCityTemp.SelectedItem.Value + " ;";
            //this.BindDropDown(ddlPinTemp, "select * from City where City_Id =" + ddlCityTemp.SelectedItem.Value + " ;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");
        }

        protected void Submit1_Click(object sender, EventArgs e)
        {
            string fname = "", lname = "", gender = "", email = "", course = "", pCountry = "", pState = "", pCity = "", 
                pPin = "", tCountry = "", tState = "", tCity = "", tPin = "";
            fname = firstname.Text.Trim();
            lname = lastname.Text.Trim();
            email = em.Text.Trim();
            course = courseList.SelectedItem.Text;
            lblgendererr.Text = "";
            if (RadioButton1.Checked) gender = "Male";
            if (RadioButton2.Checked) gender = "Female";
            if (gender == "") lblgendererr.Text = "*Required";

            pCountry = ddlCountryPer.SelectedItem.Value;
            pState = ddlStatePer.SelectedItem.Value;
            pCity = ddlCityPer.SelectedItem.Value;
            pPin = ddlPinPer.SelectedItem.Text;

            tCountry = ddlCountryTemp.SelectedItem.Value;
            tState = ddlStateTemp.SelectedItem.Value;
            tCity = ddlCityTemp.SelectedItem.Value;
            tPin = ddlPinTemp.SelectedItem.Text;
        
            string SQL = "InsertAllStudentData";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand(SQL, con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = cmd.Parameters.Add("@fname", SqlDbType.NVarChar, 20);
            param.Value = fname;

            param = cmd.Parameters.Add("@lname", SqlDbType.NVarChar, 20);
            param.Value = lname;

            param = cmd.Parameters.Add("@email", SqlDbType.NVarChar, 15);
            param.Value = email;

            param = cmd.Parameters.Add("@course", SqlDbType.NVarChar, 10);
            param.Value = course;

            param = cmd.Parameters.Add("@gender", SqlDbType.NVarChar, 8);
            param.Value = gender;

            param = cmd.Parameters.Add("@perCountry", SqlDbType.Int);
            param.Value = pCountry;

            param = cmd.Parameters.Add("@perState", SqlDbType.Int);
            param.Value = pState;

            param = cmd.Parameters.Add("@perCity", SqlDbType.Int);
            param.Value = pCity;

            param = cmd.Parameters.Add("@tmpCountry", SqlDbType.Int);
            param.Value = tCountry;

            param = cmd.Parameters.Add("@tmpState", SqlDbType.Int);
            param.Value = tState;

            param = cmd.Parameters.Add("@tmpCity", SqlDbType.Int);
            param.Value = tCity;

            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected < 0) Label0.Text = "Successfully added";
                else Label0.Text = "Failed to add";
            }
            catch(Exception exc)
            {
                Label0.Text = "Failed to add!!!";
                lbltest.Text = exc.ToString();
            }
        }

        protected void btnresetPer_Click(object sender, EventArgs e)
        {
            ddlCountryPer.ClearSelection();
            ddlStatePer.ClearSelection();
            ddlCityPer.ClearSelection();
            ddlPinPer.ClearSelection();
            /*
            this.BindDropDown(ddlCountryPer, "select * from Country;", "Country_name", "Country_Id", "-- SELECT --", "Country");
            this.BindDropDown(ddlStatePer, "select * from State;", "State_name", "State_Id", "-- SELECT --", "State");
            this.BindDropDown(ddlCityPer, "select * from city;", "City_name", "City_Id", "-- SELECT --", "City");
            this.BindDropDown(ddlPinPer, "select * from city;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");*/
        }

        protected void btnresettemp_Click(object sender, EventArgs e)
        {
            this.BindDropDown(ddlCountryTemp, "select * from Country;", "Country_name", "Country_Id", "-- SELECT --", "Country");
            this.BindDropDown(ddlStateTemp, "select * from State;", "State_name", "State_Id", "-- SELECT --", "State");
            this.BindDropDown(ddlCityTemp, "select * from city;", "City_name", "City_Id", "-- SELECT --", "City");
            this.BindDropDown(ddlPinTemp, "select * from city;", "Pin_Code", "City_Id", "-- SELECT --", "Pin");
        }
    }
}