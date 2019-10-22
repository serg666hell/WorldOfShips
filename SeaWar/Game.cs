using System.Collections.Generic;

namespace SeaWar.Domain
{
    public sealed class Game
    {
        private List<Player> players;

        //public List<Player> Players { get => players; private set => players = value; }
        public Player Player { get; private set; }


        /*public void initShips()
        {
            Dictionary<Guid, Ship> playerShips = playerOne.PlayerShips;
            playerOne.initShips();
            playerTwo.initShips();
        }*/

        public void initPlayers()
        {
            Player = new Player("Player1", new GameBoard());
            //var playerTwo = new Player("Player2", new GameBoard());
            //Players.Add(playerOne);
            //Players.Add(playerTwo);
        }
    }
}