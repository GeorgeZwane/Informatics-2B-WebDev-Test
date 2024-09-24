<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddingProduct.aspx.cs" Inherits="Web_Application.AddingProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- BREADCRUMB -->
		<div id="breadcrumb" class="section">
			<!-- container -->
			<div class="container">
				<!-- row -->
				<div class="row">
					<div class="col-md-12">
						<div class="section-title">
							<h3 class="title">Add Product</h3>
						</div>
					</div>
				</div>
				<!-- /row -->
			</div>
			<!-- /container -->
		</div>
		<!-- /BREADCRUMB -->

    <section class="ProductAdd-form-body">
            <section class="ProductAdd-form-container">
                <div class="ProductAdd-header-container">
                    <h1 class="ProductAdd-title">Product</h1>
                </div>
                <div class="ProductAdd-body-container">
                    <label for="pname"><b>Product Name</b></label>
                    <input type="text" name="pname" required runat="server" id="pname">

                    <label for="pdescription"><b>Description</b></label>
                    <input type="text" name="pdescription" required runat="server" id="pdescription">

                    <label for="category"><b>Category</b></label>
                    <asp:DropDownList ID="DropDownListCategories" runat="server" CssClass="select-options">
                        <asp:ListItem Text="Smartphone" Value="Smartphone"></asp:ListItem>
                        <asp:ListItem Text="Laptop" Value="Laptop"></asp:ListItem>
                        <asp:ListItem Text="Camera" Value="Camera"></asp:ListItem>
                        <asp:ListItem Text="Accessory" Value="Accessory"></asp:ListItem>
                    </asp:DropDownList>

                    <label for="size"><b>Size</b></label>
                    <asp:DropDownList ID="DropDownListSize" runat="server" CssClass="select-options">
                        <asp:ListItem Text="11.1 INCH" Value="11.1 INCH"></asp:ListItem>
                        <asp:ListItem Text="12 INCH" Value="12 INCH"></asp:ListItem>
                        <asp:ListItem Text="6.6 INCH" Value="6.6 INCH"></asp:ListItem>
                        <asp:ListItem Text="Small" Value="Small"></asp:ListItem>
                    </asp:DropDownList>

                    <label for="color"><b>Color</b></label>
                    <asp:DropDownList ID="DropDownListColor" runat="server" CssClass="select-options">
                        <asp:ListItem Text="Red" Value="Red"></asp:ListItem>
                        <asp:ListItem Text="Blue" Value="Blue"></asp:ListItem>
                        <asp:ListItem Text="Black" Value="Black"></asp:ListItem>
                        <asp:ListItem Text="Silver" Value="Silver"></asp:ListItem>
                    </asp:DropDownList>

                    <label for="quantity"><b>Quantity</b></label>
                    <input type="text" name="quantity" required runat="server" id="quantity">

                    <label for="price"><b>Price</b></label>
                    <input type="text" name="nprice" placeholder="0.00" required runat="server" id="nprice"/>

                    <label for="picture">Add product image:</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                 <asp:Label ID="Label3" runat="server" Text="" style="font-family: Arial; font-size:16px; color: red; margin-left: 200px; margin-top: 20px;"></asp:Label>
                <div class="ProductAdd-button-container">
                   
                    <asp:Button class="ProductAdd-button" ID="btnAdd" runat="server" Text="Add Product" OnClick="btnAdd_Click"/>
                   
                </div>
            </section>
        </section>
</asp:Content>
