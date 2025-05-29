using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SberUniversity.Model;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SberUniversity.ViewModel
{
    public partial class ResultPageViewModel : INotifyPropertyChanged
    {

        private Visibility isPlaceholderVisible = Visibility.Visible;
        private Frame _MainFrame;
        private MainPage _MainPage;
        private ITest _Test;
        private ResultPageVar1 _ResultPage;
        string theme = "SberTest";
        string text = "";
        DispatcherTimer timer = new();
        int dotCount = 0;
        private string headerText;
        private string headText;
        private string program1Text;
        private string description1Text;
        private string program2Text;
        private string description2Text;
        private string program3Text;
        private string description3Text;
        private string AnimText;
        private SolidColorBrush warningForeground;
        private bool isCheked;
        private Visibility loadingVis = Visibility.Collapsed;
        private Visibility errorsVis = Visibility.Collapsed;
        private string emailText;
        private Visibility politicsVis = Visibility.Collapsed;
        private Visibility agrementVis = Visibility.Collapsed;

        public Visibility IsPlaceholderVisible
        {
            get
            {
                return isPlaceholderVisible;
            }
            set
            {
                isPlaceholderVisible = value; OnPropertyChanged();
            }
        }
        public ResultPageViewModel(Frame mainFrame, MainPage mainPage, ITest test, ResultPageVar1 ResultPage)
        {
            _MainFrame = mainFrame;
            _MainPage = mainPage;
            _Test = test;
            _ResultPage = ResultPage;
        }

        public string HeaderText
        {
            get
            {
                return headerText;
            }
            set
            {
                headerText = value;OnPropertyChanged();
            }
        }
        public string HeadText
        {
            get
            {
                return headText;
            }
            set
            {
                headText = value; OnPropertyChanged();
            }
        }
        public string Program1Text
        {
            get
            {
                return program1Text;
            }
            set
            {
                program1Text = value; OnPropertyChanged();
            }
        }
        public string Description1Text
        {
            get
            {
                return description1Text;
            }
            set
            {
                description1Text = value; OnPropertyChanged();
            }
        }
        public string Program2Text
        {
            get
            {
                return program2Text;
            }
            set
            {
                program2Text = value; OnPropertyChanged();
            }
        }
        public string Description2Text
        {
            get
            {
                return description2Text;
            }
            set
            {
                description2Text = value; OnPropertyChanged();
            }
        }
        public string Program3Text
        {
            get
            {
                return program3Text;
            }
            set
            {
                program3Text = value; OnPropertyChanged();
            }
        }
        public string Description3Text
        {
            get
            {
                return description3Text;
            }
            set
            {
                description3Text = value; OnPropertyChanged();
            }
        }
        public string AnimatedText
        {
            get
            {
                return AnimText;
            }
            set
            {
                AnimText = value; OnPropertyChanged();
            }
        }
        public SolidColorBrush WarningForeground
        {
            get
            {
                return warningForeground;
            }
            set
            {
                warningForeground = value; OnPropertyChanged();
            }
        }
        public bool IsCheked
        {
            get
            {
                return isCheked;
            }
            set
            {
                isCheked = value; OnPropertyChanged();
            }
        }
        public Visibility LoadingVisibility
        {
            get
            {
                return loadingVis;
            }
            set
            {
                loadingVis = value; OnPropertyChanged();
            }
        }
        public Visibility ErrorsVisibility
        {
            get
            {
                return errorsVis;
            }
            set
            {
                errorsVis = value; OnPropertyChanged();
            }
        }
        public string EmailText
        {
            get
            {
                return emailText;
            }
            set
            {
                emailText = value;OnPropertyChanged();
            }
        }
        public Visibility PoliticsVisibility
        {
            get
            {
                return politicsVis;
            }
            set
            {
                politicsVis = value; OnPropertyChanged();
            }
        }
        public Visibility AgrementVisibility
        {
            get
            {
                return agrementVis;
            }
            set
            {
                agrementVis = value; OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void CheckResults()
        {
            var result = _Test.GetTestResults();
            if (result <= 2.0)
            {
                HeaderText = "Ваш результат\n0-2 баллов";
                HeadText = "Похоже, вы упускаете карьерные возможности, которые вас\nокружают, а вместе с ними и интересные перспективы. Пройдя\nэтот тест, вы уже сделали первый шаг, поздравляем!\n\nДля дальнейшего развития предлагаем ознакомиться\nс возможностями диагностики и карьерного консультирования\nSberQ.";
                Program1Text = "Upgrade: личностный интенсив";
                Description1Text = "позволит увидеть перспективы и найти свои точка роста";
                Program2Text = "Управление изменениями";
                Description2Text = "научит навигировать компанию в постоянно меняющемся окружении";
                Program3Text = "Бизнес с AI: от теории к практике";
                Description3Text = "программа направлена на изучение процессов разработки и внедрения AI-технологий\nв бизнесе с целью оптимизации процессов и повышение экономической\nэффективности";

            }
            if (result >= 3.0 && result <= 6.0)
            {
                HeaderText = "Ваш результат\n3-6 баллов";
                HeadText = "Вы явно не новичок в развитии, продолжайте в том же духе.\n\nЧтобы выйти на следующий уровень и использовать\nсобственный ресурс по максимуму предлагаем ознакомиться\nс возможностями диагностики и карьерного консультирования\nSberQ.";
                Program1Text = "Upgrade 2: осознанное лидерство";
                Description1Text = "позволит увидеть перспективы и развить свой лидерский потенциал";
                Program2Text = "Мини MBA";
                Description2Text = "даст комплексный набор знаний, инструментов и навыков актуальных для повышения эффективности бизнес-процессов";
                Program3Text = "Цифровая трансформация бизнеса";
                Description3Text = "поможет погрузиться в инновационные технологии и разработать свой проект по\nизменению процессов в компании";
            }
            if (result >= 7.0)
            {
                HeaderText = "Ваш результат\n7-10 баллов";
                HeadText = "Приятно иметь дело с профессионалом! Продолжайте\nв том же духе!\n\nДля достижения самых амбициозных целей предлагаем\nознакомиться с возможностями диагностики и карьерного\nконсультирования SberQ.";
                Program1Text = "Вызов сильных";
                Description1Text = "новая уникальная программа, которая поможет лидерам исследовать свой\nвнутренний ресурс и направить его на достижение новых результатов, даже если\nкажется, что они уже пройдены";
                Program2Text = "STEP";
                Description2Text = "международная программа сделает из вас лидера нового поколения, способного в\nусловиях высокой неопределённости инициировать изменения и управлять ими";
                Program3Text = "Digital Strategy";
                Description3Text = "поможет перестроить текущую бизнес-модель и провести цифровую трансформацию\nбизнеса для завоевания и сохранения лидерской позиции на рынке";
            }
            text = string.Concat(HeaderText, '\n', HeadText, '\n', Program1Text, '\n', Description1Text, '\n', Program2Text, '\n', Description2Text, '\n', Program3Text, '\n', Description3Text);

        }

        public void SetupAnimation()
        {

            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += AnimationLoading;
            timer.Start();
        }

        private void AnimationLoading(object? sender, EventArgs e)
        {
            AnimatedText = "Отправка" + new string('.', dotCount);
            dotCount = (dotCount + 1) % 4;
        }

        [RelayCommand]
        public void PlaceholderVisibleChanged()
        {
            
            if (string.IsNullOrEmpty(EmailText))
            {
                IsPlaceholderVisible = Visibility.Visible;
            }
            else
            {
                IsPlaceholderVisible = Visibility.Collapsed;
            }

        }

        [RelayCommand]
        private void EndTest()
        {
            _MainFrame.Navigate(_MainPage);
        }

        [RelayCommand]
        private async Task GetTheResults()
        {

            WarningForeground = Brushes.Transparent;
            if (IsCheked == true)
            {
                LoadingVisibility = Visibility.Visible;
                var host = App.host.Services.GetRequiredService<IMail>();

                
                try
                {
                    host.LoadMailSettings("mailsettings.json");
                    await host.SentMail(EmailText, theme, text);
                    LoadingVisibility = Visibility.Collapsed;
                    _MainFrame.Navigate(new EndPage(_MainFrame, _MainPage));
                }
                catch (Exception)
                {
                    LoadingVisibility = Visibility.Collapsed;
                    ErrorsVisibility = Visibility.Visible;
                }
                LoadingVisibility = Visibility.Collapsed;

            }
            else
            {
                WarningForeground = Brushes.Red;
            }
        }

        [RelayCommand]
        private void ClosePolitic()
        {
            PoliticsVisibility = Visibility.Collapsed;
        }
        [RelayCommand]
        private void OpenPolitics()
        {
            PoliticsVisibility = Visibility.Visible;
        }

        [RelayCommand]
        private void CloseAgrement()
        {
            AgrementVisibility = Visibility.Collapsed;
        }

        [RelayCommand]
        private void OpenAgrement()
        {
            AgrementVisibility = Visibility.Visible;
        }

        [RelayCommand]
        private void TryAgain()
        {
            EmailText = "";
            IsCheked = false;
            ErrorsVisibility = Visibility.Collapsed;
        }

        [RelayCommand]
        private void ToMainPage()
        {
             ErrorsVisibility = Visibility.Collapsed;
             EmailText = "";
             IsCheked = false;
            _MainFrame.Navigate(_MainPage);

        }
    }
}
