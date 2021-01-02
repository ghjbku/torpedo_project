using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torpedo_project.GameObjects
{
    class Player : PlayerEntity
    {
        public string PlayerName { get; set; }
        public int RoundsNo { get; set; }
        public List<string> PlayerHits { get; set; }
        public List<string> EnemyHits { get; set; }
        public List<Ship> RemainingShips { set; get; }
        public List<Ship> DestroyedShips { set; get; }

        public Player(string playerName) {
            PlayerName = playerName;
            RemainingShips = new List<Ship>();
            DestroyedShips = new List<Ship>();
            EnemyHits = new List<string> ();
            PlayerHits = new List<string> ();
        }

        public void fillUpRemainingShips(Ship ship) {
            RemainingShips.Add(ship);
        }
        public void fillUpDestroyedShips(Ship ship)
        {
            DestroyedShips.Add(ship);
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
