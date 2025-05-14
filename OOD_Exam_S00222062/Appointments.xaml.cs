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

namespace OOD_Exam_S00222062
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {
        public Appointments()
        {
            InitializeComponent();
        }

        private void AddAppointment(object sender, RoutedEventArgs e)
        {
            string appointmentNotes = notesTxtBox.Text;
            DateTime newAppointmentTime = appointmentTime.SelectedDate ?? DateTime.Now;
            DateTime newAppointmentDate = appointmentDate.SelectedDate ?? DateTime.Now;
            if (string.IsNullOrWhiteSpace(appointmentNotes))
            {
                MessageBox.Show("Please enter valid appointment notes.");
                return;
            }
            using (var db = new PatientData())
            {
                var appointment = new Appointment
                {
                    AppointmentTime = appointmentTime,
                    AppointmentNotes = appointmentNotes
                };
                db.Appointments.Add(appointment);
                db.SaveChanges();
                MessageBox.Show("Appointment added successfully.");
            }
        }

        private void UpdateAppointment() 
        {
            using (var db = new PatientData())
            {
                var appointment = db.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                if (appointment != null)
                {
                    appointment.AppointmentTime = appointmentTime;
                    appointment.AppointmentNotes = notesTxtBox.Text;
                    db.SaveChanges();
                    MessageBox.Show("Appointment updated successfully.");
                }
                else
                {
                    MessageBox.Show("Appointment not found.");
                }
            }
        }
    }
}
