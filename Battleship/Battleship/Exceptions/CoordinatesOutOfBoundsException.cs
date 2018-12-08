using Battleship.Models;
using System;
using System.Collections.Generic;

namespace Battleship.Exceptions
{
    public class CoordinatesOutOfBoundsException : Exception
    {
        public CoordinatesOutOfBoundsException(Guid playerId, IEnumerable<Coordinate> coordinates)
            : base($"Coordinates are outside of bame bounds.  PlayerId='{playerId}', Coordinates='{string.Join("|", coordinates)}'")
        {

        }
    }
}
