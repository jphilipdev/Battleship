using Battleship.Models;
using System;
using System.Collections.Generic;

namespace Battleship.Exceptions
{
    public class CoordinatesNotStraightLineException : Exception
    {
        public CoordinatesNotStraightLineException(Guid playerId, IEnumerable<Coordinate> coordinates)
            : base($"Coordinates do not form straight line.  PlayerId='{playerId}', Coordinate='{string.Join("|", coordinates)}'")
        {

        }
    }
}
