using System.ComponentModel;

namespace MCBattleShip.Models
{
    public enum CellState
    {
        None,
        Hit,
        Sank,
        Ship
    }

    public class Cell: INotifyPropertyChanged
    {
        private CellState cellState;

        public Cell()
        {
            this.State = CellState.None;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CellState State
        {
            get
            {
                return this.cellState;
            }

            set
            {
                if (this.cellState != value)
                {
                    this.cellState = value;
                    this.OnPropertyChanged("State");
                }
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        protected void OnPropertyChanged(string name)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}