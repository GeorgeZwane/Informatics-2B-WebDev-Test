using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application.ServiceReference1;

namespace Web_Application
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            String display1 = "";
            String display2 = "";
            int userID = Convert.ToInt32(Session["loggedInUser"]);
            int parameterValue = Convert.ToInt32(Request.QueryString["logout"]);
            User loggedUser = sr.getUser(userID);

            if(parameterValue == -1)
            {
                Session["loggedInUser"] = null;
            }

            if(Session["loggedInUser"] != null)
            {
                display1 += "<li><a href='#'>" + loggedUser.User_Type + "</a></li>";
                display1 += "<li><a href='#'><i class='fa fa-user-o'></i>Welcome " + loggedUser.FirstName + "</a></li>";

                display2 += "<li><a class='nav-link-login' href='Index.aspx'>Home</a></li>";
                display2 += "<li><a class='nav-link-register' href='Index.aspx?logout=-1'>Logout</a></li>";
            }
            else
            {
                display1 += "<li><a href='#'><i class='fa fa-dollar'></i>USD</a></li>";
                display1 += "<li><a href='#'><i class='fa fa-user-o'></i>My Account</a></li>";

                display2 += "<li><a class='nav-link-home' href='Index.aspx'>Home</a></li>";
                display2 += "<li><a class='nav-link-login' href='Login.aspx'>Login</a></li>";
                display2 += "<li><a class='nav-link-register' href='Register.aspx'>Register</a></li>";
            }

            userAccount.InnerHtml = display1;
            navChange.InnerHtml = display2;
        }
    }
}