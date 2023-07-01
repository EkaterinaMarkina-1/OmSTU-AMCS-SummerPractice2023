using Xunit;

namespace TestxUnit
{
    public class SpaceShipTests
    {
        [Fact]
        public void SpaceShipMovesInStraightLine()
        {
            // Arrange
            var spaceShip = new SpaceShip();
            spaceShip.SetPosition(12, 5);
            spaceShip.SetVelocity(-5, 3);
            // Act
            spaceShip.Move();
            // Assert
            Assert.Equal(7, spaceShip.GetPosX());
            Assert.Equal(8, spaceShip.GetPosY());
        }

        [Fact]
        public void CannotMoveIfPositionNotDefined()
        {
            // Arrange
            var spaceShip = new SpaceShip();
            spaceShip.SetVelocity(-5, 3);

            // Act & Assert
            Assert.Throws<System.Exception>(() => spaceShip.Move());
        }

        [Fact]
        public void CannotMoveIfVelocityNotDefined()
        {
            // Arrange
            var spaceShip = new SpaceShip();
            spaceShip.SetPosition(12, 5);

            // Act & Assert
            Assert.Throws<System.Exception>(() => spaceShip.Move());
        }

        [Fact]
        public void CannotMoveIfPositionCannotBeChanged()
        {
            // Arrange
            var spaceShip = new SpaceShip();
            spaceShip.SetPosition(12, 5);
            spaceShip.SetVelocity(-5, 3);
            // Assuming there is some logic in SpaceShip class to make position unchangeable
            spaceShip.SetPositionUnchangeable(true);

            // Act & Assert
            Assert.Throws<System.Exception>(() => spaceShip.Move());
        }
    }
}

