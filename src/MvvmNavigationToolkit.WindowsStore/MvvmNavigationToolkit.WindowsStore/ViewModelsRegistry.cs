using System;
using System.Collections.Generic;

namespace MvvmNavigationToolkit.WindowsStore
{
    public static class ViewModelsRegistry
    {
        private static readonly Dictionary<Guid, object> ViewModels = new Dictionary<Guid, object>();

        /// <summary>
        /// Registers view model in the registry and returns its Id
        /// </summary>
        public static string Register(object viewModel)
        {
            lock (ViewModels)
            {
                var id = Guid.NewGuid();
                ViewModels[id] = viewModel;
                return id.ToString(); 
            }
        }

        /// <summary>
        /// Gets view model by id and deregisters it from the inner list
        /// </summary>
        public static object GetAndDeregister(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;
            Guid vmId;
            if (!Guid.TryParse(id, out vmId))
            {
                //TODO: log
                return null;
            }
            object objRef;
            lock (ViewModels)
            {
                if (ViewModels.TryGetValue(vmId, out objRef) /*&& weakRef.IsAlive*/)
                {
                    ViewModels.Remove(vmId); // to not keeping the reference to the view model
                    return objRef;
                } 
            }
            //TODO: log
            return null;
        }
    }
}
