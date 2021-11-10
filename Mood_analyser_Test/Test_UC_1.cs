using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestMoodAnalyzerProblem;

namespace MoodAnalyserTest
{
    [TestClass]
    public class TestClass
    {
        //Test case 1.1 : Sad message should return SAD 
        [TestMethod]
        public void GivenSadMsgReturnSadMood()
        {
            //AAA method
            //Arrange
            string message = "I am in sad mood";
            string expected = "SAD";
            //creating object of moodanalyzer class and passing message
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);
            
            //Act
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            //comparing actual and expected value
            Assert.AreEqual(expected, actual);         
        }
        //Test case 1.2 : Any message should return HAPPY and sad message should return sad 
        [TestMethod]
        public void GivenAnyMsgReturnHaapyMood()
        {
            //AAA method
            //Arrange
            string message = "I am in Any mood";
            string expected = "HAPPY";
            //creating object of moodanalyzer class and passing message
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(message);

            //Act
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            //comparing actual and expected value
            Assert.AreEqual(expected, actual);
        }
    }

}
