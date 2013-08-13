using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MvvmNavigationToolkit
{
    public abstract class NavigationManagerBase
    {
        private readonly NavigationBuilder _navigationBuilder;

        protected NavigationManagerBase(NavigationBuilder navigationBuilder)
        {
            _navigationBuilder = navigationBuilder;
        }

        public Dictionary<Type, Type> ViewsMap { get { return _navigationBuilder.ViewsMap; } }

        public abstract Type[] RootViews { get; }

        public abstract void StartupNavigation(Frame rootFrame, string arguments);

        public void Navigate<T>(T viewModel)
        {
            var page = ViewsMap[viewModel.GetType()];

            var frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                frame = new Frame();
                Window.Current.Content = frame;   
            }

            if (frame.Content is FrameworkElement)
            {
                var dc = ((FrameworkElement) frame.Content).DataContext;
                if (dc != null && dc.Equals(viewModel))
                    return;
            }

            bool isRootPage = RootViews.Contains(page.GetType());
            if (isRootPage)
            {
                //quick way to clear the navigation history
                frame = new Frame();
                frame.Style = ((Frame)Window.Current.Content).Style;
                Window.Current.Content = frame;   
            }

            var preferredLocation = GetPreferredLocation(page);

            switch (preferredLocation)
            {
                case ViewPreferredLocationType.Page:
                    bool navigationResult = frame.Navigate(page, ViewModelsRegistry.Register(viewModel));
                    break;
                case ViewPreferredLocationType.SettingsPanel:
                    PopupsController.ShowPopupView(Activator.CreateInstance(page) as FrameworkElement, viewModel,
                        (SettingsPane.Edge == SettingsEdgeLocation.Right) ? DockType.Right : DockType.Left);
                    break;
                case ViewPreferredLocationType.LeftPanel:
                    PopupsController.ShowPopupView(Activator.CreateInstance(page) as FrameworkElement, viewModel, DockType.Left);
                    break;
                case ViewPreferredLocationType.RightPanel:
                    PopupsController.ShowPopupView(Activator.CreateInstance(page) as FrameworkElement, viewModel, DockType.Right);
                    break;
                case ViewPreferredLocationType.WidePanel:
                    PopupsController.ShowPopupView(Activator.CreateInstance(page) as FrameworkElement, viewModel, DockType.StrechedHorizontal);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void NavigateBack()
        {
            var frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                //TODO: clarify situation
                throw new NotImplementedException();
            }

            frame.GoBack();
        }

        public bool CanNavigateBack()
        {
            var frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                //TODO: clarify situation
                throw new NotImplementedException();
            }

            return frame.CanGoBack;
        }

        /// <summary>
        /// Removes the last page from navigation stack
        /// Unlike the WP, Metro doesn't provide suitable method to do it, so this ugly workaround that
        /// I've copied  from someone's blog does the job
        /// </summary>
        public static void PopCurrentFrame(Frame frame)
        {
            string navigationHistory = frame.GetNavigationState();
            var history = new List<string>(navigationHistory.Split(','));

            history.RemoveRange(history.Count - 2, 2);

            int numberOfPages = int.Parse(history[1]);
            int currentPageIndex = int.Parse(history[2]);

            numberOfPages--;
            currentPageIndex--;

            history[1] = numberOfPages.ToString();
            history[2] = currentPageIndex.ToString();

            string newHistory = String.Join<string>(",", history.AsEnumerable());

            frame.SetNavigationState(newHistory);
        }

        /// <summary>
        /// Gets preferred location for the view
        /// </summary>
        private ViewPreferredLocationType GetPreferredLocation(Type type)
        {
            var result = ViewPreferredLocationType.Page;
            var attribute = type.GetTypeInfo().GetCustomAttribute<PreferredLocationAttribute>();
            if (attribute != null)
            {
                result = attribute.LocationType;
            }
            return result;
        }
    }
}
