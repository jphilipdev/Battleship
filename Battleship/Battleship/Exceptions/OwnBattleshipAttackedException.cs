using System;

namespace Battleship.Exceptions
{
    public class OwnBattleshipAttackedException : Exception
    {
        public OwnBattleshipAttackedException(Guid playerId, Guid battleshipId)
            : base($"Cannot attack own battleship.  PlayerId='{playerId}', BattleshipId='{battleshipId}'")
        {

        }
    }
}
