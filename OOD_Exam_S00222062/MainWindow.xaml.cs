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

namespace OOD_Exam_S00222062
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewPatientsDetail();
        }

        // Add a new patient to the database
        private async void AddPatientDetails(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameTxtBox.Text;
            string surname = surnameTxtBox.Text;

            string phoneNumber = phoneNumberTxtBox.Text;
            DateTime dob = dobCalender.SelectedDate ?? DateTime.Now;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Please enter a valid first name and surname.");
                return;
            }
            
            using (var db = new PatientData())
            {
                var patient = new Patient
                {
                    FirstName = firstName,
                    Surname = surname,
                    DOB = dob,
                    ContactNumber = phoneNumber
                };
                db.Patients.Add(patient);
                await db.SaveChangesAsync();
                MessageBox.Show("Patient details added successfully.");
            }
        }


        // View all patients in the list box
        private void ViewPatientsDetail()
        {
            using (var db = new PatientData())
            {
                List<Patient> patients = db.Patients.ToList();
                patientListBx.ItemsSource = patients;
            }
        }

        // Add a new appointment for the selected patient
        private void AddNewAppointment(object sender, RoutedEventArgs e)
        {
            if (patientListBx.SelectedItem is Patient selectedPatient)
            {
                AppointmentsWindow appointmentsWindow = new AppointmentsWindow(selectedPatient);
                appointmentsWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a patient to add an appointment.");
            }
            
            
        }


    }
}
