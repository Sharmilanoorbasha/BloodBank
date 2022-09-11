<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="BloodBank.UI.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp Form</title>
    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/Content/css") %>
        <%: Scripts.Render("~/bundles/modernizr") %>
        <%: Scripts.Render("~/bundles/MsAjaxJs") %>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/jquery") %>
        <%: Scripts.Render("~/bundles/bootstrap") %>
    </asp:PlaceHolder>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-center mt-3">
            <h3 class="text-danger">Online BloodBank</h3>
            <h4 class="" style="color: darkblue">Get Signup and Save a Life</h4>
        </div>
        <div class="row w-100">
            <div class="col-6">
                <asp:Image ID="SignUp_Image" runat="server" ImageUrl="~/Content/images/donate_is_help.jpg" alt="donate image" class="img-fluid text-center mt-4 pt-4" />
            </div>
            <div class="col-6 mt-5 rounded border shadow">
                <div class="form-group mt-3">
                    <label for="username" class="pr-5">UserName:</label>
                    <asp:TextBox ID="userName" class="form-control d-inline" AutoCompleteType="DisplayName" runat="server" required="true" Width="400px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="password" class="pr-5 mr-2">Password:</label>
                    <asp:TextBox ID="password" class="form-control d-inline" type="password" runat="server" required="true" Width="400px"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="firstname" class="pr-5 mr-1">FirstName:</label>
                    <asp:TextBox ID="firstName" class="form-control d-inline" runat="server" required="true" Width="400px"></asp:TextBox>
                </div>
                <div class="d-flex">
                    <div class="form-group">
                        <label for="lastname" class="pr-5 mr-1">LastName:</label>
                        <asp:TextBox ID="lastName" class="form-control d-inline" runat="server" required="true" Width="200px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Age" class="pr-3 ml-4">Age:</label>
                        <asp:TextBox ID="age" class="form-control d-inline" type="number" runat="server" required="true" Width="100px"></asp:TextBox>
                    </div>
                </div>
                <div class="d-flex">
                    <div class="form-group">
                        <label for="contactnumber" class="pr-2">ContactNumber:</label>
                        <asp:TextBox ID="contactNumber" class="form-control d-inline" type="number" required="true" runat="server" Width="200px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="email" class="pr-2 ml-4">Email:</label>
                        <asp:TextBox ID="email" class="form-control d-inline" required="true" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </div>
                <div class="d-flex">
                    <div class="form-group">
                        <label for="gender" class="pr-5 mr-5">Gender:</label>
                        <asp:RadioButton ID="male" runat="server" GroupName="Gender" CssClass="pr-3" Text="Male" />
                        <asp:RadioButton ID="female" runat="server" GroupName="Gender" Text="Female" />
                    </div>
                    <div class="form-group">
                        <label for="weight" class="pr-2 ml-5 pl-1">Weight:</label>
                        <asp:TextBox ID="weight" class="form-control d-inline" type="number" required="true" runat="server" Width="100px"></asp:TextBox>
                    </div>
                </div>
                <span class="p-1">Select your Blood Group Type : </span>
                <asp:DropDownList ID="BloodGroupDropDown" CssClass="custom-select ml-4 " runat="server" Width="400px">
                    <asp:ListItem>O+</asp:ListItem>
                    <asp:ListItem>O-</asp:ListItem>
                    <asp:ListItem>A+</asp:ListItem>
                    <asp:ListItem>A-</asp:ListItem>
                    <asp:ListItem>B+</asp:ListItem>
                    <asp:ListItem>B-</asp:ListItem>
                    <asp:ListItem>AB+</asp:ListItem>
                    <asp:ListItem>AB-</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="SignUpWarningText" CssClass="text-center d-block" runat="server" ForeColor="Red"></asp:Label>
                <asp:Button ID="Button1" runat="server" class="offset-4 mt-3 btn btn-primary" Text="Register" OnClick="Button1_Click" />
                <asp:LinkButton ID="LinkButton1" href="login.aspx" class="btn btn-dark mt-3 ml-3" runat="server">Back</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
