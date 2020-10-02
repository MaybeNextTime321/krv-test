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

namespace Academy.Pages
{
    /// <summary>
    /// Логика взаимодействия для GradeP.xaml
    /// </summary>
    public partial class GradeP : Page
    {
        public GradeP()
        {
            InitializeComponent();
            DataContext = this;
            AllStudents = Core.DB.Students.ToList();
            AllGrades = Core.DB.Grade.ToList();
            //  var s = db.Students.ToList();
        }
        public List<Students> AllStudents { get; set; }
        public List<Grade> AllGrades { get; set; }

        private void GradeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem) as Grade;
            
            AllStudents = item.Students.ToList();
            StudentsData.ItemsSource = null;
            StudentsData.ItemsSource = AllStudents;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_student_Click(object sender, RoutedEventArgs e)
        {
            var item = StudentsData.SelectedItem as Students;
            Core.DB.Students.Remove(item);
            Core.DB.SaveChanges();
            MessageBox.Show("Студент удален");
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var item = StudentsData.SelectedItem as Students;
            var db = new schoolEntities();
           var st= db.Students.Where(s => s.id == item.id).First();
            NavigationService.Navigate(new StudentP(db,st));
        }
    }
}
