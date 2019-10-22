using System;
using System.Collections.Generic;

namespace SeaWar.Domain
{
    public sealed class Ship
    {
        public enum AmountOfPossibleShips
        {
            OneDeck = 4,
            TwoDeck = 3,
            TreeDeck = 2,
            FourDeck = 1
        }

        public enum ShipState
        {
            Healthy,
            Damaged,
            Died
        }

        public enum ShipType
        {
            OneDeck = 1,
            TwoDeck = 2,
            TreeDeck = 3,
            FourDeck = 4
        }

        //private List<Deck> decks;

        public Ship(ShipType type)
        {
            IsOnBoard = false;
            ShipLocation = new List<Cell>();
            Guid1 = Guid.NewGuid();
            var AmountOfDecks = (int) type;
            Type = type;
            ShipState1 = ShipState.Healthy;
            this.AmountOfDecks = AmountOfDecks;
        }

        public List<Cell> ShipLocation { get; private set; }

        public bool IsOnBoard { get; private set; }

        public Guid Guid1 { get; private set; }

        public int AmountOfDecks { get; private set; }

        public ShipState ShipState1 { get; private set; }

        public int AmountOfHittedDecks { get; private set; }

        public ShipType Type { get; }

        public override string ToString()
        {
            return Guid1 + " " + Type;
        }

        public void changeAmountOFHitedDecks(int value)
        {
            AmountOfHittedDecks += value;
        }

        public void changeShipLocation(List<Cell> value)
        {
            ShipLocation = value;
        }

        public void changeIsOnBoard(bool value)
        {
            IsOnBoard = value;
        }
    }
}