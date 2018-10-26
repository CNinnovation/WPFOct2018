using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace NumericUpDownLib
{
    public class NumericUpDown2 : RangeBase
    {
        static NumericUpDown2()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown2), new FrameworkPropertyMetadata(typeof(NumericUpDown2)));
        }

        public NumericUpDown2()
        {
            InitializeCommands();         
        }

        public static RoutedCommand IncreaseCommand { get; private set; }
        public static RoutedCommand DecreaseCommand { get; private set; }

        private static void InitializeCommands()
        {
            IncreaseCommand = new RoutedCommand("IncreaseCommand", typeof(NumericUpDown2));
            CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown2), new CommandBinding(IncreaseCommand, OnIncreaseCommand));
            CommandManager.RegisterClassInputBinding(typeof(NumericUpDown2), new InputBinding(IncreaseCommand, new KeyGesture(Key.Up)));

            DecreaseCommand = new RoutedCommand("DecreaseCommand", typeof(NumericUpDown2));
            CommandManager.RegisterClassCommandBinding(typeof(NumericUpDown2), new CommandBinding(DecreaseCommand, OnDecreaseCommand));
            CommandManager.RegisterClassInputBinding(typeof(NumericUpDown2), new InputBinding(DecreaseCommand, new KeyGesture(Key.Down)));
        }

        private static void OnIncreaseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (sender is NumericUpDown2 control)
            {
                control.OnIncrease();
            }
        }
        private static void OnDecreaseCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (sender is NumericUpDown2 control)
            {
                control.OnDecrease();
            }
        }

        protected virtual void OnIncrease() => Value++;

        protected virtual void OnDecrease() => Value--;
    }
}
