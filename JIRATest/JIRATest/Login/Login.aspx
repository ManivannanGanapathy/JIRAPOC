<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JIRATest.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/CommonStyle.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Welcome to Access JIRA</h2>

            <%--<button onclick="document.getElementById('id01').style.display='block'" style="width: auto;">Login</button>--%>

            <%--<div id="id01" class="modal">--%>
           <asp:Label runat="server" ID="LabelWarningErrorMessage" ForeColor="#FF3300" />

                <div class="container">
                    <div class="imgcontainer">
                    <%--<span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal">&times;</span>--%>
                    <img src="../Images/img_avatar2.png" alt="Avatar" class="avatar">
                </div>
                    <label for="uname"><b>Username</b></label>                    
                    <input type="text" runat="server" id="txtUserName" placeholder="Enter Username" name="uname" tabindex="1" required="required">

                    <label for="psw"><b>Password</b></label>
                    <input type="password" runat="server" id="txtUserPwd" placeholder="Enter Password" name="psw" tabindex="2" required="required">

                    <asp:button runat="server" Text="Login" ToolTip="Login" class="loginbtn" OnClick="Login_Click" TabIndex="3" />
                    <label>
                        <input type="checkbox" checked="checked" name="remember">
                        Remember me
                    </label>
                </div>

                <div class="container" style="background-color: #f1f1f1">
                   <%-- <button type="button" onclick="document.getElementById('id01').style.display='none'" class="cancelbtn">Cancel</button>--%>
                    <span class="psw">Forgot <a href="#">password?</a></span>
                </div>
        </div>
    </form>
<%--  
  <form class="modal-content animate" action="/action_page.php" method="post">
  
  </form>--%>


<script>
// Get the modal
var modal = document.getElementById('id01');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
</script>
</body>
</html>
