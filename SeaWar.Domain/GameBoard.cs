using System.Collections.Generic;

namespace SeaWar.Domain
{
    public sealed class GameBoard
    {
        public string[] HorizontalLabels { get; } = {"А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К"};
        public string[] Vertical { get; } = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};

        public GameBoard()
        {
            initDesk();
        }

        public string Name { get; private set; }

        public List<Cell> Cells { get; private set; }

        public List<Ship> Ships { get; private set; }

        public Cell getCell(Cell cell)
        {
            return Cells.Find(x => x.Equals(cell));
        }

        public Ship getShipByTargetCell(Cell cell)
        {
            return null;
        }
        
        private void initDesk()
        {
            Cells = new List<Cell>();
            for (var i = 0; i < HorizontalLabels.Length; i++)
            for (var j = 0; j < Vertical.Length; j++)
                Cells.Add(new Cell(HorizontalLabels[i] + Vertical[j], Cell.CellState.Empty));
        }
    }
}