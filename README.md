MvvmNavigationToolkit
=====================

Navigation toolkit for Windows Phone &amp; Windows Store apps

It's all about wiring VM together with Views using fluent syntax:

            _navigationBuilder
                .RegisterViewModel<FrameViewModel>().StaticResource().WithoutView()
                .RegisterViewModel<MainViewModel>().Singleton().ForView<MainPage>()
                .RegisterViewModel<NotesViewModel>().StaticResource().ForView<NotesView>()
                .RegisterViewModel<NoteViewModel>().ForView<NoteView>()
                .RegisterViewModel<AppSettingsViewModel>().ForView<AppSettingsView>()
                ;
                
And now in any ViewModel you can open one in this way:

        ServiceLocator.Resolve<NotesViewModel>().Show();
