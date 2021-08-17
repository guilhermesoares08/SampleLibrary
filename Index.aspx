<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LibrarySystem.Index" %>

<!DOCTYPE html>
<link href="Style/TabelaPadrao.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
    
        <title></title>
        <style type="text/css">
            #Select1 {
                width: 119px;
            }
        </style>
    </head>
    <body>  
        <form method="post" runat="server">        
            <input id="txtSearch" type="text" runat="server" />


            <input id="btnPesquisa" type="submit" value="Pesquisar" />
            <select id="cbFilterGender" runat="server" name="D1"></select>
            <input id="btnClearFields" type="button" value="Clear fields" onclick="clearFields()" />

            <table>
                <tr> 
                    <th>Id</th>
                    <th>Description</th>
                    <th>Gender</th>
                    <th>Ações</th>
                </tr>
                <% foreach (var item in lstBooks)
                   {%>
                    <tr>
                        <td><%=item.Id %></td>
                        <td><%=item.Description %></td>
                        <td><%=item.Gender %></td>
                        <td><asp:Button ID="Button1" runat="server" Text="Delete" OnClick="DeleteBook" CommandArgument='<%#Eval("LibrarySystem.Domain.Book.Id") %>' /></td>                        
                    </tr>
                 <%}%>
            </table>
        </form>
    </body>
    
</html>

<script type="text/javascript">
    function clearFields() {
        var elements = document.getElementById("cbFilterGender").options;
        document.getElementById("txtSearch").value = "";

        for (var i = 0; i < elements.length; i++) {
            elements[i].selected = false;
        }
    }
</script>
