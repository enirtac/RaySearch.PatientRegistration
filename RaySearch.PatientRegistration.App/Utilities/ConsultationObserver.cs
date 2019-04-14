using System;
using System.Collections.ObjectModel;
using System.Linq;
using RaySearch.PatientRegistration.DomainModel;

namespace RaySearch.PatientRegistration.App.Utilities
{
    public class ConsultationObserver:IObserver<Consultation>
    {
        private IDisposable _unsubscriber;
        public ObservableCollection<Consultation> Consultations = new ObservableCollection<Consultation>();

        public virtual void Subscribe(IObservable<Consultation> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }
        public void OnNext(Consultation value)
        {
            Consultations.Add(value);
            
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
