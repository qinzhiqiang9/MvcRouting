using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Artech.MvcRouting;

namespace MvcApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new QueryStringRoute());
            RouteTable.Assemblies.Add("MvcApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            RouteTable.Namespaces.Add("Artech.MvcApp");
        }
    }
}