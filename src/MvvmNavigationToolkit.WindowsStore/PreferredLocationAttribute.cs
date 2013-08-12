using System;

namespace MvvmNavigationToolkit
{
    public class PreferredLocationAttribute : Attribute
    {
        public ViewPreferredLocationType LocationType { get; private set; }

        public PreferredLocationAttribute(ViewPreferredLocationType locationType)
        {
            LocationType = locationType;
        }
    }
}