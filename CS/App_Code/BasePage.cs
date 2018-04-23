using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

public class BasePage : System.Web.UI.Page {
    static Operation Operation {
        get {
            if (HttpContext.Current.Session["_Operation"] == null)
                HttpContext.Current.Session["_Operation"] = new Operation();
            return HttpContext.Current.Session["_Operation"] as Operation;
        }
    }

    [WebMethod(EnableSession = true)]
    public static string GetProgress() {
        if (HttpContext.Current.Session == null || !(HttpContext.Current.Session["_Operation"] is Operation))
            return "NaN";
        var progress = (HttpContext.Current.Session["_Operation"] as Operation).Progress;
        return progress.ToString();
    }

    [WebMethod(EnableSession = true)]
    public static void StartOperation() {
        Operation.AsyncStart(5000);
    }
}
