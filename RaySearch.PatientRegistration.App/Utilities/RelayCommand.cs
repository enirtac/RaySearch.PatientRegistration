//===========================================================================
//
//  Copyright RaySearch Laboratories AB
//  All Rights Reserved
//
//  This file contains proprietary and confidential information and remains
//  the unpublished property of RaySearch Laboratories AB. Use, disclosure,
//  or reproduction is prohibited except as permitted by express written
//  license agreement with RaySearch Laboratories AB.
//
//===========================================================================

using System;
using System.Windows.Input;

namespace RaySearch.PatientRegistration.App.Utilities
{
    public class RelayCommand<T> : ICommand
    {
        private Action<T> _targetExecuteMethod;
        private Func<T, bool> _targetCanExecuteMethod;
        private string _header = String.Empty;

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod = null, string header = null)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
            Header = header;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return _targetCanExecuteMethod(tparm);
            }

            if (_targetExecuteMethod != null)
                return true;

            return false;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            _targetExecuteMethod?.Invoke((T)parameter);
        }

        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
    }

    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }
     
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

    }
}
