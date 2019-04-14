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

using RaySearch.PatientRegistration.App.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RaySearch.PatientRegistration.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }
}
