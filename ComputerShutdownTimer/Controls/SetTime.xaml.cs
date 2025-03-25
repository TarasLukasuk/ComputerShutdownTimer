using ComputerShutdownTimer.Converters;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ComputerShutdownTimer.Controls
{
    public partial class SetTime : UserControl
    {
        public SetTime()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty MaxTimeValueProperty = DependencyProperty.Register(nameof(MaxTimeValue), typeof(int), typeof(SetTime), new PropertyMetadata(0));
        public static readonly DependencyProperty LableTextProperty = DependencyProperty.Register(nameof(LableText), typeof(string), typeof(SetTime), new PropertyMetadata(string.Empty));

        private int _value;
        private const int MIN_VALUE = 0;

        [Category("Settings")]
        [Description("The maximum time value that can be set.")]
        [Browsable(true)]
        public int MaxTimeValue
        {
            get => new ObjectToIntegerConverter().Convert(GetValue(MaxTimeValueProperty));
            set => SetValue(MaxTimeValueProperty, value);
        }


        [Category("Settings")]
        [Description("Sets the text in the label")]
        [Browsable(true)]
        public string LableText
        {
            get => new ObjectToStringConverter().Convert(GetValue(LableTextProperty));
            set => SetValue(LableTextProperty, value);
        }

        public int Value
        {
            get => _value;
            private set
            {
                if (value > MaxTimeValue || value < MIN_VALUE)
                {
                    _value = default;
                    ContentUpdates();

                }
                else
                {
                    _value = value++;
                    ContentUpdates();
                }
            }
        }


        private void Reduce_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void Increase_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void ContentUpdates()
        {
            Count.Content = Value.ToString("D2");
        }
    }
}
