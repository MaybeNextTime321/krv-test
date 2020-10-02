using Academy.Pages;
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

namespace Academy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Start());
        }

        private void studentsB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("U click on students");
            MainFrame.Navigate(new SudentsP());
        }

        private void gradeB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("U click on grades");
            MainFrame.Navigate(new GradeP());
        }

        private void settingsB_Click(object sender, RoutedEventArgs e)
        {
            var sw = new SettingsWindow();
            var sw2 = new SettingsWindow();
            sw2.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            sw.Show();
            sw2.Show();
        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack ==true)
            {
                MainFrame.GoBack();
            }
        }
    }
}
