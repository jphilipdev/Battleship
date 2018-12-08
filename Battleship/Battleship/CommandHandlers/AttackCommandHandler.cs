using Battleship.Exceptions;
using Battleship.Models;
using Battleship.Store;
using System;
using System.Linq;

namespace Battleship.CommandHandlers
{
    public interface IAttackCommandHandler
    {
        bool Execute(IGameStore store, Guid playerId, Coordinate coordinate);
    }

    public class AttackCommandHandler : IAttackCommandHandler
    {
        public bool Execute(IGameStore store, Guid playerId, Coordinate coordinate)
        {
            var battleship = store.GetBattleship(coordinate);

            if (battleship == null)
            {
                return false;
            }

            ValidateAttack(store, playerId, battleship);

            SaveAttackResult(coordinate, battleship);

            return true;
        }       

        private void ValidateAttack(IGameStore store, Guid playerId, Models.Battleship battleship)
        {
            if (battleship.PlayerId == playerId)
            {
                throw new OwnBattleshipAttackedException(playerId, battleship.Id);
            }
        }

        private void SaveAttackResult(Coordinate coordinate, Models.Battleship battleship)
        {
            var hitCoordinate = battleship.Coordinates.Single(p => p.Coordinate == coordinate);
            hitCoordinate.Hit = true;
        }
    }
}
