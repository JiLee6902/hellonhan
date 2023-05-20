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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaleWPFApp
{
    /// <summary>
    /// Interaction logic for AdminCourse.xaml
    /// </summary>
    public partial class AdminCourse : Page
    {
        private readonly ICourseRepository courseRepository;
        public AdminCourse(ICourseRepository _courseRepository)
        {
            InitializeComponent();
            this.courseRepository = _courseRepository;
            this.listView.SelectionChanged += ListView_SelectionChanged;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = courseRepository.List();
        }

        public void RefreshListView()
        {
            listView.ItemsSource = courseRepository.List();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView? listView = sender as ListView;
            GridView? gridView = listView != null ? listView.View as GridView : null;

            var width = listView != null ? listView.ActualWidth - SystemParameters.VerticalScrollBarWidth : this.Width;

            var column1 = 0.2;
            var column2 = 0.4;
            var column3 = 0.2;


            if (gridView != null && width >= 0)
            {
                gridView.Columns[0].Width = width * column1;
                gridView.Columns[1].Width = width * column2;
                gridView.Columns[2].Width = width * column3;
            }
        }

        private void Button_OpenCreate(object sender, RoutedEventArgs e)
        {
            AdminCourseCreate adminCourseCreate = new AdminCourseCreate(this, null, courseRepository);
            adminCourseCreate.Show();
        }

        private void Button_Reload(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = courseRepository.List();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Button_Delete(sender, e, courseRepository);
        }

        private void Button_Delete(object sender, RoutedEventArgs e, ICourseRepository courseRepository)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you wan't remove course seledted?", "Remove course", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                List<Course> courses = listView.SelectedItems.Cast<Course>().ToList();
                courses.ForEach(course => courseRepository.Remove(course));
                listView.ItemsSource = courseRepository.List();
            }
        }


        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            int count = listView.SelectedItems.Count;
            if (count > 0)
            {
                List<Course> courses = listView.SelectedItems.Cast<Course>().ToList();
                courses.ForEach(course =>
                {
                    AdminCourseCreate courseCreate = new AdminCourseCreate(this, course, courseRepository);
                    courseCreate.Show();
                });
            }
            else
            {
                MessageBox.Show("Plase select course");
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = listView.SelectedItems.Count;
            if (count > 0)
            {
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
            else
            {
                btnEdit.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
        }
    }
}
