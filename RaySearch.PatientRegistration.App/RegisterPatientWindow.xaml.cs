using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RaySearch.PatientRegistration.App.ViewModels;
using RaySearch.PatientRegistration.DomainModel;
using RaySearch.PatientRegistration.DomainModel.Interface;

namespace RaySearch.PatientRegistration.App
{
    /// <summary>
    /// Interaction logic for RegisterPatientView.xaml
    /// </summary>
    public partial class RegisterPatientWindow: Window
    {
        public RegisterPatientWindow(IHospital hospital)
        {
            InitializeComponent();
            var vm = new PatientViewModel((Hospital)hospital);
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = this.Close;

        }
    }
}
