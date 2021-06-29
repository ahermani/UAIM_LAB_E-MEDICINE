
namespace ZsutPw.Patterns.WindowsApplication.View
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using ZsutPw.Patterns.WindowsApplication.Controller;
    using ZsutPw.Patterns.WindowsApplication.Model;
    using ZsutPw.Patterns.WindowsApplication.Utilities;

    public sealed partial class PatientAppointmentsPage : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }

        public PatientAppointmentsPage()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;
        }
        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddAppointmentPage));
        }

        private void EditAppointment_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditAppointmentPage));
        }

        private void ViewAppointment_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AppointmentIdPage));
        }
    }
}
