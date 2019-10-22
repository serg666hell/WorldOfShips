using System;
using System.Collections.Generic;

namespace SeaWar.Domain
{
    public sealed class Player
    {
        public enum AmountOfPossibleShips
        {
            OneDeck = 4,
            TwoDeck = 3,
            TreeDeck = 2,
            FourDeck = 1
        }

        public enum FireResult
        {
            hit,
            kill,
            miss
        }

        public Player(string name, GameBoard board)
        {
            Name = name;
            Board = board;
        }

        public Dictionary<Guid, Ship> PlayerShips { get; private set; }

        public string Name { get; }

        public GameBoard Board { get; }

        public List<Ship> Ships { get; private set; }

        //TODO: sorted List? how to simplify?
        public void putShipOnBoard(Ship ship, List<Cell> location)
        {
            var currentShip = PlayerShips[ship.Guid1];
            currentShip.changeShipLocation(location);
            currentShip.changeIsOnBoard(true);
        }

        public void removeShipFromBoard(Ship ship)
        {
            ship.changeShipLocation(null);
            ship.changeIsOnBoard(false);
        }

        // TODO: rename gameboard field. Implement getShipByCell
        public FireResult fire(Cell cell, Player enemy)
        {
            var enemyDesk = enemy.Board;
            var enemyShips = enemyDesk.Ships;
            var targetCell = enemyDesk.getCell(cell);
            if (targetCell.State == Cell.CellState.Occupied)
                foreach (var ship in enemyShips)
                foreach (var shipCell in ship.ShipLocation)
                    if (shipCell.Equals(cell))
                    {
                        shipCell.changeIsHited(true);
                        var shipState = checkShipState(ship);
                        if (shipState == Ship.ShipState.Died)
                            return FireResult.kill;
                        return FireResult.hit;
                    }

            return FireResult.miss;
        }

        private Ship.ShipState checkShipState(Ship ship)
        {
            ship.changeAmountOFHitedDecks(1);
            if (ship.AmountOfDecks < ship.AmountOfHittedDecks)
                return Ship.ShipState.Damaged;
            return Ship.ShipState.Died;
        }

        public void initShips()
        {
            PlayerShips = new Dictionary<Guid, Ship>();
            //create 4 one deck ships
            for (var i = 0; i < (int) AmountOfPossibleShips.OneDeck; i++)
            {
                var oneDeckShip = new Ship(Ship.ShipType.OneDeck);
                PlayerShips.Add(oneDeckShip.Guid1, oneDeckShip);
            }

            //create 3 two deck ships
            var twoDeckShips = new List<Ship>();
            for (var i = 0; i < (int) AmountOfPossibleShips.TwoDeck; i++)
            {
                var twoDeckShip = new Ship(Ship.ShipType.TwoDeck);
                PlayerShips.Add(twoDeckShip.Guid1, twoDeckShip);
            }

            //create 2 tree deck ships
            var treeDeckShips = new List<Ship>();
            for (var i = 0; i < (int) AmountOfPossibleShips.TreeDeck; i++)
            {
                var treeDeckShip = new Ship(Ship.ShipType.TreeDeck);
                PlayerShips.Add(treeDeckShip.Guid1, treeDeckShip);
            }

            //create 1 four deck ships
            var fourDeckShips = new List<Ship>();
            var fourDeckShip = new Ship(Ship.ShipType.FourDeck);
            PlayerShips.Add(fourDeckShip.Guid1, fourDeckShip);
        }
    }
}