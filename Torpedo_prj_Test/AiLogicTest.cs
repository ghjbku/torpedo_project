using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Torpedo_prj_Test
{
    [TestClass]
    public class AiLogicTest
    {
        [TestMethod]
        public void AiHitsCloseAfterAShipPartIsHitRotationFalse()
        {
            // Arrange
            torpedo_project.GameObjects.Ship testShip = new torpedo_project.GameObjects.Ship("A", 1, "B", 1, "PatrolBoat");
            string LastCoordTheAiHit = "A1";
            string expected = "A";
            testShip.rotated = false;
            //Act
            string got = torpedo_project.GameObjects.Functions.AiRandomCoord(LastCoordTheAiHit, testShip);
            /*
             *  if (LastCoordThatHit == null){}
              else {
                TestingLabelOutput("hit: " + LastCoordThatHit);
                rnd = new Random();
                if (lastShipHitAi.rotated == true)
                {
                    range = "ABCDEFGHIJ";
                    string[] _rangeNumber = System.Text.RegularExpressions.Regex.Split(LastCoordThatHit, @"\D+");
                    dice = int.Parse(_rangeNumber[1]);
                    Coord1 = new string(Enumerable.Range(1, 1).Select(x => range[rnd.Next(0, range.Length)]).ToArray());
                }
                else {
                    string[] _rangeAlphabet = System.Text.RegularExpressions.Regex.Split(LastCoordThatHit, @"\d+");
                    range = _rangeAlphabet[0];
                    dice = rnd.Next(1, 11);
                    Coord1 = range;
                }
            }
             
             */
            string[] _actual = System.Text.RegularExpressions.Regex.Split(got, @"\d+");
            string actual = _actual[0];
            // Assert
            System.Console.WriteLine(got);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AiHitsCloseAfterAShipPartIsHitRotationTrue()
        {
            // Arrange
            torpedo_project.GameObjects.Ship testShip = new torpedo_project.GameObjects.Ship("A", 1, "B", 1, "PatrolBoat");
            string LastCoordTheAiHit = "A1";
            string expected = "1";
            testShip.rotated = true;
            //Act
            string got = torpedo_project.GameObjects.Functions.AiRandomCoord(LastCoordTheAiHit, testShip);
            /*
             *  if (LastCoordThatHit == null){}
              else {
                TestingLabelOutput("hit: " + LastCoordThatHit);
                rnd = new Random();
                if (lastShipHitAi.rotated == true)
                {
                    range = "ABCDEFGHIJ";
                    string[] _rangeNumber = System.Text.RegularExpressions.Regex.Split(LastCoordThatHit, @"\D+");
                    dice = int.Parse(_rangeNumber[1]);
                    Coord1 = new string(Enumerable.Range(1, 1).Select(x => range[rnd.Next(0, range.Length)]).ToArray());
                }
                else {
                    string[] _rangeAlphabet = System.Text.RegularExpressions.Regex.Split(LastCoordThatHit, @"\d+");
                    range = _rangeAlphabet[0];
                    dice = rnd.Next(1, 11);
                    Coord1 = range;
                }
            }
             
             */
            string[] _actual = System.Text.RegularExpressions.Regex.Split(got, @"\D+");
            string actual = _actual[1];
            // Assert
            System.Console.WriteLine(got);
            Assert.AreEqual(expected, actual);
        }
    }
}
