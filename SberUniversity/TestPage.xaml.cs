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

namespace SberUniversity
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        Frame _MainFrame;
        MainPage _Mainpage;
        Test test1 = new();
        public TestPage(Frame frame,MainPage page)
        {
            _MainFrame = frame;
            _Mainpage = page;
            InitializeComponent();
            slider1.ApplyTemplate();
            var track1 = slider1.Template.FindName("PART_Track", slider1) as Track;
            if (track1?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track1.IncreaseRepeatButton);
            }
            slider2.ApplyTemplate();
            var track2 = slider2.Template.FindName("PART_Track", slider2) as Track;
            if (track2?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track2.IncreaseRepeatButton);
            }
            slider3.ApplyTemplate();
            var track3 = slider3.Template.FindName("PART_Track", slider3) as Track;
            if (track3?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track3.IncreaseRepeatButton);
            }
            slider4.ApplyTemplate();
            var track4 = slider4.Template.FindName("PART_Track", slider4) as Track;
            if (track4?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track4.IncreaseRepeatButton);
            }
            slider5.ApplyTemplate();
            var track5 = slider5.Template.FindName("PART_Track", slider5) as Track;
            if (track5?.IncreaseRepeatButton != null)
            {
                IncreaseButtonClip(track5.IncreaseRepeatButton);
            }
            
        }

        private void Return(object sender,RoutedEventArgs e)
        {
            _MainFrame.Navigate(_Mainpage);
        }
        private void Sent(object sender, RoutedEventArgs e)
        {
            test1 = (Test)this.Resources["test1"];
            _MainFrame.Navigate(new ResultPageVar1(_MainFrame,_Mainpage,test1));
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
                figure.Segments.Add(new LineSegment(new Point(w-r,0),true));
                figure.Segments.Add(new ArcSegment(new Point(w-7,r),new Size(r,r),0,false,SweepDirection.Clockwise,true));
                figure.Segments.Add(new LineSegment(new Point(w-7, h - r), true));
                figure.Segments.Add(new ArcSegment(new Point(w-r,h),new Size(r,r),0,false,SweepDirection.Clockwise,true));
                figure.Segments.Add(new LineSegment(new Point(0,h),true));
                figure.Segments.Add(new LineSegment(new Point(0, 0), true));

                var geometry = new PathGeometry();
                geometry.Figures.Add(figure);
                repeatButton.Clip = geometry;
            };
        }

    }
    
}
