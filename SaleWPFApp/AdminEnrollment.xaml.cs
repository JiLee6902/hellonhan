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
    /// Interaction logic for AdminEnrollment.xaml
    /// </summary>
    public partial class AdminEnrollment : Page
    {
        private readonly IEnrollmentRepository enrollmentRepository;
        public AdminEnrollment(IEnrollmentRepository _enrollmentRepository)
        {
            InitializeComponent();
            this.enrollmentRepository = _enrollmentRepository;
            this.listView.SelectionChanged += ListView_SelectionChanged;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = enrollmentRepository.List();
        }
        public void RefreshListView()
        {
            listView.ItemsSource = enrollmentRepository.List();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView? listView = sender as ListView;
            GridView? gridView = listView != null ? listView.View as GridView : null;

            var width = listView != null ? listView.ActualWidth - SystemParameters.VerticalScrollBarWidth : this.Width;

            var column1 = 0.2;
            var column2 = 0.2;
            var column3 = 0.2;
            var column4 = 0.2;
  

            if (gridView != null && width >= 0)
            {
                gridView.Columns[0].Width = width * column1;
                gridView.Columns[1].Width = width * column2;
                gridView.Columns[2].Width = width * column3;
                gridView.Columns[3].Width = width * column4;
            }
        }

        private void Button_OpenCreate(object sender, RoutedEventArgs e)
        {
            AdminEnrollmentCreate adminEnrollmentCreate = new AdminEnrollmentCreate(this, null, enrollmentRepository);
            adminEnrollmentCreate.Show();
        }

        private void Button_Reload(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = enrollmentRepository.List();
        }


      


        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            int count = listView.SelectedItems.Count;
            if (count > 0)
            {
                List<Enrollment> enrollments = listView.SelectedItems.Cast<Enrollment>().ToList();
                enrollments.ForEach(enrollment =>
                {
                    AdminEnrollmentCreate enrollmentCreate = new AdminEnrollmentCreate(this, enrollment, enrollmentRepository);
                    enrollmentCreate.Show();
                });
            }
            else
            {
                MessageBox.Show("Plase select product");
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

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Do you wan't remove course seledted?", "Remove course", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                List<Enrollment> enrollments = listView.SelectedItems.Cast<Enrollment>().ToList();
                enrollments.ForEach(enrollment => enrollmentRepository.Remove(enrollment));
                listView.ItemsSource = enrollmentRepository.List();
            }
        }
    }
}
