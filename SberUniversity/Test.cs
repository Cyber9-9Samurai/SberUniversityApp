using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SberUniversity
{
    
    public class Test : DependencyObject,ITest
    {
        public static readonly DependencyProperty FirstQuestionProperty;
        public static readonly DependencyProperty SecondQuestionProperty;
        public static readonly DependencyProperty ThirdQuestionProperty;
        public static readonly DependencyProperty FourthQuestionProperty;
        public static readonly DependencyProperty FivesQuestionProperty;

        static Test()
        {
            FirstQuestionProperty = DependencyProperty.Register("FirstQuestion", typeof(double), typeof(Test),new FrameworkPropertyMetadata(0.0,FrameworkPropertyMetadataOptions.None,null),new ValidateValueCallback(ValidateValue));
            SecondQuestionProperty = DependencyProperty.Register("SecondQuestion", typeof(double), typeof(Test), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None, null), new ValidateValueCallback(ValidateValue));
            ThirdQuestionProperty = DependencyProperty.Register("ThirdQuestion", typeof(double), typeof(Test), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None, null), new ValidateValueCallback(ValidateValue));
            FourthQuestionProperty = DependencyProperty.Register("FourthQuestion", typeof(double), typeof(Test), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None, null), new ValidateValueCallback(ValidateValue));
            FivesQuestionProperty = DependencyProperty.Register("FivesQuestion", typeof(double), typeof(Test), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None, null), new ValidateValueCallback(ValidateValue));
        }

        public static bool ValidateValue(object value)
        {
            double val = (double)value;
            if(val >= 0.0 && val <= 2.0)
            {
                return true;
            }
            return false;
        }
        public double FirstQuestion
        {
            get { return (double)GetValue(FirstQuestionProperty); }
            set { SetValue(FirstQuestionProperty, value); }
        }
        public double SecondQuestion
        {
            get { return (double)GetValue(SecondQuestionProperty); }
            set { SetValue(SecondQuestionProperty, value); }
        }
        public double ThirdQuestion
        {
            get { return (double)GetValue(ThirdQuestionProperty); }
            set { SetValue(ThirdQuestionProperty, value); }
        }
        public double FourthQuestion
        {
            get { return (double)GetValue(FourthQuestionProperty); }
            set { SetValue(FourthQuestionProperty, value); }
        }
        public double FivesQuestion
        {
            get { return (double)GetValue(FivesQuestionProperty); }
            set { SetValue(FivesQuestionProperty, value); }
        }

        public double GetTestResults()
        {
            return FirstQuestion + SecondQuestion + ThirdQuestion + FourthQuestion + FivesQuestion;
        }
    }
}
