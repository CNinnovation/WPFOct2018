using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace NumericUpDownLib
{
    [TemplatePart(Name ="PART_IncreaseButton", Type =typeof(RepeatButton))]
    public class NumericUpDown : Control
    {
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        public NumericUpDown()
        {
            InitializeCommands();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var button = Template.FindName("PART_IncreaseButton", this);
            if (button is RepeatButton b)
            {
                b.Background = new SolidColorBrush(Colors.Blue);
            }
        }

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value", typeof(int), typeof(NumericUpDown),
                new FrameworkPropertyMetadata(0, new PropertyChangedCallback(OnValueChanged),
                                              new CoerceValueCallback(CoerceValue)));

        private static object CoerceValue(DependencyObject element, object value)
        {
            if (element is NumericUpDown control)
            {
                int newValue = (int)value;

                newValue = Math.Max(control.MinValue, Math.Min(control.MaxValue, newValue));
                return newValue;
            }
            else throw new InvalidOperationException($"element is not {nameof(NumericUpDown)}");
        }

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is NumericUpDown control)
            {
                var e = new RoutedPropertyChangedEventArgs<int>(
                    (int)args.OldValue, (int)args.NewValue, ValueChangedEvent);
                control.OnValueChanged(e);
            }
        }

        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent(
            "ValueChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<CultureInfoIetfLanguageTagConverter>), typeof(NumericUpDown));

        public event RoutedPropertyChangedEventHandler<int> ValueChanged
        {
            add => AddHandler(ValueChangedEvent, value);
            remove => RemoveHandler(ValueChangedEvent, value);
        }

        protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<int> args) =>
            RaiseEvent(args);

        public static RoutedCommand IncreaseCommand { get; private set; }
        public static RoutedCommand DecreaseCommand { get; private set; }

        private static void InitializeCommands()
        {
            IncreaseCommand = new RoutedCommand("IncreaseCommand", typeof(NumericUpDown));
            CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown), new CommandBinding(IncreaseCommand, OnIncreaseCommand));
            CommandManager.RegisterClassInputBinding(typeof(NumericUpDown), new InputBinding(IncreaseCommand, new KeyGesture(Key.Up)));

            DecreaseCommand = new RoutedCommand("DecreaseCommand", typeof(NumericUpDown));
            CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown), new CommandBinding(DecreaseCommand, OnDecreaseCommand));
            CommandManager.RegisterClassInputBinding(typeof(NumericUpDown), new InputBinding(DecreaseCommand, new KeyGesture(Key.Down)));
        }

        private static void OnIncreaseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (sender is NumericUpDown control)
            {
                control.OnIncrease();
            }
        }
        private static void OnDecreaseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (sender is NumericUpDown control)
            {
                control.OnDecrease();
            }
        }

        protected virtual void OnIncrease() => Value++;

        protected virtual void OnDecrease() => Value--;

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(NumericUpDown), new PropertyMetadata(100));

        public int MinValue
        {
            get => (int)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));
    }
}
