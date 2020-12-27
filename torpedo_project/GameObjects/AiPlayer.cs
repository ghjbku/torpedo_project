using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torpedo_project.GameObjects
{
    class AiPlayer : PlayerEntity
    {
        public string PlayerName { get; set; }
        public int RoundsNo { get; set; }
        public char[,] PlayerHits { get; set; }
        public char[,] EnemyHits { get; set; }
        public List<Ship> RemainingShips { get; set; }
        public List<Ship> DestroyedShips { get; set; }


        public AiPlayer()
        {
            PlayerName = "Ai";
            RemainingShips = new List<Ship>();
            DestroyedShips = new List<Ship>();
            EnemyHits = new char[,] { };
            PlayerHits = new char[,] { };
        }

        public void fillUpRemainingShips(Ship ship)
        {
            RemainingShips.Add(ship);
        }
    }
    
    
}
