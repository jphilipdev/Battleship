using System;
using System.Collections.Generic;

namespace Battleship.Models
{
    public class Battleship
    {
        public Battleship(Guid id, Guid playerId, IReadOnlyList<BattleshipCoordinate> coordinates)
        {
            Id = Id;
            PlayerId = playerId;
            Coordinates = coordinates;
        }

        public Guid Id { get; }

        public Guid PlayerId { get; }

        public IReadOnlyList<BattleshipCoordinate> Coordinates { get; }
    }
}
