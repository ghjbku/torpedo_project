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
        public int[][] PlayerHits { get; set; }
        public int[][] EnemyHits { get; set; }
        public int[][] RemainingShips { get; set; }
        public int[][] DestroyedShips { get; set; }

        public Player(string playerName) {
            PlayerName = playerName;
        }
    }
}
