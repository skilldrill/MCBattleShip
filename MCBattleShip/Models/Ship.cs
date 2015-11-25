using System.Collections.Generic;
using System.Linq;

namespace MCBattleShip.Models
{
    public class Ship
    {
        public Ship()
        {
            Cells = new List<Cell>();
        }

        public List<Cell> Cells { get; set; }

        public bool IsDown
        {
            get
            {
                var aliveCell = Cells.FirstOrDefault(c => c.State != CellState.Hit);
                if (aliveCell != null)
                {
                    return false;
                }
                return true;
            }
        }

        public void AttackShip(Cell attackedCell)
        {
            if (attackedCell.State == CellState.Ship)
            {
                attackedCell.State = CellState.Hit;
            }
        }

        public void SinkShip()
        {
            foreach (var cell in Cells)
            {
                cell.State = CellState.Sank;
            }
        }
    }
}