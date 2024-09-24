using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Application.ServiceReference1;

namespace Web_Application
{
    public partial class Index : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder display = new StringBuilder();
            dynamic prodList = sr.AllProducts();
            //dynamic prodList = Session["filteredList"];
            //if (prodList == null)
            //{
            //    Session["filteredList"] = sr.AllProducts();
            //    prodList = Session["filteredList"];
            //}


            foreach (Product p in prodList)
            {
                //    display += "<div class='product-block'>";
                //    display += "<div class='image-block'>";
                //    display += "<a href='AboutProduct.aspx?aboutPage=" + p.Prod_Id + "'>";
                //    display += "<img src=" + p.Prod_Image + ">";
                //    display += "</a>";
                //    display += "</div>";
                //    display += "<div class='product-name-block'>";
                //    display += "<a href='AboutProduct.aspx?aboutPage=" + p.Prod_Id + "'><h3 class='product-name'>"+ p.Prod_Name+ "</H3>";
                //    display += "</a>";
                //    display += "</div>";
                //    display += "</div>";
                //    display += "<div class='category-block'><p class='product-category'>" + p.Prod_Category +"</p></div><div class='price-block'><h4 class='product-price'>R"+ p.Prod_Price +"</h4></div>";




                display.Append("<div class='product'><div class='product-img'><a href=\"AboutProduct.aspx?ProductId=" + p.Prod_Id + "\"><img src='" + p.Prod_Image + "'alt='' /></a><div class='product-label'><span class='sale'>30%</span><span class='new'>NEW</span></div></div>");
                display.Append( "<div class='product'><div class='product-img'><img src='" + p.Prod_Image + "'alt=''><div class='product-label'><span class='sale'>30%</span><span class='new'>NEW</span></div></div>");
                display.Append("<div class='product-body'><p class='product-category'>" + p.Prod_Category + "</p><h3 class='product-name'><a href='#'>" + p.Prod_Name + "</a></h3><h4 class='product-price'>R" + p.Prod_Price + "</h4>");
                display.Append("<div class='product-rating'><i class='fa fa-star'></i><i class='fa fa-star'></i><i class='fa fa-star'></i><i class='fa fa-star'></i><i class='fa fa-star'></i></div>");
                display.Append("<div class='product-btns'><button class='add-to-wishlist'><i class='fa fa-heart-o'></i><span class='tooltipp'>add to wishlist</span></button><button class='quick-view'><i class='fa fa-eye'></i><span class='tooltipp'>View more</span></button></div></div></div>");
                //
            }
            changeProduct.InnerHtml = display.ToString();
        }

        protected void allProducts_Click(object sender, EventArgs e)
        {
            dynamic allProducts = sr.AllProducts();
            Session["filteredList"] = allProducts;

            Response.Redirect("index.aspx");
        }

        protected void getLaptops_Click(object sender, EventArgs e)
        {
            dynamic allCaps = sr.ProductFilter("Laptop");
            Session["filteredList"] = allCaps;


            Response.Redirect("index.aspx");
        }

        protected void getSmartphones_Click(object sender, EventArgs e)
        {
            dynamic allShirts = sr.ProductFilter("Smartphone");
            Session["filteredList"] = allShirts;

            Response.Redirect("index.aspx");
        }

        protected void getCameras_Click(object sender, EventArgs e)
        {
            dynamic allHoodies = sr.ProductFilter("Camera");
            Session["filteredList"] = allHoodies;

            Response.Redirect("index.aspx");
        }

        protected void getAccessories_Click(object sender, EventArgs e)
        {
            dynamic allHoodies = sr.ProductFilter("Accessory");
            Session["filteredList"] = allHoodies;

            Response.Redirect("index.aspx");
        }
    }
}