using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace JoshuaNel_Assesment_IDC
{
    public partial class ClientCapture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnFarmerCreate_Click(object sender, EventArgs e)
        {
            
            
            

            if(txtCallCentre.Text == "" || txtCapturedBy.Text == "" || txtClientEmail.Text == "" || txtClientName.Text == "" || txtClientSurname.Text == "" || txtContactNumber.Text == "" || txtIDNumber.Text == "" || txtAccBal.Text == "")

            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all required fields')", true);

            } else if (checkContactNo(txtContactNumber.Text) == false)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter Valid Cellphone number')", true);

            } else if (checkEmail(txtClientEmail.Text) == false)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter Valid Email Address')", true);
            } else if(checkID(txtIDNumber.Text) == false)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter Valid ID number')", true);
            } else if (checkID(txtIDNumber.Text) && checkEmail(txtClientEmail.Text) && checkContactNo(txtContactNumber.Text))
            {
                var prefix = "+27";
                var fullNumber = prefix + txtContactNumber.Text;


                SqlConnection connection = new SqlConnection(@"Data Source=CUR002-5CD80-61;Initial Catalog=IDC_Assesment; Integrated Security=True");
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Clients]
               ([IDNumber]
               ,[ClientName]
               ,[ClientSurname]
               ,[ContactNumber]
               ,[CallCenterName]
               ,[Email]
               ,[CapturedBy]
               ,[AccountBalance]
               ,[CaptureDate])
           
         VALUES
               ('" + txtIDNumber.Text + "', '" + txtClientName.Text + "', '" + txtClientSurname.Text + "', '" + fullNumber + "', '" + txtCallCentre.Text + "', '" + txtClientEmail.Text + "', '" + txtCapturedBy.Text + "', '"+ txtAccBal.Text +"' ,'" + calCaptureDate.SelectedDate + "')", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                Response.Write("Client Added Succesfully");
                connection.Close();
            }


        }

        private static bool checkID(string inputValue)
        {
            // Replace the desiredOutput with the value you are checking against
            var ID = "[0-9]{13}";

            // Check if the inputValue matches the desiredOutput
            bool isMatch = Regex.IsMatch(inputValue.Trim(), ID);

            return isMatch;
        }

        private static bool checkContactNo(string inputValue)
        {
            var contactNo = "[0-9]{9}";

            bool isMatch = Regex.IsMatch(inputValue.Trim(), contactNo);

            return isMatch;
        }

        private static bool checkEmail(string inputValue)
        {
            var email = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            bool isMatch = Regex.IsMatch(inputValue.Trim(), email);

            return isMatch;
        }

       
    }
}