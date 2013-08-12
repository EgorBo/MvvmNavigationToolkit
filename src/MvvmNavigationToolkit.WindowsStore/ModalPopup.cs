using MvvmNavigationToolkit;

namespace Viber.Metro.Toolkit.Navigation
{
    public class ModalPopupAttribute : PreferredLocationAttribute
    {
        public ModalPopupAttribute()
            : base(ViewPreferredLocationType.WidePanel)
        {
        }

        public ModalPopupAttribute(ViewPreferredLocationType type)
            : base(type)
        {
        }
    }
}