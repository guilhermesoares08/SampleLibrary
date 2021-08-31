<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LibrarySystem.Index" %>

<!DOCTYPE html>

<link href="Style/bootstrap-5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" />
<link href="Style/MainPage.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
</head>
<body>

    <form runat="server">
        <div class="form-row">
            <i class="bi bi-alarm"></i>
        </div>
        <div class="center">
            <div class="col-md-12 text-center">
                <select runat="server" class="btn btn-primary selectMainPage" aria-label="Default select example">
                    <option selected>Autor</option>
                </select>
                <select id="cbFilterGender" runat="server" class="btn btn-primary selectMainPage" aria-label="Default select example">
                </select>
                <select class="btn btn-primary selectMainPage" aria-label="Default select example">
                    <option selected>Nacional</option>
                    <option selected>Internacional</option>
                </select>
            </div>
        </div>
        <div class="belowcenter">
            <div class="col-md-12 text-center">
                <button>botao</button>
            </div>            
        </div>
    </form>
</body>
</html>

<script type="text/javascript">

</script>
