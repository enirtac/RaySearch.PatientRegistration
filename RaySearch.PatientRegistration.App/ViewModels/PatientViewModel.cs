using System;
using System.Linq;
using RaySearch.PatientRegistration.App.Utilities;
using RaySearch.PatientRegistration.DomainModel;
using RaySearch.PatientRegistration.DomainModel.Interface;

namespace RaySearch.PatientRegistration.App.ViewModels
{
    public class PatientViewModel:ViewModelBase
    {
        public RelayCommand SaveNewPatientCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
     
        public string PatientName { get; set; }
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }
        private readonly Hospital _hospital;
        public PatientViewModel(IHospital hospital)
        {
            SaveNewPatientCommand = new RelayCommand(SaveNewPatient);
            CloseWindowCommand = new RelayCommand(CloseWindow);
            _hospital = (Hospital)hospital;
        }
        
        public void SaveNewPatient(object obj)
        {
            try
            {
                _hospital.RegisterPatient(PatientName);
                var patient = _hospital.Patients.Where(t => t.Name == PatientName);
                _hospital.ScheduleConsultation(patient.First());
                CloseAction();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        
    }
}
