using MCBattleShip.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MCBattleShip
{
    [ValueConversion(typeof(CellState), typeof(Color))]
    public class StateValueColorConverter: IValueConverter
    {
        private Dictionary<CellState, Color> colorMatch = new Dictionary<CellState, Color>();

        public StateValueColorConverter()
        {
            colorMatch.Add(CellState.None, Colors.White);
            colorMatch.Add(CellState.Sank, Colors.Red);
            colorMatch.Add(CellState.Ship, Colors.Gray);
            colorMatch.Add(CellState.Hit, Colors.Orange);
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CellState state = (CellState)value;
            return new SolidColorBrush(colorMatch[state]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
