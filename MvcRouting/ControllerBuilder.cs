using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artech.MvcRouting
{
    public class ControllerBuilder
    {
        static ControllerBuilder()
        {
            Current = new ControllerBuilder();
        }
        private static IControllerFactory controllerFactory = new DefaultControllerFactory();
        public static ControllerBuilder Current { get; private set; }
        public IControllerFactory GetControllerFactory()
        {
            return controllerFactory;
        }
    }
}
