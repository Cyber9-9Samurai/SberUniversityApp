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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Frame _MainFrame;
        public MainPage(Frame frame)
        {
            _MainFrame = frame;
            InitializeComponent();
        }

        private void TestStartbtn_Click(object sender,RoutedEventArgs e)
        {
            _MainFrame.Navigate(new TestPage(_MainFrame,this));
        }
    }
}
