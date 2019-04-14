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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaySearch.PatientRegistration.App.ViewModels;
using RaySearch.PatientRegistration.DomainModel;
using RaySearch.PatientRegistration.DomainModel.Interface;

namespace RaySearch.PatientRegistration.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void RegisteringNewPatientShouldAlsoScheduleInitialConsultation()
        {
           
            var hospital = new Hospital();
            var vm = new PatientViewModel(hospital);
            var closeActionMock = new Mock<Action>();
            vm.CloseAction = closeActionMock.Object;
            vm.PatientName = "TestPatient";
            vm.SaveNewPatient(null);
            Assert.AreEqual(hospital.Consultations.Count, 1);

        }
        [TestMethod]
        public void RegisteringTwoNewPatientWithTheSameName()
        {

            var hospital = new Hospital();
            var vm = new PatientViewModel(hospital);
            var closeActionMock = new Mock<Action>();
            vm.CloseAction = closeActionMock.Object;
            vm.PatientName = "TestPatient";
            vm.SaveNewPatient(null);
            Assert.AreEqual(hospital.Consultations.Count, 1);
            vm.PatientName = "TestPatient";
            vm.SaveNewPatient(null);
            Assert.AreEqual(vm.ErrorMessage, "A patient with the specifed name already exist.");

        }

    }
}
