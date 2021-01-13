using System.Collections.Generic;

namespace torpedo_project
{
    public interface PlayerEntity
    {
        string PlayerName { set; get; }
        int RoundsNo { set; get; }
        List<string> PlayerHits { set; get; }
        List<string> EnemyHits { set; get; }
        List<GameObjects.Ship> RemainingShips { set; get; }
        List<GameObjects.Ship> DestroyedShips { set; get; }

        void fillUpRemainingShips(GameObjects.Ship ship);
        void fillUpDestroyedShips(GameObjects.Ship ship);
        void updatePlayerHits(string coord);
        void updateEnemyHits(string coord);
    }
}
