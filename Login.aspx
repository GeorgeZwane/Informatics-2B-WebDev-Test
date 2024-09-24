<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Application.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-body">
            <section class="login-form-container">
                <div class="login-header-container">
                    <h1 class="login-title">Login</h1>
                </div>
                <div class="login-body-container">
                    <label for="username"><b>Username</b></label>
                    <input type="text" name="username" required runat="server" id="username">

                    <label for="psw"><b>Password</b></label>
                    <input type="password" name="psw" required runat="server" id="psw">
                </div>
                
                <asp:Label ID="Label1" runat="server" Text="" style="font-family: Arial; font-size:16px; color: red; margin-left: 100px; margin-top: 10px;"></asp:Label>

                <div class="login-button-container">
                    <asp:Button class="login-button" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
                </div>
            </section>
        </section>
</asp:Content>
