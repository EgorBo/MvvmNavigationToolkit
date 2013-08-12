using System;
#if WINDOWS_PHONE
using System.Windows;
#else
using Windows.UI.Xaml;
#endif
using MvvmNavigationToolkit.Contracts;

namespace MvvmNavigationToolkit
{
    public class NavigationRegisteredViewModel<TViewModel>
    {
        private readonly NavigationBuilder _builder;
        private readonly IIoCContainerBuilder _containerBuilderBuilder;
        private bool _isStaticResource;
        private string _staticResourceKey = string.Empty;
        private bool _singleInstance;
        private Type _viewModelInterfaceType;

        internal NavigationRegisteredViewModel(NavigationBuilder builder, IIoCContainerBuilder containerBuilderBuilder)
        {
            _builder = builder;
            _containerBuilderBuilder = containerBuilderBuilder;
        }

        public NavigationBuilder ForView<TView>() where TView : FrameworkElement
        {
            WithoutView();
            _builder.ViewsMap[typeof(TViewModel)] = typeof(TView);
            return _builder;
        }

        public NavigationBuilder WithoutView()
        {
            if (_singleInstance)
            {
                if (_viewModelInterfaceType != null)
                    _containerBuilderBuilder.RegisterAsSingleton(typeof (TViewModel), _viewModelInterfaceType);
                else
                    _containerBuilderBuilder.RegisterAsSingleton(typeof (TViewModel));
            }
            else
            {
                if (_viewModelInterfaceType != null)
                    _containerBuilderBuilder.Register(typeof(TViewModel), _viewModelInterfaceType);
                else
                    _containerBuilderBuilder.Register(typeof(TViewModel));
            }
            if (_isStaticResource)
            {
                _builder.AddStaticViewModel<TViewModel>(_staticResourceKey);
            }
            return _builder;
        }

        /// <summary>
        /// Injects specified vm into App.Resources[key]=vm so you can access to it
        /// from any places via "{Binding Foo, Source={StaticResource key}}"
        /// NOTE: SingleInstance().AsStaticResource() equals to just AsStaticResource()
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public NavigationRegisteredViewModel<TViewModel> StaticResource(string key = "")
        {
            _staticResourceKey = key;
            _isStaticResource = true;
            return Singleton(); //static resource can't be a not single instance
        }

        public NavigationRegisteredViewModel<TViewModel> As<TViewModelInterface>()
        {
            _viewModelInterfaceType = typeof (TViewModelInterface);
            return this;
        }

        /// <summary>
        /// Registers ViewModel as single instance (singleton) in IoC
        /// </summary>
        /// <returns></returns>
        public NavigationRegisteredViewModel<TViewModel> Singleton()
        {
            _singleInstance = true;
            return this;
        }
    }
}