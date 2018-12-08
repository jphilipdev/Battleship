using Battleship.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Store
{
    public interface IGameStore
    {
        void AddBattleship(Models.Battleship battleship);

        Models.Battleship GetBattleship(Coordinate coordinate);

        bool HasPlayerLost(Guid playerId);
    }

    public class GameStore : IGameStore
    {
        private readonly List<Models.Battleship> _battleships = new List<Models.Battleship>();


        public void AddBattleship(Models.Battleship battleship)
        {
            _battleships.Add(battleship);
        }

        public Models.Battleship GetBattleship(Coordinate coordinate)
        {
            return _battleships.SingleOrDefault(b => b.Coordinates.Any(c => c.Coordinate == coordinate));
        }

        public bool HasPlayerLost(Guid playerId)
        {
            return _battleships.Any(b => b.PlayerId == playerId && b.Coordinates.Any(c => !c.Hit));
        }
    }
}
