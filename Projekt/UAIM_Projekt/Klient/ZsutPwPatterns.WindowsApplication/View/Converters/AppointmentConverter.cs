//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Patterns.WindowsApplication.View
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Windows.UI.Xaml.Data;

    using ZsutPw.Patterns.WindowsApplication.Model;

    public class AppointmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "";
            AppointmentDto appointment = (AppointmentDto)value;

             return String.Format("\nCreator Id: {0},\nState: {1},\nCreation date: {2},\nAppointment Date: {3},\nPatient Id: {4},\nDoctor Id: {5},\nTreatment Ids: {6},\nNote: {7}\n",
             appointment.CreatorId, appointment.State, appointment.CreationDate?.ToShortDateString(), appointment.AppointmentDate?.ToShortDateString(), appointment.PatientId, appointment.DoctorId, string.Join(", ", appointment.TreatmentIds), appointment.Note);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
