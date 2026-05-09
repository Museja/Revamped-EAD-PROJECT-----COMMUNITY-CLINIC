using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOLLCommunityClinicWeb1
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string email = txtEmail.Text;
                string message = txtMessage.Text;

                //allows clients to submit messages through the contact form, which will be sent to the clinic's email address for review and response.

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("yourappemail@gmail.com");
                mail.To.Add("millermonique2024@gmail.com");
                mail.Subject = "New Contact Form Message - MOLL Clinic";

                mail.Body = $"Name: {name}\nEmail: {email}\n\nMessage:\n{message}";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("yourappemail@gmail.com", "your-app-password");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                lblStatus.Text = "Your message has been sent successfully!";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error sending message. Please try again.";
            }
        }
    }
}