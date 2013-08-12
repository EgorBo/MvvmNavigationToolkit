using System;
using System.Collections.Generic;
#if WINDOWS_PHONE
using System.Windows;
#else
using Windows.UI.Xaml;
#endif
using MvvmNavigationToolkit.Contracts;

namespace MvvmNavigationToolkit
{
    public class NavigationBuilder
    {
        private readonly IIoCContainerBuilder _containerBuilderBuilder;
        private readonly Dictionary<string, Type> _viewModelsAsStaticResources = new Dictionary<string, Type>();

        public NavigationBuilder(IIoCContainerBuilder containerBuilderBuilder)
        {
            _containerBuilderBuilder = containerBuilderBuilder;
            ViewsMap = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// Collection of mapped ViewModel to View
        /// </summary>
        public Dictionary<Type, Type> ViewsMap { get; set; }

        /// <summary>
        /// Registers ViewModel
        /// </summary>
        public NavigationRegisteredViewModel<TViewModel> RegisterViewModel<TViewModel>() //where TViewModel : ViewModelBase
        {
            return new NavigationRegisteredViewModel<TViewModel>(this, _containerBuilderBuilder);
        }

        public void RegisterStaticViewModels(Func<Type, object> resolver)
        {
            foreach (var item in _viewModelsAsStaticResources)
            {
                //ContainsKey for metro and Contains for phone... Microsoft, I hate you.
#if WINDOWS_PHONE
                if (!Application.Current.Resources.Contains(item.Key))
                    Application.Current.Resources.Add(item.Key, resolver(item.Value));
#else
                if (!Application.Current.Resources.ContainsKey(item.Key)) 
                    Application.Current.Resources.Add(item.Key, resolver(item.Value));
#endif
            }
        }

        internal void AddStaticViewModel<TViewModel>(string key = "")
        {
            var vmType = typeof (TViewModel);
            _viewModelsAsStaticResources[string.IsNullOrEmpty(key) ? vmType.Name : key] = vmType;
        }
    }
}
