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
using System.Collections.Generic;
using RaySearch.PatientRegistration.App.Utilities;
using RaySearch.PatientRegistration.DomainModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace RaySearch.PatientRegistration.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public RelayCommand OpenRegisterPatientWindowCommand { get; set; }
        public RelayCommand OpenConsultationWindowCommand { get; set; }

        public ObservableCollection<Patient> Patients => _pObserver.Patients;
        public ObservableCollection<Consultation> Consultations => _cObserver.Consultations;

        private readonly Hospital _hospital;
        private readonly ConsultationObserver _cObserver;
        private readonly PatientObserver _pObserver;


        public MainWindowViewModel()
        {
            OpenRegisterPatientWindowCommand = new RelayCommand(OpenRegisterNewPatientWindow);
            OpenConsultationWindowCommand = new RelayCommand(OpenRegisterNewConsultationWindow);

            _hospital = new Hospital();
            _cObserver = new ConsultationObserver();
            _cObserver.Subscribe(_hospital.WhenConsultationScheduled);            
            _pObserver = new PatientObserver();
            _pObserver.Subscribe(_hospital.WhenPatientRegistered);

        }
        private void OpenRegisterNewPatientWindow(object obj)
        {
            var view = new RegisterPatientWindow(_hospital);
            view.ShowDialog();
        }
        private void OpenRegisterNewConsultationWindow(object obj)
        {
            var view = new ConsultationWindow(_hospital,Patients);
            view.ShowDialog();
        }
     
    }
}
