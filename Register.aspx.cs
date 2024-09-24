using HashPass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application.ServiceReference1;

namespace Web_Application
{
    public partial class Register : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            String usertype = DropDownListUsertype.SelectedValue;
            DateTime DoB = DateTime.Parse(dob.Value);
            DateTime userRegisterDate = DateTime.Now;

            bool registered = sr.Register(fname.Value, lname.Value, email.Value, contact.Value, DoB, usertype, Secrecy.HashPassword(psw.Value), userRegisterDate);
            if (psw.Value == psw1.Value && registered == true)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Label2.Text = "Password does not match.";
            }
        }
    }
}