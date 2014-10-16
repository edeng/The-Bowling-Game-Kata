using NUnit.Framework;

namespace TheBowlingGameKata.Tests
{
    [TestFixture]
    public class TheBowlingGameKataTest
    {
        private Game g;

        public TheBowlingGameKataTest()
        {
            g = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }

        [Test]
        public void TestGutterGame()
        {
            // Arrange
            RollMany(20, 0); 

            // Act
            bool result = g.Score().Equals(0); 

            // Assert
            Assert.True(result);
        }

        [Test]
        public void TestAllOnes()
        {
            // Arrange
            RollMany(20, 1);

            // Act
            bool result = g.Score().Equals(20); 

            // Assert
            Assert.True(result);
        }

        [Test]
        public void TestOneSpare()
        {
            // Arrange
            RollSpare(); 
            g.Roll(3);
            RollMany(17, 0);
 
            // Act 
            bool result = g.Score().Equals(16); 

            // Assert
            Assert.True(result); 

        }
        
        [Test]
        public void TestOneStrike()
        {
            // Arrange
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);

            // Act
            bool result = g.Score().Equals(24); 

            // Assert
            Assert.True(result);

        }

        [Test]
        public void TestPerfectTest()
        {
            // Arrange
            RollMany(12, 10);

            // Act
            bool result = g.Score().Equals(300); 

            // Assert
            Assert.True(result);

        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
