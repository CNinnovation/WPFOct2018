using System;
using System.Windows;
using System.Windows.Controls;

namespace NumericUpDownUCSample
{
    public partial class NumericUpDown : UserControl
    {
        public NumericUpDown()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(decimal), typeof(NumericUpDown),
            new FrameworkPropertyMetadata(MinValue, new PropertyChangedCallback(OnValueChanged),
                                      new CoerceValueCallback(CoerceValue)));

        public decimal Value
        {
            get => (decimal)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        private static object CoerceValue(DependencyObject element, object value)
        {
            decimal newValue = (decimal)value;

            newValue = Math.Max(MinValue, Math.Min(MaxValue, newValue));

            return newValue;
        }

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is NumericUpDown control)
            {
                var e = new RoutedPropertyChangedEventArgs<decimal>(
                    (decimal)args.OldValue, (decimal)args.NewValue, ValueChangedEvent);
                control.OnValueChanged(e);
            }
        }

        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
            "ValueChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<decimal>), typeof(NumericUpDown));

        public event RoutedPropertyChangedEventHandler<decimal> ValueChanged
        {
            add => AddHandler(ValueChangedEvent, value);
            remove => RemoveHandler(ValueChangedEvent, value);
        }

        protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<decimal> args) =>
            RaiseEvent(args);

        private void OnUpButton(object sender, EventArgs e) => Value++;

        private void OnDownButton(object sender, EventArgs e) => Value--;

        private const decimal MinValue = 0, MaxValue = 100;
    }
}
