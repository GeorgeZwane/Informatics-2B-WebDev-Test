<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Web_Application.Cart" %>

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
							<h3 class="title">Cart</h3>
						</div>
					</div>
				</div>
				<!-- /row -->
			</div>
			<!-- /container -->
		</div>
		<!-- /BREADCRUMB -->
    <section class="cart-form-body">
		<div>
			<table class="table-cells">
            <thead>
                <tr>
                    <td></td>
                    <td>Image</td>
                    <td>PRODUCT NAME</td>
                    <td>UNIT PRICE</td>
                    <td>QUANTITY</td>
                    <td>TOTAL PRICE</td>
                </tr>
            </thead>

            <tbody>
                <tr>
                    <td><button>delete</button></td>
                    <td>Image 1</td>
                    <td>Lenovo</td>
                    <td>R9800.00</td>
                    <td class="quantity-block">
						<div class="input-number">
							<input type="number">
							<span class="qty-up">+</span>
							<span class="qty-down">-</span>
						</div>
                    </td>
                    <td>R9800.00</td>
                </tr>

                <tr>
                    <td><button>delete</button></td>
                    <td>Image 2</td>
                    <td>DELL</td>
                    <td>R10800.00</td>
                    <td class="quantity-block">
						<div class="input-number">
							<input type="number">
							<span class="qty-up">+</span>
							<span class="qty-down">-</span>
						</div>
                    </td>
                    <td>R10800.00</td>
                </tr>

                <tr>
                    <td><button>delete</button></td>
                    <td>Image 3</td>
                    <td>Asus</td>
                    <td>R4800.00</td>
                    <td class="quantity-block">
						<div class="input-number">
							<input type="number">
							<span class="qty-up">+</span>
							<span class="qty-down">-</span>
						</div>
                    </td>
                    <td>R9600.00</td>
                </tr>
            </tbody>

            <tfoot>
                <tr>
                    <td colspan="5" align="right">SUBTOTAL</td>
                    <td class="subtotal-amount">R30200.00</td>
                </tr>
            </tfoot>
        </table>

		<div class="buttons-container">
			<div class="shopping-btn-container">
				<asp:Button class="shopping-btn" ID="btnShop" runat="server" Text="Continue Shopping" />
			</div>
			<div class="update-btn-container">
				<asp:Button class="updating-btn" ID="btnUpdate" runat="server" Text="Update Cart" />
			</div>
			<div class="checkout-btn-container">
				<asp:Button class="checkout-btn" ID="btnCheckout" runat="server" Text="Checkout" />
			</div>
		</div>
		</div>
		</section>
</asp:Content>
