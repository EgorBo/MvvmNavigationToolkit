namespace MvvmNavigationToolkit.WindowsPhone.Sample.DesignTimeViewModels
{
    public class DesignTimeNotesViewModel
    {
        public dynamic Notes
        {
            get
            {
                return new[]
                {
                    new {Name = "note 1", Description = "DesignTime data 1"},
                    new {Name = "note 2", Description = "DesignTime data 2"},
                    new {Name = "note 3", Description = "DesignTime data 3"},
                    new {Name = "note 4", Description = "DesignTime data 4"},
                    new {Name = "note 5", Description = "DesignTime data 5"},
                };
            }
        }
    }
}
