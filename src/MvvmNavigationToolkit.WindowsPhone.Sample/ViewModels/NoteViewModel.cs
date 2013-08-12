namespace MvvmNavigationToolkit.WindowsPhone.Sample.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        public NoteViewModel() { }

        public NoteViewModel(string name, string desc)
        {
            _name = name;
            _description = desc;
        }

        private string _name;
        private string _description;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
    }
}