using BusinessObject.Model;
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
    /// Interaction logic for AdminEnrollmentCreate.xaml
    /// </summary>
    public partial class AdminEnrollmentCreate : Window
    {
        private readonly IStudentRepository studentRepository;
        private readonly IEnrollmentRepository enrollmentRepository;
        private readonly AdminEnrollment adminEnrollment;
        private Enrollment? enrollment;
        private Student? students;
       

        


        public AdminEnrollmentCreate(AdminEnrollment _adminEnrollment, Enrollment? enrollment, IEnrollmentRepository _enrollmentRepository)
        {
            InitializeComponent();
            this.enrollmentRepository = _enrollmentRepository;
            this.adminEnrollment = _adminEnrollment;
            this.enrollment = enrollment;
           
        }

     
        private void Window_Loaded(object sender, RoutedEventArgs e, ComboBox cbStudentId)
        {
      
            if (enrollment != null)
            {

                
                txtBoxCourse.Text = enrollment.CourseId.ToString();
                txtBoxGrade.Text = enrollment.Grade.ToString();
                txtBoxId.Text = enrollment.EnrollmentId.ToString();

                txtBoxId.Visibility = Visibility.Visible;
               
                labelId.Visibility = Visibility.Visible;
                btn.Content = "Update";
                this.Height = 550;
            }
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            int courseId = int.Parse(txtBoxCourse.Text);
            int grade = int.Parse(txtBoxGrade.Text);


            Enrollment? p = null;
            if (enrollment != null)
            {
                p = enrollment;
            }
            else
            {
                p = new Enrollment();
            }
          
            
            p.CourseId = courseId;
            p.Grade = grade;
           

            if (enrollment != null)
            {
                enrollmentRepository.Update(p);
            }
            else
            {
                enrollmentRepository.Add(p);
            }
            this.Close();
            adminEnrollment.RefreshListView();
        }

       
    }
}
