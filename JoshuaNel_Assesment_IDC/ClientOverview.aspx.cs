using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using ClosedXML.Excel;
using System.Net;

namespace JoshuaNel_Assesment_IDC
{
    public partial class ClientOverview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClientSearch_Click(object sender, EventArgs e)
        {
            //Empty Fields Check
            if (txtClientSearch.Text == "")

            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all required fields')", true);

            } else
            {

                //Both Grid Views are filled with information from both tables in the database

                SqlConnection connection = new SqlConnection(@"Data Source=CUR002-5CD80-61;Initial Catalog=IDC_Assesment; Integrated Security=True");

                string client = txtClientSearch.Text;

                SqlCommand clientSearch = new SqlCommand("SELECT *\r\nFROM dbo.Clients\r\n WHERE \r\n IDNumber = @clientID;", connection);
                clientSearch.Parameters.Add("@clientID", System.Data.SqlDbType.VarChar).Value = client;
                SqlDataAdapter adapter = new SqlDataAdapter(clientSearch);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Client_View.DataSource = dt;
                Client_View.DataBind();

                SqlCommand paymentSearch = new SqlCommand("SELECT *\r\nFROM dbo.Payments\r\n WHERE \r\n ClientID = @clientID;", connection);
                paymentSearch.Parameters.Add("@clientID", System.Data.SqlDbType.VarChar).Value = client;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(paymentSearch);
                DataTable dt2 = new DataTable();
                sqlDataAdapter.Fill(dt2);
                PaymentView.DataSource = dt2;
                PaymentView.DataBind();
            }

            
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            //Empty Field Check

            if (txtEmail.Text == "")

            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill all required fields')", true);

            }
            else //If not empty the data from the gridviews will be exported to an excel sheet
            {
                GridView clientGridView = Client_View;
                GridView paymentGridView = PaymentView;
                TextBox emailTextBox = txtEmail;

                DataTable cdt = new DataTable();
                DataTable pdt = new DataTable();

                foreach (TableCell cell in Client_View.HeaderRow.Cells)
                {
                    cdt.Columns.Add(cell.Text);
                }

                foreach (GridViewRow row in clientGridView.Rows)
                {
                    DataRow cdr = cdt.NewRow();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        cdr[i] = row.Cells[i].Text;
                    }
                    cdt.Rows.Add(cdr);
                }

                foreach (TableCell cell in PaymentView.HeaderRow.Cells)
                {
                    pdt.Columns.Add(cell.Text);
                }

                foreach (GridViewRow row in paymentGridView.Rows)
                {
                    DataRow pdr = pdt.NewRow();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        pdr[i] = row.Cells[i].Text;
                    }
                    pdt.Rows.Add(pdr);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(cdt, "ClientOverview");
                    wb.Worksheets.Add(pdt, "PaymentsOverview");

                    string fileName = "ExportedData.xlsx";
                    string filePath = Server.MapPath("~/" + fileName);

                    wb.SaveAs(filePath);

                    SendEmail(emailTextBox.Text, filePath, fileName);

                    System.IO.File.Delete(filePath);
                }
            }

            
        }

        private void SendEmail(string toEmail, string attachmentFilePath, string attachmentFileName)
        {

            //Method that will send the new Excel file to the Clients Email Address

            string fromEmail = "joshuanel10@gmail.com";
            string smtpServer = "smtp-relay.brevo.com";
            string smtpUsername = "joshuanel10@gmail.com";
            string smtpPassword = "v2tNrHR4ExY1PfsT";
            int smtpPort = 587;

            try
            {
                using (SmtpClient smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.Port = smtpPort;
                    smtpClient.EnableSsl = true;

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(fromEmail);
                        mailMessage.To.Add(toEmail);
                        mailMessage.Subject = "Excel Export";
                        mailMessage.Body = "Attached is the Excel file.";
                        mailMessage.Attachments.Add(new Attachment(attachmentFilePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));

                        smtpClient.Send(mailMessage);
                    }
                }

                // Inform the user that the email has been sent
                Response.Write("<script>alert('Email sent successfully.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error sending email: " + ex.Message + "');</script>");
            }

        }
    }
}