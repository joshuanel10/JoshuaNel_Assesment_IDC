using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace JoshuaNel_Assesment_IDC
{
    public partial class PaymentCapture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPaymentAdd_Click(object sender, EventArgs e)
        {


            if (txtClientID.Text == "" || txtPaymentAmount.Text == "" || txtReference.Text == "") //Empty Fields Check

            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all required fields')", true);

            } else
            {
                try
                { 
                    using (SqlConnection con = new SqlConnection(@"Data Source=CUR002-5CD80-61;Initial Catalog=IDC_Assesment; Integrated Security=True"))
                    {
                        int newPaymentAmount = Int32.Parse(txtPaymentAmount.Text);
                        string clientID = txtClientID.Text;


                        con.Open();

                        //Adding Payment to Database

                        if (IsPaymentAmountValid(con, clientID, newPaymentAmount))
                        {
                            SqlCommand insert = new SqlCommand(@"INSERT INTO Payments
                        ([ClientID]
                        ,[PaymentAmount]
                        ,[PaymentDate]
                        ,[Reference])
                VALUES
                        ('" + txtClientID.Text + "', '" + txtPaymentAmount.Text + "', '" + calPaymentDate.SelectedDate + "', '" + txtReference.Text + "')", con);

                            insert.ExecuteNonQuery();
                            Response.Write("Payment Added Succesfully");


                            
                            UpdateAccountBalance(con, clientID, newPaymentAmount * -1); //Updating Account Balance

                            
                            UpdatePaymentsToDate(con, clientID); //Updating Payments To Date

                            con.Close();
                        }
                        else
                        {
                            Response.Write("Error: Payment amount exceeds available account balance");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }



            

        }

        //Method to check whether Payment exceeds current account balance
        private static bool IsPaymentAmountValid(SqlConnection connection, string clientID, decimal paymentAmount)
        {
            string getAccountBalanceQuery = "SELECT AccountBalance FROM Clients WHERE IDNumber = @ClientID";

            using (SqlCommand command = new SqlCommand(getAccountBalanceQuery, connection))
            {
                command.Parameters.AddWithValue("@ClientID", clientID);

                // ExecuteScalar returns the first column of the first row in the result set
                decimal accountBalance = Convert.ToDecimal(command.ExecuteScalar());

                return paymentAmount <= accountBalance;
            }
        }

        //Method to Update the Account Balance
        static void UpdateAccountBalance(SqlConnection connection, string clientID, decimal amountToUpdate)
        {
            string updateAccountBalanceQuery = "UPDATE Clients SET AccountBalance = AccountBalance + @AmountToUpdate WHERE IDNumber = @ClientID";

            using (SqlCommand command = new SqlCommand(updateAccountBalanceQuery, connection))
            {
                command.Parameters.AddWithValue("@ClientID", clientID);
                command.Parameters.AddWithValue("@AmountToUpdate", amountToUpdate);

                command.ExecuteNonQuery();
            }
        }


        //Method to Update the PaymentsToDate Field
        private static void UpdatePaymentsToDate(SqlConnection connection, string clientID)
        {
            string updatePaymentsToDateQuery = @"
            WITH UpdatedPayments AS (
                SELECT
                    ClientID,
                    COALESCE(SUM(PaymentAmount), 0) AS NewPaymentsToDate
                FROM Payments
                WHERE ClientID = @ClientID
                GROUP BY ClientID
            )

            UPDATE Clients
            SET PaymentsToDate = UpdatedPayments.NewPaymentsToDate
            FROM UpdatedPayments
            WHERE Clients.IDNumber = UpdatedPayments.ClientID";

            using (SqlCommand command = new SqlCommand(updatePaymentsToDateQuery, connection))
            {
                command.Parameters.AddWithValue("@ClientID", clientID);

                command.ExecuteNonQuery();
            }
        }

    }
}

