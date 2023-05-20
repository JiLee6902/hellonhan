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
    /// Interaction logic for AdminStudentCreate.xaml
    /// </summary>
    /// 
    public partial class AdminStudentCreate : Window
    {
        private readonly IStudentRepository studentRepository;
        private readonly AdminStudent adminStudent;
        private Student? student;
        public AdminStudentCreate(AdminStudent _adminStudent, Student? _student, IStudentRepository _studentRepository)
        {
            InitializeComponent();
            this.studentRepository = _studentRepository;
            this.adminStudent = _adminStudent;
            this.student = _student;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (student != null)
            {
                txtBoxLastName.Text = student.LastName;
                txtBoxFirstMidName.Text = student.FirstMidName;
                txtBoxDate.Text = student.EnrollmentDate.Value.ToString();
                txtBoxId.Text = student.Id.ToString();
                txtBoxId.Visibility = Visibility.Visible;
                labelId.Visibility = Visibility.Visible;
                btn.Content = "Update";
                this.Height = 550;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string lastName = txtBoxLastName.Text;
            string firstMidName = txtBoxFirstMidName.Text;
            DateTime ernrollmentDate = DateTime.Parse(txtBoxDate.Text);


            Student? p = null;
            if (student != null)
            {
                p = student;
            }
            else
            {
                p = new Student();
            }
          
            p.LastName = lastName;
            p.FirstMidName = firstMidName;
            p.EnrollmentDate = ernrollmentDate;

            if (student != null)
            {
                studentRepository.Update(p);
            }
            else
            {
                studentRepository.Add(p);
            }
            this.Close();
            adminStudent.RefreshListView();
        }
    }
}
