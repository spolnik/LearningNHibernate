<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ordering.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .contacts li
        {
            display: inline;
            float: left;
            margin: 0 0 15px 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LoginStatus ID="loginStatus" runat="server" />
        <br />
        <asp:LoginView ID="loginView" runat="server">
            <AnonymousTemplate>
                <asp:Login ID="login" runat="server" />
            </AnonymousTemplate>
            <LoggedInTemplate>
                Thanks for Logging In
            </LoggedInTemplate>
        </asp:LoginView>
        <asp:LoginView ID="adminLogin" runat="server">
            <RoleGroups>
                <asp:RoleGroup Roles="Administrator">
                    <ContentTemplate>
                        <asp:Button ID="adminOnly" runat="server" />
                    </ContentTemplate>
                </asp:RoleGroup>
            </RoleGroups>
        </asp:LoginView>  
        <asp:ListView ID="contactView" DataSourceID="contactSource" runat="server">
            <LayoutTemplate>
                <ul class="contacts">
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li><p>
                    <%# Eval("LastName") %>,&nbsp;<%# Eval("FirstName") %>
                    <br />
                    <asp:HyperLink NavigateUrl='<%# DataBinder.Eval(
                        Container.DataItem, "Email", "mailto:{0}?subject=NHibernate&body=Hello from NHibernate") %>'
                        Text='<%# Eval("Email") %>' runat="server" />
                </p></li>
            </ItemTemplate>
            <EmptyDataTemplate>
                <div>
                    No contacts were found
                </div>
            </EmptyDataTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="contactSource" 
            DataObjectTypeName="Ordering.Data.Common.Contact"
            TypeName="Ordering.Data.DataAccess.ContactDataControl" 
            SelectMethod="GetAll" runat="server">

        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
