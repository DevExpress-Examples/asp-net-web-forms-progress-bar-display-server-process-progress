<!-- default file list -->
*Files to look at*:

* [BasePage.cs](./CS/App_Code/BasePage.cs) (VB: [BasePage.vb](./VB/App_Code/BasePage.vb))
* [Operation.cs](./CS/App_Code/Operation.cs) (VB: [Operation.vb](./VB/App_Code/Operation.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx](./VB/Default.aspx))
* [jQuery.aspx](./CS/jQuery.aspx) (VB: [jQuery.aspx.vb](./VB/jQuery.aspx.vb))
* [jQuery.aspx.cs](./CS/jQuery.aspx.cs) (VB: [jQuery.aspx.vb](./VB/jQuery.aspx.vb))
* [ScriptManager.aspx](./CS/ScriptManager.aspx) (VB: [ScriptManager.aspx.vb](./VB/ScriptManager.aspx.vb))
* [ScriptManager.aspx.cs](./CS/ScriptManager.aspx.cs) (VB: [ScriptManager.aspx.vb](./VB/ScriptManager.aspx.vb))
<!-- default file list end -->
# How to track progress of server side processing on the client side (using WebMethods)


<p>This example demonstrates one of many possible scenarios when a client should be notified of the progress of a server process. Web methods allow you to make a request from the client and return information that can be restored and used to display a current progress, without refreshing the whole page. <br><br>The sample demonstrates how to use web methods in two ways

* Using the jQuery library (the jQuery.aspx page);
* Using ScriptManager (the ScriptManager.aspx page);<br><br>Note that web methods <strong>should have the [WebMethod] attribute</strong> (WebMethod(EnableSession = true) if you use the session). They are defined in the BasePage class that is used by both the jQuery and ScriptManager pages.</p>
<p><br>To call a web method using jQuery, perform a POST request to the method:</p>


```js
WebMethodRequest("jQuery.aspx/StartOperation");
...
function WebMethodRequest(url, callback) {
    $.ajax({
        url: url,
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        success: callback
    });
}
```


<p>In case you use ScriptManager, the syntax would be as follows:</p>


```js
PageMethods.StartOperation();
```


<br>
<p>Please refer to the following links to know more:<br><a href="http://msdn.microsoft.com/en-us/library/bb398998.aspx">Exposing Web Services to Client Script</a> <br><a href="http://stackoverflow.com/questions/9854006/how-to-call-webmethod">How to call WebMethod?</a></p>
<p>This example extends the following one: <a href="https://www.devexpress.com/Support/Center/p/E918">How to display progress information about server-side callback processing</a>.</p>
<p><strong>See also</strong><strong>:<br> </strong><a href="https://www.devexpress.com/Support/Center/p/E4656">How to track progress of server side processing on the client side (using HttpModule)</a><br><a href="https://www.devexpress.com/Support/Center/p/E4651">How to track progress of server side processing on the client side (using HttpHandler)</a><br><a href="https://www.devexpress.com/Support/Center/p/T518056">ASPxGridView - How to show a lengthy operation's progress and allow canceling such operations</a></p>

<br/>


