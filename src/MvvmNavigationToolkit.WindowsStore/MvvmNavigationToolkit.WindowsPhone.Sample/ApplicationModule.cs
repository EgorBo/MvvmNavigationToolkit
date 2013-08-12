using Autofac;
using MvvmNavigationToolkit.WindowsPhone.Sample.Infrastructure;
using MvvmNavigationToolkit.WindowsPhone.Sample.Navigation;
using MvvmNavigationToolkit.WindowsPhone.Sample.ViewModels;
using MvvmNavigationToolkit.WindowsPhone.Sample.Views;

namespace MvvmNavigationToolkit.WindowsPhone.Sample
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
                ;

            base.OnMap(builder);
        }

        public override void OnPostContainerBuild(IContainer container)
        {
            _navigationBuilder.RegisterStaticViewModels(container.Resolve);
        }
    }
}
