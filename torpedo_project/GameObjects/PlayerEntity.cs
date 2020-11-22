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
        int[][] PlayerHits { set; get; }
        int[][] EnemyHits { set; get; }
        int[][] RemainingShips { set; get; }
        int[][] DestroyedShips { set; get; }

    }
}
