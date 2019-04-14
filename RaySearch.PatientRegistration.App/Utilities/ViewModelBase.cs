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
using System.ComponentModel;

namespace RaySearch.PatientRegistration.App.Utilities
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Action CloseAction { get; set; }
        public void CloseWindow(object obj)
        {
            CloseAction();
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
