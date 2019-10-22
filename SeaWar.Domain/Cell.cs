using System;

namespace SeaWar.Domain
{
    public sealed class Cell
    {
        public enum CellState
        {
            Empty,
            Occupied
        }

        public Cell(string location, CellState state)
        {
            Location = location;
            State = state;
        }
        
        private string Location { get; }

        public CellState State { get; private set; }

        private bool IsHited { get;  set; }

        public void changeIsHited(bool value)
        {
            IsHited = value;
        }
    }
}