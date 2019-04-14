using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using RaySearch.PatientRegistration.App.Utilities;
using RaySearch.PatientRegistration.DomainModel;

namespace RaySearch.PatientRegistration.App.ViewModels
{
    public class ConsultationViewModel : ViewModelBase
    {
        public RelayCommand SaveNewConsultationCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        
        private readonly Hospital _hospital;
        private Patient _currentSelection;
        public ObservableCollection<Patient> Patients { get; set; }

        public ConsultationViewModel(Hospital hospital, ObservableCollection<Patient> patients)
        {
            _hospital = hospital;
            SaveNewConsultationCommand = new RelayCommand(SaveConsultation);
            CloseWindowCommand = new RelayCommand(CloseWindow);
            Patients = patients;

        }
    
        public Patient CurrentSelection
        {
            get => _currentSelection;
            set
            {
                _currentSelection = value;
                OnPropertyChanged(nameof(CurrentSelection));
            }
        }

        private void SaveConsultation(object obj)
        {
           
            var patient = _hospital.Patients.First(t => t.Name == CurrentSelection.Name);
            _hospital.ScheduleConsultation(patient);
            CloseAction();
        }
    }
}
