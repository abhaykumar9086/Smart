<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Smart.WebApp.CurrentGen.Default" Async="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <script type="text/javascript">
            //Put your JavaScript code here.
        </script>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <div class="demo-container size-narrow">
            <telerik:RadAsyncUpload RenderMode="Lightweight" runat="server" ID="AsyncUpload1" MultipleFileSelection="Automatic" Width="500px" OnFileUploaded="AsyncUpload1_FileUploaded" />
            <telerik:RadProgressArea RenderMode="Lightweight" runat="server" ID="RadProgressArea1" />
            <telerik:RadButton RenderMode="Lightweight" runat="server" ID="RadButton1" Text="Run" OnClick="RadButton1_Click" />
        </div>
        <asp:Label runat="server" ID="lblTest" />
        <div>
        </div>
    </form>
</body>
</html>
