using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SberUniversity.ViewModel
{
    public partial class EndPageViewModel: INotifyPropertyChanged
    {
        Frame _MainFrame;
        MainPage _MainPage;
        public EndPageViewModel(Frame frame,MainPage page)
        {
            _MainFrame = frame;
            _MainPage = page;
        }

        [RelayCommand]
        private void ToMain()
        {
            _MainFrame.Navigate(_MainPage);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propName));
        }
    }
}
