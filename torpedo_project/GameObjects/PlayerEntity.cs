using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torpedo_project
{
    interface PlayerEntity
    {
        string PlayerName { set; get; }
        int RoundsNo { set; get; }
        char[,] PlayerHits { set; get; }
        char[,] EnemyHits { set; get; }
        List<GameObjects.Ship> RemainingShips { set; get; }
        List<GameObjects.Ship> DestroyedShips { set; get; }

        void fillUpRemainingShips(GameObjects.Ship ship);
    }
}
