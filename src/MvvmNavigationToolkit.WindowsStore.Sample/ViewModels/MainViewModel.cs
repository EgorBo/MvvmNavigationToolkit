using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace MvvmNavigationToolkit.WindowsStore.Sample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NotesViewModel _notesViewModel;
        public MainViewModel(NotesViewModel notesViewModel)
        {
            _notesViewModel = notesViewModel;
        }

        // navigation to the NotesViewModel is done via binding to StaticResource, but you can do it via command here as well
        public ICommand OpenNotes { get { return new RelayCommand(_notesViewModel.Show); }} 
    }
}
