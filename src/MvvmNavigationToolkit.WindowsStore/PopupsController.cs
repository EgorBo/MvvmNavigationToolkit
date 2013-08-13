using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using MvvmNavigationToolkit.Contracts;

namespace MvvmNavigationToolkit
{
    internal static class PopupsController
    {
        private static readonly List<Popup> OpenedPopups = new List<Popup>();

        /// <summary>
        /// Shows the specified content in the popup with given viewmodel and preferred location
        /// </summary>
        public static void ShowPopupView(FrameworkElement element, object dataContext, DockType location)
        {
            double panelWidth = element.Width;
            var windowBounds = Window.Current.Bounds;
            var popup = new Popup();
            var closeableDataContext = dataContext as ICloseable;

            bool isModal = element.GetType().HasAttribute(typeof(ModalPopupAttribute));
            popup.IsLightDismissEnabled = !isModal;
            popup.ChildTransitions = new TransitionCollection();
            popup.Closed += (s, e) =>
            {
                if (closeableDataContext != null)
                    closeableDataContext.OnClose();
                if (!OpenedPopups.Contains(popup))
                    OpenedPopups.Add(popup);
            };

            if (closeableDataContext != null)
            {
                closeableDataContext.CloseRequested += (s, e) => popup.IsOpen = false;
            }

            var grid = FindChildOfType<Grid>(Window.Current.Content);
            if (grid != null)
            {
                grid.Children.Add(popup);
            }

            //popup.ChildTransitions.Add(new PaneThemeTransition { Edge = edgeLocation }); //TODO: it sometimes causes a fault, investigate
            element.DataContext = dataContext;

            if (location == DockType.StrechedHorizontal)
            {
                popup.Width = windowBounds.Width;
                popup.Height = windowBounds.Height;
                element.VerticalAlignment = VerticalAlignment.Center;
                popup.SetValue(Canvas.LeftProperty, 0);
                popup.SetValue(Canvas.TopProperty, windowBounds.Height / 4);
                popup.HorizontalAlignment = HorizontalAlignment.Stretch;
                popup.VerticalAlignment = VerticalAlignment.Center;
            }
            else if (location == DockType.Left || location == DockType.Right)
            {
                popup.Width = panelWidth;
                popup.Height = windowBounds.Height;

                popup.SetValue(Canvas.LeftProperty, location == DockType.Right ? (windowBounds.Width - panelWidth) : 0);
                popup.SetValue(Canvas.TopProperty, 0);
                popup.HorizontalAlignment = location == DockType.Right ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            }
            else
            {
                throw new NotImplementedException();
            }

            element.Width = popup.Width;
            element.Height = popup.Height;

            popup.Child = element;
            popup.IsOpen = true;

            OpenedPopups.Add(popup);
        }

        private static T FindChildOfType<T>(DependencyObject root) where T : class
        {
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                for (var i = VisualTreeHelper.GetChildrenCount(current) - 1; i >= 0; i--)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    var typedChild = child as T;
                    if (typedChild != null)
                    {
                        return typedChild;
                    }
                    queue.Enqueue(child);
                }
            }
            return null;
        }
    }
}
