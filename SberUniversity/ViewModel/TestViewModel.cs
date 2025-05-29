using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Hosting;
using SberUniversity.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SberUniversity.ViewModel
{
    public partial class TestViewModel: INotifyPropertyChanged
    {
        private Test test;
        private Frame _MainFrame;
        private MainPage _page;
        private TestPage _TestPage;
        
        public TestViewModel(Frame frame, MainPage page, TestPage testPage)
        {
            _MainFrame = frame;
            _page = page;
            _TestPage = testPage;
            test = new Test { FirstQuestion = 0, SecondQuestion = 0, ThirdQuestion = 0, FourthQuestion = 0, FivesQuestion = 0 };
            _TestPage.slider1.ApplyTemplate();
            var track1 = _TestPage.slider1.Template.FindName("PART_Track", _TestPage.slider1) as Track;
            if (track1?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track1.IncreaseRepeatButton);
            }
            _TestPage.slider2.ApplyTemplate();
            var track2 = _TestPage.slider2.Template.FindName("PART_Track", _TestPage.slider2) as Track;
            if (track2?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track2.IncreaseRepeatButton);
            }
            _TestPage.slider3.ApplyTemplate();
            var track3 = _TestPage.slider3.Template.FindName("PART_Track", _TestPage.slider3) as Track;
            if (track3?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track3.IncreaseRepeatButton);
            }
            _TestPage.slider4.ApplyTemplate();
            var track4 = _TestPage.slider4.Template.FindName("PART_Track", _TestPage.slider4) as Track;
            if (track4?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track4.IncreaseRepeatButton);
            }
            _TestPage.slider5.ApplyTemplate();
            var track5 = _TestPage.slider5.Template.FindName("PART_Track", _TestPage.slider5) as Track;
            if (track5?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track5.IncreaseRepeatButton);
            }
        }

        public double FirstQuestion
        {
            get { return test.FirstQuestion; }
            set { test.FirstQuestion = value; OnPropertyChanged(); }
        }
        public double SecondQuestion
        {
            get { return test.SecondQuestion; }
            set { test.SecondQuestion = value; OnPropertyChanged(); }
        }
        public double ThirdQuestion
        {
            get { return test.ThirdQuestion; }
            set { test.ThirdQuestion = value; OnPropertyChanged(); }
        }
        public double FourthQuestion
        {
            get { return test.FourthQuestion; }
            set { test.FourthQuestion = value; OnPropertyChanged(); }
        }
        public double FivesQuestion
        {
            get { return test.FivesQuestion; }
            set { test.FivesQuestion = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        [RelayCommand]
        private void Return()
        {
            _MainFrame.Navigate(_page);
        }
        [RelayCommand]
        private void Sent()
        {
            _MainFrame.Navigate(new ResultPageVar1(_MainFrame, _page, test));
        }

        private void IncreaseButtonClip(RepeatButton repeatButton)
        {
            repeatButton.SizeChanged += (s, e) =>
            {
                double h = repeatButton.ActualHeight;
                double w = repeatButton.ActualWidth;
                double r = 20;
                var figure = new PathFigure
                {
                    StartPoint = new Point(0, 0),
                    IsClosed = true
                };
                figure.Segments.Add(new LineSegment(new Point(w - r, 0), true));
                figure.Segments.Add(new ArcSegment(new Point(w - 7, r), new Size(r, r), 0, false, SweepDirection.Clockwise, true));
                figure.Segments.Add(new LineSegment(new Point(w - 7, h - r), true));
                figure.Segments.Add(new ArcSegment(new Point(w - r, h), new Size(r, r), 0, false, SweepDirection.Clockwise, true));
                figure.Segments.Add(new LineSegment(new Point(0, h), true));
                figure.Segments.Add(new LineSegment(new Point(0, 0), true));

                var geometry = new PathGeometry();
                geometry.Figures.Add(figure);
                repeatButton.Clip = geometry;
            };
        }
    }
}
