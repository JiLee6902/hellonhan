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
    /// Interaction logic for AdminCourseCreate.xaml
    /// </summary>
    public partial class AdminCourseCreate : Window
    {
        private readonly ICourseRepository courseRepository;
        private readonly AdminCourse adminCourse;
        private Course? course;
        public AdminCourseCreate(AdminCourse _adminCourse, Course? course, ICourseRepository _courseRepository)
        {
            InitializeComponent();
            this.courseRepository = _courseRepository;
            this.adminCourse = _adminCourse;
            this.course = course;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (course != null)
            {
                txtBoxTitle.Text = course.Title;
                txtBoxId.Text = course.CourseId.ToString();
                txtBoxId.Visibility = Visibility.Visible;
                labelId.Visibility = Visibility.Visible;
                btn.Content = "Update";
                this.Height = 550;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int courseId = int.Parse(txtBoxId.Text);
            string title = txtBoxTitle.Text;
            int credits = int.Parse(txtBoxCredits.Text);


            Course? p = null;
            if (course != null)
            {
                p = course;
            }
            else
            {
                p = new Course();
            }
            p.CourseId = courseId;
            p.Title = title;
            p.Credits = credits;

            if (course != null)
            {
                courseRepository.Update(p);
            }
            else
            {
                courseRepository.Add(p);
            }
            this.Close();
            adminCourse.RefreshListView();
        }
    }
}
