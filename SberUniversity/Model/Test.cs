using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SberUniversity.Model
{
    
    public class Test : INotifyPropertyChanged,ITest
    {
        private double question1;
        private double question2;
        private double question3;
        private double question4;
        private double question5;

        public double FirstQuestion
        {
            get { return question1; }
            set { question1 = value; OnPropertyChanged(); }
        }
        public double SecondQuestion
        {
            get { return question2; }
            set { question2 = value; OnPropertyChanged(); }
        }
        public double ThirdQuestion
        {
            get { return question3; }
            set { question3 = value; OnPropertyChanged(); }
        }
        public double FourthQuestion
        {
            get { return question4; }
            set { question4 = value; OnPropertyChanged(); }
        }
        public double FivesQuestion
        {
            get { return question5; }
            set { question5 = value; OnPropertyChanged(); }
        }

        public double GetTestResults()
        {
            return FirstQuestion + SecondQuestion + ThirdQuestion + FourthQuestion + FivesQuestion;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
