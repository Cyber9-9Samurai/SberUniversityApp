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

namespace SberUniversity
{
    /// <summary>
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        MainPage _MainPage;
        Frame _MainFrame;
        public EndPage(Frame frame,MainPage main)
        {
            _MainPage = main;
            _MainFrame = frame;
            InitializeComponent();
        }

        private void ToMain(object sender,RoutedEventArgs e)
        {
            _MainFrame.Navigate(_MainPage);
        }
    }
}
