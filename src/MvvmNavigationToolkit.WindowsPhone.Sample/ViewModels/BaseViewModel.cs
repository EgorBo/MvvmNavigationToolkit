using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmNavigationToolkit.WindowsPhone.Sample.Infrastructure;

namespace MvvmNavigationToolkit.WindowsPhone.Sample.ViewModels
{
    public class BaseViewModel : ViewModelBase, INavigatableViewModel
    {
        private ICommand _show = null;
        private readonly List<RelayCommand> _commands = new List<RelayCommand>();
        private bool _isBusy;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Shows frame busy indicator if true
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
                ServiceLocator.Resolve<FrameViewModel>().IsBusy = value;
            }
        }

        public ICommand ShowCommand
        {
            get { return _show ?? (_show = new RelayCommand(Show)); }
        }

        public Dispatcher Dispatcher { get { return Deployment.Current.Dispatcher; } }

        public virtual void Show()
        {
            if (IsInDesignMode)
                return;

            Dispatcher.BeginInvoke(() =>
                {
                    IsBusy = true;
                    ServiceLocator.Resolve<NavigationManagerBase>().Navigate(this);
                    IsBusy = false;
                });
        }

        public virtual void OnNavigatedTo() { }

        public virtual void OnNavigatedFrom() { }

        protected ICommand CreateCommand(Action action, Func<bool> canExecute = null)
        {
            var command = canExecute == null ? new RelayCommand(action) : new RelayCommand(action, canExecute);
            _commands.Add(command);
            return command;
        }

        protected void UpdateCanExecutes()
        {
            _commands.ForEach(i => i.RaiseCanExecuteChanged());
        }

        protected void SetPropertyAndRefreshCanExecute<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            SetProperty(ref storage, value, propertyName);
            UpdateCanExecutes();
        }
    }
}
