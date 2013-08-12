using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace MvvmNavigationToolkit.WindowsPhone.Sample.Infrastructure
{
    public class LayerModule : Module
    {
        protected sealed override void Load(ContainerBuilder builder)
        {
            foreach (var childModule in ChildModules)
            {
                childModule.Load(builder);
            }
            OnMap(builder);
            base.Load(builder);
        }

        protected virtual void OnMap(ContainerBuilder builder)
        {
        }

        protected virtual IEnumerable<LayerModule> ChildModules
        {
            get { return Enumerable.Empty<LayerModule>(); }
        }

        public virtual void OnPostContainerBuild(IContainer container)
        {
        }
    }
}
