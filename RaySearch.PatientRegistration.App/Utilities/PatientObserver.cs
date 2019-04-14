using System;
using System.Collections.ObjectModel;
using RaySearch.PatientRegistration.DomainModel;

namespace RaySearch.PatientRegistration.App.Utilities
{
    public class PatientObserver:IObserver<Patient>
    {
        private IDisposable _unsubscriber;
        public ObservableCollection<Patient> Patients = new ObservableCollection<Patient>();
   
        public virtual void Subscribe(IObservable<Patient> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }
        public void OnNext(Patient value)
        {
            Patients.Add(value);
        }

        public void OnError(Exception error)
        {
           
        }

        public void OnCompleted()
        {
           _unsubscriber.Dispose();
        }
    }
}
