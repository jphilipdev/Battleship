using Battleship.Exceptions;
using Battleship.Models;
using Battleship.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.CommandHandlers
{
    public interface IAddBattleshipCommandHandler
    {
        Guid Execute(IGameStore store, Guid playerId, IReadOnlyList<Coordinate> coordinates);
    }

    public class AddBattleshipCommandHandler : IAddBattleshipCommandHandler
    {
        public Guid Execute(IGameStore store, Guid playerId, IReadOnlyList<Coordinate> coordinates)
        {
            var battleshipId = Guid.NewGuid();

            ValidateCoordinates(playerId, coordinates);

            AddBattleship(store, playerId, coordinates, battleshipId);

            return battleshipId;
        }

        private void ValidateCoordinates(Guid playerId, IReadOnlyList<Coordinate> coordinates)
        {
            ValidateCoordinatesProvided(playerId, coordinates);
            ValidateCoordinatesWithinBounds(playerId, coordinates);
            ValidateCoordinatesInStraightLine(playerId, coordinates);
        }

        private void ValidateCoordinatesProvided(Guid playerId, IReadOnlyList<Coordinate> coordinates)
        {
            if (coordinates == null || !coordinates.Any())
            {
                throw new CoordinatesNotProvidedException(playerId);
            }
        }

        private void ValidateCoordinatesWithinBounds(Guid playerId, IReadOnlyList<Coordinate> coordinates)
        {
            if (coordinates.Any(p => p.X < 1) || coordinates.Any(p => p.Y < 1) || coordinates.Any(p => p.X > 10) || coordinates.Any(p => p.Y > 10))
            {
                throw new CoordinatesOutOfBoundsException(playerId, coordinates);
            }
        }

        private void ValidateCoordinatesInStraightLine(Guid playerId, IReadOnlyList<Coordinate> coordinates)
        {
            if (new HashSet<int>(coordinates.Select(p => p.X)).Count > 1 && new HashSet<int>(coordinates.Select(p => p.Y)).Count > 1)
            {
                throw new CoordinatesNotStraightLineException(playerId, coordinates);
            }
        }

        private void AddBattleship(IGameStore store, Guid playerId, IReadOnlyList<Coordinate> coordinates, Guid battleshipId)
        {
            var battleship = new Models.Battleship(battleshipId, playerId, coordinates.Select(p => new BattleshipCoordinate(p)).ToList());
            store.AddBattleship(battleship);
        }
    }
}