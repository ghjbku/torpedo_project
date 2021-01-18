using System.Collections.Generic;

namespace torpedo_project
{
    public interface PlayerEntity
    {
        string PlayerName { set; get; }
        int RoundsNo { set; get; }
        bool won { set; get; }
        List<string> PlayerHits { get; }
        List<string> EnemyHits { get; }
        List<GameObjects.Ship> RemainingShips { get; }
        List<GameObjects.Ship> DestroyedShips { get; }

        void fillUpRemainingShips(GameObjects.Ship ship);
        void fillUpDestroyedShips(GameObjects.Ship ship);
        void updatePlayerHits(string coord);
        void updateEnemyHits(string coord);
    }
}
