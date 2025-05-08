using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SberUniversity
{
    /// <summary>
    /// Логика взаимодействия для ResultPageVar1.xaml
    /// </summary>
    public partial class ResultPageVar1 : Page
    {
        Frame _MainFrame;
        MainPage _MainPage;
        MailService mail = new();
        string theme = "SberTest";
        string text = "";
        double result;
        DispatcherTimer timer = new();
        int dotCount = 0;

        public ResultPageVar1(Frame mainFrame, MainPage mainPage,ITest test)
        {
            InitializeComponent();
            _MainFrame = mainFrame;
            _MainPage = mainPage;
            result = test.GetTestResults();
            if(result <= 2.0)
            {
                Header.Text = "Ваш результат\n0-2 баллов";
                HeadText.Text = "Похоже, вы упускаете карьерные возможности, которые вас\nокружают, а вместе с ними и интересные перспективы. Пройдя\nэтот тест, вы уже сделали первый шаг, поздравляем!\n\nДля дальнейшего развития предлагаем ознакомиться\nс возможностями диагностики и карьерного консультирования\nSberQ.";
                Program1.Text = "Upgrade: личностный интенсив";
                Description1.Text = "позволит увидеть перспективы и найти свои точка роста";
                Program2.Text = "Управление изменениями";
                Desription2.Text = "научит навигировать компанию в постоянно меняющемся окружении";
                Program3.Text = "Бизнес с AI: от теории к практике";
                Desription3.Text = "программа направлена на изучение процессов разработки и внедрения AI-технологий\nв бизнесе с целью оптимизации процессов и повышение экономической\nэффективности";
                
            }
            if (result >= 3.0 && result <= 6.0)
            {
                Header.Text = "Ваш результат\n3-6 баллов";
                HeadText.Text = "Вы явно не новичок в развитии, продолжайте в том же духе.\n\nЧтобы выйти на следующий уровень и использовать\nсобственный ресурс по максимуму предлагаем ознакомиться\nс возможностями диагностики и карьерного консультирования\nSberQ.";
                Program1.Text = "Upgrade 2: осознанное лидерство";
                Description1.Text = "позволит увидеть перспективы и развить свой лидерский потенциал";
                Program2.Text = "Мини MBA";
                Desription2.Text = "даст комплексный набор знаний, инструментов и навыков актуальных для повышения эффективности бизнес-процессов";
                Program3.Text = "Цифровая трансформация бизнеса";
                Desription3.Text = "поможет погрузиться в инновационные технологии и разработать свой проект по\nизменению процессов в компании";
            }
            if (result >= 7.0)
            {
                Header.Text = "Ваш результат\n7-10 баллов";
                HeadText.Text = "Приятно иметь дело с профессионалом! Продолжайте\nв том же духе!\n\nДля достижения самых амбициозных целей предлагаем\nознакомиться с возможностями диагностики и карьерного\nконсультирования SberQ.";
                Program1.Text = "Вызов сильных";
                Description1.Text = "новая уникальная программа, которая поможет лидерам исследовать свой\nвнутренний ресурс и направить его на достижение новых результатов, даже если\nкажется, что они уже пройдены";
                Program2.Text = "STEP";
                Desription2.Text = "международная программа сделает из вас лидера нового поколения, способного в\nусловиях высокой неопределённости инициировать изменения и управлять ими";
                Program3.Text = "Digital Strategy";
                Desription3.Text = "поможет перестроить текущую бизнес-модель и провести цифровую трансформацию\nбизнеса для завоевания и сохранения лидерской позиции на рынке";
            }
           
            text = string.Concat(Header.Text, '\n', HeadText.Text, '\n', Program1.Text, '\n', Description1.Text, '\n', Program2.Text, '\n', Desription2.Text, '\n', Program3.Text, '\n', Desription3.Text);
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += AnimationLoading;
            timer.Start();
        }

        private void AnimationLoading(object? sender,EventArgs e)
        {
            AnimatedText.Text = "Отправка" + new string('.',dotCount);
            dotCount = (dotCount + 1) % 4;
        }
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text))
                Placeholder.Visibility = Visibility.Visible;
            else
                Placeholder.Visibility = Visibility.Hidden;
        }
        private void EndTest(object sender,RoutedEventArgs e)
        {
            _MainFrame.Navigate(_MainPage);
        }
        private async void GetTheResults(object sender, RoutedEventArgs e)
        {
            
            warning.Foreground = Brushes.Transparent;
            if (Agree.IsChecked == true)
            {
                Loading.Visibility = Visibility.Visible;
                IMail _mail = mail;
                _mail.LoadMailSettings("mailsettings.json");
                try
                {
                     await _mail.SentMail(email.Text, theme, text);
                     Loading.Visibility = Visibility.Collapsed;
                    _MainFrame.Navigate(new EndPage(_MainFrame, _MainPage));
                }
                catch (Exception)
                {
                    Loading.Visibility = Visibility.Collapsed;
                    Errors.Visibility = Visibility.Visible;
                }
                Loading.Visibility = Visibility.Collapsed;
                
            }
            else
            {
                warning.Foreground = Brushes.Red;
            }
        }


        private void ClosePolitic(object sender, RoutedEventArgs e)
        {
            UniversityPolitics.Visibility = Visibility.Collapsed;
        }
        private void OpenPolitics(object sender, MouseEventArgs e)
        {
            UniversityPolitics.Visibility = Visibility.Visible;
        }

        private void CloseAgrement(object sender, RoutedEventArgs e)
        {
            PersonalDataAgrement.Visibility = Visibility.Collapsed;
        }

        private void OpenAgrement(object sender, MouseEventArgs e)
        {
            PersonalDataAgrement.Visibility = Visibility.Visible;
        }

        private void ToMainPage(object sender,RoutedEventArgs e)
        {
            Errors.Visibility = Visibility.Collapsed;
            email.Text = "";
            Agree.IsChecked = false;
            _MainFrame.Navigate(_MainPage);
            
        }

        private void TryAgain(object sender,RoutedEventArgs e)
        {
            email.Text = "";
            Agree.IsChecked = false;
            Errors.Visibility = Visibility.Collapsed;
        }

    }
}
