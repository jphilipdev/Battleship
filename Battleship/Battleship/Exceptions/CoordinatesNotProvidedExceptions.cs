using System;

namespace Battleship.Exceptions
{
    public class CoordinatesNotProvidedException : Exception
    {
        public CoordinatesNotProvidedException(Guid playerId)
            : base($"No coordinates provided for battleship.  PlayerId='{playerId}'")
        {

        }
    }
}
