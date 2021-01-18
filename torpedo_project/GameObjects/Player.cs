using System.Collections.Generic;

namespace torpedo_project.GameObjects
{
    public class Player : PlayerEntity
    {
        public string PlayerName { get; set; }
        public bool won { set; get; }
        public int RoundsNo { get; set; }
        public List<string> PlayerHits { get; }
        public List<string> EnemyHits { get; }
        public List<Ship> RemainingShips { get; }
        public List<Ship> DestroyedShips { get; }

        public Player()
        {
            PlayerName = "player";
            RemainingShips = new List<Ship>();
            DestroyedShips = new List<Ship>();
            EnemyHits = new List<string>();
            PlayerHits = new List<string>();
        }

        public Player(string playerName)
        {
            PlayerName = playerName;
            RemainingShips = new List<Ship>();
            DestroyedShips = new List<Ship>();
            EnemyHits = new List<string>();
            PlayerHits = new List<string>();
        }

        public void fillUpRemainingShips(Ship ship)
        {
            RemainingShips.Add(ship);
        }
        public void fillUpDestroyedShips(Ship ship)
        {
            DestroyedShips.Add(ship);
            RemainingShips.Remove(ship);
        }

        public void updatePlayerHits(string coord)
        {
            PlayerHits.Add(coord);
        }

        public void updateEnemyHits(string coord)
        {
            EnemyHits.Add(coord);
        }
    }
}
