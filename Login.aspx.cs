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
    public partial class Login : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int user = sr.Login(username.Value, Secrecy.HashPassword(psw.Value));

            if (user != 0)
            {
                Session["loggedInUser"] = user;
                Response.Redirect("Index.aspx");
            }
            else
            {
                Label1.Text = "Incorrect Username or Password";
            }
        }
    }
}