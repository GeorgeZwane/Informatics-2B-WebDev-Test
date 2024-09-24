using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Web_Service
{
    //Class to store values to be showed in a cart
    public class CartItem
    {
        public int Prod_Id { get; set; }
        public string Prod_Name { get; set; }
        public string Prod_Image { get; set; }
        public decimal Prod_Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
    
    public class Service1 : IService1
    {
        DataClasses2DataContext db = new DataClasses2DataContext();

        //Functionality for registering the user
       public bool Register(String fName, String lName, String email, String contact, DateTime dob, String type, String password, DateTime registeredDate)
        {
            var newUser = new User
            {
                FirstName = fName,
                LastName = lName,
                EmailAddress = email,
                ContactNo = contact,
                DateofBirth = dob,
                User_Type = type,
                Password = password,
                User_CreateDate = registeredDate,
            };

            db.Users.InsertOnSubmit(newUser);
            try
            {
                db.SubmitChanges();
                return true;
            }catch(Exception ex){
                ex.GetBaseException();
                return false;
            }
        }

        //Functionality for user login
        public int Login(String email, String password)
        {
            var user = (from u in db.Users
                        where u.EmailAddress.Equals(email) && u.Password.Equals(password)
                        select u).FirstOrDefault();

            if(user != null)
            {
                return user.User_Id;
            }
            else
            {
                return 0;
            }
        }

        //Functionality to get the user
        public User getUser(int userID)
        {
            var registeredUser = (from u in db.Users
                                  where u.User_Id.Equals(userID)
                                  select u).FirstOrDefault();

            if(registeredUser != null)
            {
                var tempUser = new User
                {
                    FirstName = registeredUser.FirstName,
                    LastName = registeredUser.LastName,
                    EmailAddress = registeredUser.EmailAddress,
                    ContactNo = registeredUser.ContactNo,
                    User_Type = registeredUser.User_Type,
                    User_CreateDate = registeredUser.User_CreateDate,
                };
                return tempUser;
            }
            else
            {
                return null;
            }
        }

        //Functionality to get all products
        public List<Product> AllProducts()
        {
            var listProducts = new List<Product>();

            var prodList = (from p in db.Products select p).DefaultIfEmpty();

            if(prodList != null)
            {
                foreach (Product p in prodList)
                {
                    listProducts.Add(p);
                }
                return listProducts;
            }
            else
            {
                return null;
            } 
        }

        //Functionality to return a single product
        public Product AboutProduct(int prodID)
        {
            var product = (from p in db.Products
                           where p.Prod_Id.Equals(prodID)
                           select p).FirstOrDefault();

            if(product != null)
            {
                var prod = new Product
                {
                    Prod_Image = product.Prod_Image,
                    Prod_Name = product.Prod_Name,
                    Prod_Description = product.Prod_Description,
                    Prod_Price = product.Prod_Price,
                    Product_Reviews = product.Product_Reviews,
                    Prod_Category = product.Prod_Category,
                };
                return prod;
            }
            else
            {
                return null;
            }
        }

        //Functionality to filter products according to user choice
        public List<Product> ProductFilter(String filterChoice)
        {
            var filteredList = new List<Product>();

            var prodList = (from p in db.Products
                            where p.Prod_Category.Equals(filterChoice) || p.Prod_Color.Equals(filterChoice) || p.Prod_Size.Equals(filterChoice)
                            select p).DefaultIfEmpty();
            
            if(prodList != null)
            {
                foreach(Product p in prodList)
                {
                    filteredList.Add(p);
                }
                return filteredList;
            }
            else
            {
                return null;
            }
        }

        public List<Product> PriceFilter(Decimal price)
        {
            var filteredList = new List<Product>();

            var prodList = (from p in db.Products
                            where  p.Prod_Price.Equals(price)
                            select p).DefaultIfEmpty();

            if (prodList != null)
            {
                foreach (Product p in prodList)
                {
                    filteredList.Add(p);
                }
                return filteredList;
            }
            else
            {
                return null;
            }
        }

        //Functionality to add a product by the manager
        public bool AddProduct(String prodName, String prodDescription, String prodCategory, Decimal prodPrice, int quantity, String prodSize, String prodColor, String prodImage, DateTime DateAdded)
        {
            var newproduct = new Product
            {
                Prod_Name = prodName,
                Prod_Description = prodDescription,
                Prod_Category = prodCategory,
                Prod_Price = prodPrice,
                Prod_Size = prodSize,
                Prod_Color = prodColor,
                Prod_Image = prodImage,
                Prod_CreateDate = DateAdded,
                Quantity = quantity,
            };

            db.Products.InsertOnSubmit(newproduct);

            try
            {
                db.SubmitChanges();
                return true;
            }catch(Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        //Functionality to delete a product by the manager
        public bool DeleteProduct(int prodID)
        {
            var prod = (from p in db.Products
                        where p.Prod_Id.Equals(prodID)
                        select p).FirstOrDefault();

            if(prod != null)
            {
                try
                {
                    db.Products.DeleteOnSubmit(prod);
                    db.SubmitChanges();
                    return true;
                }catch(Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Functionality to update a product by the manager
        public bool UpdateProduct(Product updatedProd)
        {
            try
            {
                var Prod = (from p in db.Products
                            where p.Prod_Id.Equals(updatedProd.Prod_Id)
                            select p).FirstOrDefault();

                if (Prod != null)
                {

                    Prod.Prod_Name = updatedProd.Prod_Name;
                    Prod.Prod_Description = updatedProd.Prod_Description;
                    Prod.Prod_Category = updatedProd.Prod_Category;
                    Prod.Prod_Price = updatedProd.Prod_Price;
                    Prod.Prod_Size = updatedProd.Prod_Size;
                    Prod.Prod_Color = updatedProd.Prod_Color;
                    Prod.Prod_Image = updatedProd.Prod_Image;

                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
            
        }

        //Functionality to add to cart
        public bool AddToCart(int userID, Product prod, int numItems)
        {
            var userCartProduct = (from c in db.Carts
                            where c.Cart_UserID.Equals(userID) && c.Cart_ProdID.Equals(prod.Prod_Id)
                            select c).FirstOrDefault();

            if(userCartProduct != null)
            {
                userCartProduct.Quantity += numItems;
            }
            else
            {
                var cartItem = new Cart
                {
                    Cart_UserID = userID,
                    Cart_ProdID = prod.Prod_Id,
                    Quantity = numItems,
                };
                db.Carts.InsertOnSubmit(cartItem);
            }
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        //Functionality to delete a product in cart
        public bool DeleteCartProduct(int userID, Product prod)
        {
            var userCartProduct = (from c in db.Carts
                                   where c.Cart_UserID.Equals(userID) && c.Cart_ProdID.Equals(prod.Prod_Id)
                                   select c).FirstOrDefault();

            if (userCartProduct != null)
            {
                try
                {
                    db.Carts.DeleteOnSubmit(userCartProduct);
                    db.SubmitChanges();
                    return true;
                }catch(Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Functionality to update the product in cart
        public bool UpdateCartProduct(int userID, Product prod, int newQuantity)
        {
            var userCartProduct = (from c in db.Carts
                                   where c.Cart_UserID.Equals(userID) && c.Cart_ProdID.Equals(prod.Prod_Id)
                                   select c).FirstOrDefault();

            if (userCartProduct != null)
            {
                try
                {
                    if (newQuantity == 0)
                    {
                        db.Carts.DeleteOnSubmit(userCartProduct);
                    }
                    else
                    {
                        userCartProduct.Quantity = newQuantity;
                    }

                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Functionality to retrieve cart items for a specific user
        public List<CartItem> GetUserCartItems(int userID)
        {
            
            var cartItems = (from c in db.Carts
                             join p in db.Products on c.Cart_ProdID equals p.Prod_Id
                             where c.Cart_UserID == userID
                             select new CartItem
                             {
                                 Prod_Id = p.Prod_Id,
                                 Prod_Name = p.Prod_Name,
                                 Prod_Image = p.Prod_Image,
                                 Prod_Price = p.Prod_Price,
                                 Quantity = c.Quantity,
                                 TotalPrice = c.Quantity * p.Prod_Price
                             }).ToList();

            if(cartItems != null)
            {
                return cartItems;
            }
            else
            {
                return new List<CartItem>();
            }
            
        }

    }
}
