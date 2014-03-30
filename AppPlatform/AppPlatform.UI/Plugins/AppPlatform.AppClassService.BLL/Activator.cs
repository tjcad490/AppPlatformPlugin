using System;
using System.Collections.Generic;
using System.Text;
using UIShell.OSGi;

namespace AppPlatform.AppClassService.BLL
{
    public class Activator : IBundleActivator
    {
        public void Start(IBundleContext context)
        {
            context.AddService<IAppClassService>(new AppClassService());
        }

        public void Stop(IBundleContext context)
        {
            //todo:
        }
    }
}
