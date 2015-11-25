using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace MCBattleShip.Behaviors
{
    public class SingleDigitBehavior
    {
        public static readonly DependencyProperty SingleDigitProperty =
            DependencyProperty.RegisterAttached("SingleDigit", typeof(bool), typeof(SingleDigitBehavior), new PropertyMetadata(false, SingleDigitChanged));

        public static bool GetSingleDigit(DependencyObject obj)
        {
            return (bool)obj.GetValue(SingleDigitProperty);
        }

        public static void SetSingleDigit(DependencyObject obj, bool value)
        {
            obj.SetValue(SingleDigitProperty, value);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("^[0-9]$");
            return regex.IsMatch(text);
        }

        private static void SingleDigitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var tb = d as TextBox;
            if (tb != null)
            {
                if ((bool)e.NewValue)
                {
                    tb.PreviewTextInput += tb_PreviewTextInput;
                    tb.AddHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(tb_Pasting));
                }
                else
                {
                    tb.PreviewTextInput -= tb_PreviewTextInput;
                    tb.RemoveHandler(DataObject.PastingEvent, new DataObjectPastingEventHandler(tb_Pasting));
                }
            }
        }

        private static void tb_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            var pastedText = e.DataObject.GetData(typeof(string)) as string;
            if (!IsTextAllowed(pastedText))
            {
                e.CancelCommand();
            }
        }

        private static void tb_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!IsTextAllowed(e.Text))
            {
                e.Handled = true;
            }
        }
    }
}