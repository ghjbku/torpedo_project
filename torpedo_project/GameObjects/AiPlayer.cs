using System.Collections.Generic;

namespace torpedo_project.GameObjects
{
   public class AiPlayer : PlayerEntity
    {
        public string PlayerName { get; set; }
        public int RoundsNo { get; set; }
        public bool won { set; get; }
        public List<string> PlayerHits { get; set; }
        public List<string> EnemyHits { get; set; }
        public List<Ship> RemainingShips { get; set; }
        public List<Ship> DestroyedShips { get; set; }


        public AiPlayer()
        {
            PlayerName = "Ai";
            RemainingShips = new List<Ship>();
            DestroyedShips = new List<Ship>();
            EnemyHits = new List<string> ();
            PlayerHits = new List<string> ();
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
