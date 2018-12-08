using Battleship.CommandHandlers;
using Battleship.Models;
using Battleship.Store;
using System;
using System.Collections.Generic;

namespace Battleship
{
    public class BattleshipService
    {
        private readonly IGameStore _store = new GameStore();
        private readonly IAddBattleshipCommandHandler _addBattleshipCommandHandler;
        private readonly IAttackCommandHandler _attackCommandHandler;

        public BattleshipService(IAddBattleshipCommandHandler addBattleshipCommandHandler, IAttackCommandHandler attackCommandHandler)
        {
            _addBattleshipCommandHandler = addBattleshipCommandHandler;
            _attackCommandHandler = attackCommandHandler;
        }

        public void AddBattleship(Guid playerId, IReadOnlyList<Coordinate> coordinates)
        {
            _addBattleshipCommandHandler.Execute(_store, playerId, coordinates);
        }

        public void Attack(Guid playerId, Coordinate coordinate)
        {
            _attackCommandHandler.Execute(_store, playerId, coordinate);
        }

        public bool IsGameLost(Guid playerId)
        {
            return _store.HasPlayerLost(playerId);
        }
    }
}