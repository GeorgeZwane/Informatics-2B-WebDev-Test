using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application.ServiceReference1;

namespace Web_Application
{
    public partial class AddingProduct : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String category = DropDownListCategories.SelectedValue;
            String size = DropDownListSize.SelectedValue;
            String color = DropDownListColor.SelectedValue;
            int productQuantity = Convert.ToInt32(quantity.Value);
            Decimal priceDecimal = Convert.ToDecimal(nprice.Value);
            string savePath = "";
            DateTime DateAdded = DateTime.Now;
            string fileName = "";

            if (FileUpload1.HasFile)
            {
                
                // Get the file name
                fileName = Path.GetFileName(FileUpload1.FileName);
                // Define the path to save the file
                savePath = Server.MapPath("~/img/") + fileName;

                // Save the file to the server
                FileUpload1.SaveAs(savePath);
                savePath = "img/" + fileName;
            }

            bool addedProduct = sr.AddProduct(pname.Value, pdescription.Value, category, priceDecimal, productQuantity, size, color, savePath, DateAdded);

            if(addedProduct == true)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Label3.Text = "Could not add product. Check if you added correct product data ";
            }
        }
    }
}