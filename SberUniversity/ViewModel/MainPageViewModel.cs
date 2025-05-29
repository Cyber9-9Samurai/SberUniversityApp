using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace SberUniversity.ViewModel
{
    public partial class MainPageViewModel : INotifyPropertyChanged
    {

        Frame _MainFrame;
        MainPage _page;
       
        public MainPageViewModel(Frame frame, MainPage page)
        {
            _MainFrame = frame;
            _page = page;
            
        }

        [RelayCommand]
        public void StartTest()
        {
            _MainFrame.Navigate(new TestPage(_MainFrame, _page));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
