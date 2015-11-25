using System.Collections.Generic;
using System.Linq;

namespace MCBattleShip.Models
{
    public enum ShipDirection
    {
        Vertical,
        Horizontal
    }

    public struct Coordinates
    {
        public int x, y;

        public Coordinates(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

    public class BattleMap
    {
        public BattleMap()
        {
            this.Initialize();
        }

        public List<Cell> Map { get; set; }

        private List<Ship> ShipsOnMap { get; set; }

        public void AddShip(int numberOfCells, ShipDirection direction, Coordinates startingPoint)
        {
            List<Cell> shipCells = new List<Cell>();
            for (int i = 0; i < numberOfCells; i++)
            {
                var matchedCell = direction == ShipDirection.Horizontal ? Map.Where(c => c.X == startingPoint.x + i && c.Y == startingPoint.y).FirstOrDefault() : Map.Where(c => c.X == startingPoint.x && c.Y == startingPoint.y + i).FirstOrDefault();

                if (matchedCell != null)
                {
                    matchedCell.State = CellState.Ship;
                    shipCells.Add(matchedCell);
                }
            }

            ShipsOnMap.Add(new Ship() { Cells = shipCells });
        }

        public CellState AttackPoint(Coordinates coord)
        {
            var matchedCell = Map.FirstOrDefault(c => c.X == coord.x && c.Y == coord.y);
            if (matchedCell != null)
            {
                if (matchedCell.State != CellState.None)
                {
                    var matchedShip = this.ShipsOnMap.FirstOrDefault(s => s.Cells.Contains(matchedCell));
                    if (matchedShip != null)
                    {
                        matchedShip.AttackShip(matchedCell);
                        if (matchedShip.IsDown)
                        {
                            matchedShip.SinkShip();
                            return CellState.Sank;
                        }
                        return CellState.Hit;
                    }
                }
            }

            return CellState.None;
        }

        private void Initialize()
        {
            ShipsOnMap = new List<Ship>();
            Map = new List<Cell>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Map.Add(new Cell() { X = i, Y = j });
                }
            }
        }
    }
}