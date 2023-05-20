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
    /// Interaction logic for AdminStudent.xaml
    /// </summary>
    public partial class AdminStudent : Page
    {
        private readonly IStudentRepository studentRepository;
        public AdminStudent(IStudentRepository _studentRepository)
        {
            InitializeComponent();
            this.studentRepository = _studentRepository;
            this.listView.SelectionChanged += ListView_SelectionChanged;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = studentRepository.List();
        }

        private void Button_OpenCreate(object sender, RoutedEventArgs e)
        {
            AdminStudentCreate adminStudentCreate = new AdminStudentCreate(this, null, studentRepository);
            adminStudentCreate.Show();
        }

        public void RefreshListView()
        {
            listView.ItemsSource = studentRepository.List();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView? listView = sender as ListView;
            GridView? gridView = listView != null ? listView.View as GridView : null;

            var width = listView != null ? listView.ActualWidth - SystemParameters.VerticalScrollBarWidth : this.Width;

            var column1 = 0.1;
            var column2 = 0.2;
            var column3 = 0.2;
            var column4 = 0.3;


            if (gridView != null && width >= 0)
            {
                gridView.Columns[0].Width = width * column1;
                gridView.Columns[1].Width = width * column2;
                gridView.Columns[2].Width = width * column3;
                gridView.Columns[3].Width = width * column4;
     
            }
        }

        private void Button_Reload(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = studentRepository.List();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you wan't remove member seledted?", "Remove member", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                List<Student> students = listView.SelectedItems.Cast<Student>().ToList();
                students.ForEach(student => studentRepository.Delete(student));
                listView.ItemsSource = studentRepository.List();
            }
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            int count = listView.SelectedItems.Count;
            if (count > 0)
            {
                List<Student> students = listView.SelectedItems.Cast<Student>().ToList();
                students.ForEach(student =>
                {
                    AdminStudentCreate admimStudentCreate = new AdminStudentCreate(this, student, studentRepository);
                    admimStudentCreate.Show();
                });
            }
            else
            {
                MessageBox.Show("Plase select member");
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
