using Autofac;
using MvvmNavigationToolkit.WindowsStore.Sample.Infrastructure;
using MvvmNavigationToolkit.WindowsStore.Sample.Navigation;
using MvvmNavigationToolkit.WindowsStore.Sample.ViewModels;
using MvvmNavigationToolkit.WindowsStore.Sample.ViewModels.Settings;
using MvvmNavigationToolkit.WindowsStore.Sample.Views;

namespace MvvmNavigationToolkit.WindowsStore.Sample
{
    public class ApplicationModule : LayerModule
    {
        private NavigationBuilder _navigationBuilder = null;

        protected override void OnMap(ContainerBuilder builder)
        {
            _navigationBuilder = new NavigationBuilder(new ContainerBuilderAdapter(builder));
            
            builder.RegisterInstance(_navigationBuilder).SingleInstance();
            builder.RegisterType<AppNavigationManager>().As<NavigationManagerBase>().SingleInstance();

            _navigationBuilder
                .RegisterViewModel<FrameViewModel>().StaticResource().WithoutView()
                .RegisterViewModel<MainViewModel>().Singleton().ForView<MainPage>()
                .RegisterViewModel<NotesViewModel>().StaticResource().ForView<NotesView>()
                .RegisterViewModel<NoteViewModel>().ForView<NoteView>()
                .RegisterViewModel<AppSettingsViewModel>().ForView<AppSettingsView>()
                ;

            base.OnMap(builder);
        }

        public override void OnPostContainerBuild(IContainer container)
        {
            _navigationBuilder.RegisterStaticViewModels(container.Resolve);
        }
    }
}
