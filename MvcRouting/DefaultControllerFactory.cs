using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Artech.MvcRouting
{
class DefaultControllerFactory : IControllerFactory
{
    public IController CreateController(RequestContext requestContext, string controllerName)
    {
        RouteData routeData = requestContext.RouteData;
        string controllerType = string.Format("{0}Controller", controllerName);
        IController controller;
        controller = this.CreateControler(controllerType);
        if (null != controller)
        {
            return controller;
        }
        foreach (string assembly in routeData.Assemblies)
        {
            controller = this.CreateControler(controllerType, assembly);
            if (null != controller)
            {
                return controller;
            }

            foreach (string ns in routeData.Namespaces)
            {
                controllerType = string.Format("{0}.{1}Controller", ns, controllerName);
                controller = this.CreateControler(controllerType, assembly);
                if (null != controller)
                {
                    return controller;
                }
            }
        }

        throw new InvalidOperationException("Cannot locate the controller");
    }
    private IController CreateControler(string controllerType, string assembly = null)
    {
        Type type = null;
        if (null == assembly)
        {
            type = Type.GetType(controllerType);
        }
        else
        {
            type = Assembly.Load(assembly).GetType(controllerType);
        }
        if (null == type)
        {
            return null;
        }
        return Activator.CreateInstance(type) as IController;
    }
}
}
