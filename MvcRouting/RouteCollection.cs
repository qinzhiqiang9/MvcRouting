using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Web;

namespace Artech.MvcRouting
{
public class RouteCollection: Collection<RouteBase>
{
    public RouteData GetRouteData(HttpContextBase httpContext)
    {
        foreach (RouteBase route in this)
        {
            var routeData = route.GetRouteData(httpContext);
            if (null != routeData)
            {
                return routeData;
            }
        }
        return null;
    }
}
}
