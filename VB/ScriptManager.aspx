<%@ Page Language="vb" AutoEventWireup="true" CodeFile="ScriptManager.aspx.vb" Inherits="ScriptManager" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function callbackStart(s, e) {
            s.SetEnabled(false);
            PageMethods.StartOperation();
            timer.SetEnabled(true);
        }

        function refreshProgress(s, e) {
            var onSuccess = function (res) {
                var progress = res;
                if (progress == "100") {
                    btn.SetEnabled(true);
                    timer.SetEnabled(false);
                }
                pbar.SetPosition(progress);
            }
            PageMethods.GetProgress(onSuccess);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
            <dx:ASPxProgressBar ID="pbar" runat="server" Height="21px" Width="200px" EnableClientSideAPI="true" ClientInstanceName="pbar"></dx:ASPxProgressBar>
            <dx:ASPxButton ID="btn" runat="server" Text="Start" AutoPostBack="false" EnableClientSideAPI="true" ClientInstanceName="btn">
                <ClientSideEvents Click="function(s, e) { callbackStart(s, e); }" />
            </dx:ASPxButton>
            <dx:ASPxTimer ID="timer" runat="server" ClientInstanceName="timer" Interval="777" Enabled="false">
                <ClientSideEvents Tick="function(s, e) { refreshProgress(s, e); }" />
            </dx:ASPxTimer>
        </div>
    </form>
</body>
</html>