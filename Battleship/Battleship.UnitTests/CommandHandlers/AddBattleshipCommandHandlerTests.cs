using Battleship.CommandHandlers;
using Battleship.Exceptions;
using Battleship.Models;
using Battleship.Store;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.UnitTests.CommandHandlers
{
    [TestFixture]
    public class AddBattleshipCommandHandlerTests
    {
        private AddBattleshipCommandHandler _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new AddBattleshipCommandHandler();
        }

        [Test]
        public void WhenBattleshipAdded_ThenBattleshipIsAddedToStore()
        {
            var playerId = Guid.NewGuid();
            var coordinate = new Coordinate(1, 1);
            var store = new Mock<IGameStore>();

            new AddBattleshipCommandHandler().Execute(store.Object, playerId, new List<Coordinate>() { coordinate });

            store.Verify(p => p.AddBattleship(It.Is<Models.Battleship>(p2 => p2.PlayerId == playerId && p2.Coordinates.Single().Coordinate == coordinate)));
        }

        [Test]
        public void WhenBattleshipAdded_AndNullCoordinatesProvided_ThenCoordinatesNotProvidedExceptionThrown()
        {
            Action exceptionAction = () => _subject.Execute(null, Guid.Empty, null);

            exceptionAction.Should().Throw<CoordinatesNotProvidedException>();
        }

        [Test]
        public void WhenBattleshipAdded_AndEmptyCoordinatesProvided_ThenCoordinatesNotProvidedExceptionThrown()
        {
            Action exceptionAction = () => _subject.Execute(null, Guid.Empty, new List<Coordinate>());

            exceptionAction.Should().Throw<CoordinatesNotProvidedException>();
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 11)]
        [TestCase(11, 1)]
        public void WhenBattleshipAdded_AndProvidedCoordinatesAreOutOfBounds_ThenCoordinatesOutOfBoundsExceptionThrown(int x, int y)
        {
            var coordinates = new List<Coordinate>() { new Coordinate(x, y) };

            Action exceptionAction = () => _subject.Execute(null, Guid.Empty, coordinates);

            exceptionAction.Should().Throw<CoordinatesOutOfBoundsException>();
        }

        [Test]
        public void WhenBattleshipAdded_AndProvidedCoordinatesAreNotInStraightLine_ThenCoordinatesNotStraightLineExceptionThrown()
        {
            var coordinates = new List<Coordinate>()
            {
                new Coordinate(1, 1),
                new Coordinate(1, 2),
                new Coordinate(2, 1),
            };

            Action exceptionAction = () => _subject.Execute(null, Guid.Empty, coordinates);

            exceptionAction.Should().Throw<CoordinatesNotStraightLineException>();
        }
    }
}
