using DataAccess.Repository;
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

namespace SaleWPFApp
{
    /// <summary>
    /// Interaction logic for AdminManager.xaml
    /// </summary>
    public partial class AdminManager : Window
    {
        private readonly ICourseRepository courseRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IEnrollmentRepository enrollmentRepository;
        private readonly MainWindow mainWindow;
        public AdminManager(ICourseRepository _courseRepository, IStudentRepository _studentRepository, IEnrollmentRepository _enrollmentRepository)
        {
            InitializeComponent();
            this.courseRepository = _courseRepository;
            this.studentRepository = _studentRepository;
            this.enrollmentRepository = _enrollmentRepository;
        }

        private void AdminManager_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
        }

        private void Goto_AdminCourse(object sender, MouseButtonEventArgs e)
        {
            
            AdminCourse adminCourse = new AdminCourse(courseRepository);
            frameMain.Content = adminCourse;
        }

        private void Goto_AdminStudent(object sender, MouseButtonEventArgs e)
        {
           
            AdminStudent adminStudent = new AdminStudent(studentRepository);
            frameMain.Content = adminStudent;
        }
        private void Goto_AdminEnrollment(object sender, MouseButtonEventArgs e)
        {
            
            AdminEnrollment adminEnrollment = new AdminEnrollment(enrollmentRepository);
            frameMain.Content = adminEnrollment;
        }

        
    }
}
