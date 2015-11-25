using MCBattleShip.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace MCBattleShip.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private BattleMap battleMap;
        private string currentState;
        private int inputX;

        private int inputY;

        private List<Cell> map;
        private Dictionary<CellState, string> stateToText;

        public MainViewModel()
        {
            AttackCommand = new RelayCommand(ExecutAttackCommandd, CanExecuteAttackCommand);

            this.currentState = string.Empty;
            stateToText = new Dictionary<CellState, string>();
            stateToText.Add(CellState.Hit, "Hit");
            stateToText.Add(CellState.None, "Miss");
            stateToText.Add(CellState.Sank, "Ship sank");

            InitializeBattle();
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AttackCommand
        {
            get;
            internal set;
        }

        public string CurrentState
        {
            get
            {
                return this.currentState;
            }

            set
            {
                if (this.currentState != value)
                {
                    this.currentState = value;
                    this.OnPropertyChanged("CurrentState");
                }
            }
        }

        public string InputX
        {
            get
            {
                return this.inputX.ToString();
            }

            set
            {
                int intValue;
                if (int.TryParse(value, out intValue) && this.inputX != intValue)
                {
                    this.inputX = intValue;
                    this.OnPropertyChanged("InputX");
                }
            }
        }

        public string InputY
        {
            get
            {
                return this.inputY.ToString();
            }

            set
            {
                int intValue;
                if (int.TryParse(value, out intValue) && this.inputY != intValue)
                {
                    this.inputY = intValue;
                    this.OnPropertyChanged("InputY");
                }
            }
        }

        public List<Cell> Map
        {
            get
            {
                return this.map;
            }

            set
            {
                if (this.map != value)
                {
                    this.map = value;
                    this.OnPropertyChanged("Map");
                }
            }
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="name">The name of the property.</param>
        protected void OnPropertyChanged(string name)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private bool CanExecuteAttackCommand(object obj)
        {
            return true;
        }

        private void ExecutAttackCommandd(object obj)
        {
            var attackResult = battleMap.AttackPoint(new Coordinates(inputX, inputY));
            CurrentState = stateToText[attackResult];
        }

        private void InitializeBattle()
        {
            battleMap = new BattleMap();
            battleMap.AddShip(5, ShipDirection.Vertical, new Coordinates(0, 0));
            battleMap.AddShip(4, ShipDirection.Horizontal, new Coordinates(2, 5));
            battleMap.AddShip(3, ShipDirection.Vertical, new Coordinates(7, 1));
            battleMap.AddShip(3, ShipDirection.Vertical, new Coordinates(8, 4));
            battleMap.AddShip(1, ShipDirection.Horizontal, new Coordinates(3, 9));
            this.map = battleMap.Map;
        }
    }
}