using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// Логика взаимодействия для SudentsP.xaml
    /// </summary>
    public partial class SudentsP : Page, INotifyPropertyChanged
    {
        public SudentsP()
        {
            InitializeComponent();
            DataContext = this;
           
        }
        private   List<Students> _CurrentStudents ;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Students> CurrentStudents {
            get { return _CurrentStudents; }
            
            set {
                
                _CurrentStudents = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentStudents"));
            }
        }
        public List<Grade> AllGrades { get { return _AllGrades; } set { _AllGrades = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AllGrades"));

            } }
        public List<Grade> _AllGrades;
        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = SearchTB.Text;
            CurrentStudents = Core.DB.Students.Where(s => s.Surname.Contains( search) || s.Name.Contains(search) || s.Patronymic.Contains(search)).ToList();



            DataContext = null;
            DataContext = this;
        }
        public bool searchF (Students s)
        {
            return s.Name == SearchTB.Text;
           // if (s.Name == SearchTB.Text ) return true;
            //else return false;

        }

        private void GradesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         var grade = (sender as ComboBox).SelectedItem as Grade;
            //var item = GradesCB.SelectedItem;

            if (grade == null) return;
            CurrentStudents = Core.DB.Students.Where(s => s.GraideId == grade.id).ToList();
            DataContext = null;
            DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentStudents = Core.DB.Students.ToList();
            AllGrades = Core.DB.Grade.ToList();
        }
    }
}
