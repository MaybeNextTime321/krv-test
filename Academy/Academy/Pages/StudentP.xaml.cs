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
    /// Логика взаимодействия для StudentP.xaml
    /// </summary>
    public partial class StudentP : Page
    {
        private schoolEntities _db;
        public StudentP( schoolEntities db, Students st)
        {
            _db = db;
            InitializeComponent();
            Mystudent = st;
            DataContext = this;
        }
        public Students Mystudent { get; set; }
        public Students Studentname { get; set; }
        public Students StudentSurname { get; set; }
        private void SaveB_Click(object sender, RoutedEventArgs e)
        {
            _db.SaveChanges();
        }
    }
}
