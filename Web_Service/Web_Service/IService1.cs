using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Web_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool Register(String fName, String lName, String email, String contact, DateTime dob, String type, String password, DateTime registeredDate);

        [OperationContract]
        int Login(String email, String password);

        [OperationContract]
        User getUser(int userID);

        [OperationContract]
        List<Product> AllProducts();

        [OperationContract]
        Product AboutProduct(int prodID);

        [OperationContract]
        List<Product> ProductFilter(String filterChoice);

        [OperationContract]
        List<Product> PriceFilter(Decimal price);

        [OperationContract]
        bool AddProduct(String prodName, String prodDescription, String prodCategory, Decimal prodPrice, int quantity, String prodSize, String prodColor, String prodImage, DateTime DateAdded);

        [OperationContract]
        bool DeleteProduct(int prodID);

        [OperationContract]
        bool UpdateProduct(Product updatedProd);

        [OperationContract]
        bool AddToCart(int userID, Product prod, int numItems);

        [OperationContract]
        bool DeleteCartProduct(int userID, Product prod);

        [OperationContract]
        bool UpdateCartProduct(int userID, Product prod, int newQuantity);

        [OperationContract]
        List<CartItem> GetUserCartItems(int userID);

    }

}
