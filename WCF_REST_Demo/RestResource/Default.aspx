<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RestResource.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
      <Services>
        <asp:ServiceReference Path="~/AjaxEnabled.svc" />
      </Services>
      <Scripts>
        <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.js" />
      </Scripts>
    </asp:ScriptManager>
    <script type="text/javascript">
      function SayHi(nameId, helloResultId) {
        var name = $(nameId)[0].value;
        var ajaxCall = new AjaxEnabled();
        ajaxCall.SayHello(name,
          function(result) {
            $(helloResultId).html(result);
          },

          function(result) {
            alert("Failed: " + result);
          });
      }
    </script>
    <div>
      What is your name? <input id="name" maxlength="25" />
      <input type="button" onclick="SayHi('#name', '#helloResult');" value="Say Hi"/>
    </div>
    <div id="helloResult"></div>
    </form>
</body>
</html>
