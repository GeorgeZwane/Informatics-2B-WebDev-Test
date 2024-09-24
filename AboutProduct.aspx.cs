using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application.ServiceReference1;

namespace Web_Application
{
    public partial class AboutProduct : System.Web.UI.Page
    {
        Service1Client cs = new Service1Client();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        System.Text.StringBuilder sbName = new System.Text.StringBuilder();
        System.Text.StringBuilder sbPrice = new System.Text.StringBuilder();
        System.Text.StringBuilder sbDes = new System.Text.StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Request.QueryString["ProductId"]);
            Product p = cs.AboutProduct(pID);

            sb.Append("<div id=\"product-main-img\">");
            sb.Append("<div class=\"product-preview\">");
            sb.Append("<img src =\""+p.Prod_Image+"\">");
            sb.Append("</div>");
            sb.Append("</div>");

            productName.InnerText = p.Prod_Name;
            productPrice.InnerText = p.Prod_Price.ToString();
            productDes.InnerText = p.Prod_Description;

            productImage.InnerHtml = sb.ToString();					
							
						



        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {

        }
    }
}