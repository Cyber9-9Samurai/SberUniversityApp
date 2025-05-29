using Microsoft.Extensions.Hosting;
using SberUniversity.Model;
using SberUniversity.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace SberUniversity
{
    /// <summary>
    /// Логика взаимодействия для ResultPageVar1.xaml
    /// </summary>
    public partial class ResultPageVar1 : Page
    {
       
        public ResultPageVar1(Frame mainFrame, MainPage mainPage, ITest test)
        {
            InitializeComponent();
            var ResultData = new ResultPageViewModel(mainFrame,mainPage,test,this);
            DataContext = ResultData;
            ResultData.CheckResults();
            ResultData.SetupAnimation();
        }
    }
}
