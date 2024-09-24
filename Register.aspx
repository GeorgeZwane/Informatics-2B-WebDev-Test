<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web_Application.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-body">
            <section class="register-form-container">
                <div class="register-header-container">
                    <h1 class="register-title">Register</h1>
                </div>
                <div class="register-body-container">
                    <label for="fname"><b>FirstName</b></label>
                    <input type="text" name="fname" required runat="server" id="fname">

                    <label for="lname"><b>LastName</b></label>
                    <input type="text" name="lname" required runat="server" id="lname">

                    <label for="dob"><b>Date of Birth</b></label>
                    <input type="date" name="dob" placeholder="YYYY-MM-DD" runat="server" id="dob" required>

                    <label for="email"><b>Email Address</b></label>
                    <input type="text" name="email" required runat="server" id="email">

                    <label for="contact"><b>Contact No</b></label>
                    <input type="text" name="contact" required runat="server" id="contact">

                    <label for="psw"><b>Password</b></label>
                    <input type="password" name="psw" required runat="server" id="psw">

                    <label for="psw1"><b>Confirm Password</b></label>
                    <input type="password" name="psw1" required runat="server" id="psw1">

                    <label for="userType"><b>User Type</b></label>
                    <asp:DropDownList ID="DropDownListUsertype" runat="server" CssClass="select-options">
                        <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                        <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <asp:Label ID="Label2" runat="server" Text="" style="font-family: Arial; font-size:16px; color: red; margin-left: 200px; margin-top: 20px;"></asp:Label>
                <div class="register-button-container">
                   
                    <asp:Button class="register-button" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"/>
                   
                </div>
            </section>
        </section>
</asp:Content>
