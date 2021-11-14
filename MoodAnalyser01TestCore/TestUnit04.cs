using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser01_Core;

namespace MoodAnalyser01Test_Core
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Givens the sadshouldreturn sad and happysouldreturnhappy method.
        /// TC 1.1 Given?I am in sad mood should return SAD.
        /// </summary>
        [TestMethod]
        public void GivenSadshouldreturnSad()
        {
            //Arrange
            string expected = "SAD";
            string message = "I am in sad mood";
            MoodAnalyser moodAnalysis = new MoodAnalyser(message);

            //Act
            string mood = moodAnalysis.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }

        [TestMethod]

        //TC 1.2 Given? I am in happy mood should return HAPPY.
        public void GivenHappyshouldreturnHappy()
        {
            //Arrange
            string expected = "HAPPY";
            string message = "I am in happy mood";
            MoodAnalyser moodAnalysis = new MoodAnalyser(message);

            //Act
            string mood = moodAnalysis.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }

        //[TestMethod]

        //TC 2.1 Given? NULL should return HAPPY.
        //this is the test case of UC2
        //the data roew command takes the input one after the other
        //[DataRow(null)]
        //public void GivenNullshouldreturnHappy(string message)
        //{
        //    //Arrange
        //    string expected = "HAPPY";
        //    MoodAnalyser moodAnalysis = new MoodAnalyser(message);

        //    //Act
        //    string mood = moodAnalysis.AnalyseMood();

        //    //Assert
        //    Assert.AreEqual(expected, mood);
        //}
        //THE ABOVE UC CANT PASS AS WE HAVE FURTHER DECLARED THAT NULL MODD SHOULD THROW EXCEPTION AND NOT RETURN HAPPY

        [TestMethod]
        //the following is the TC 3.1. Given? null mood, should throw custom exception
        public void Given_Null_Should_Throw_CustomException_Indicating_NullMood()
        {
            try                                                //try catch block is reqd in testign also if its present in main prog to catch multiple expetions
            {
                string message = null;
                MoodAnalyser moodAnalysis = new MoodAnalyser(message);
                string mood = moodAnalysis.AnalyseMood();
            }
            catch (CustomMoodAnException e)
            {
                Assert.AreEqual("Mood can not be null", e.Message);
            }

        }
        [TestMethod]

        //the following is the TC 3.2. Given? Empty mood, should throw custom exception showing empty.
        public void Given_Empty_Should_Throw_CustomException_Indicating_EmptyMood()
        {
            try                                                //try catch block is reqd in testign also if its present in main prog to catch multiple expetions
            {
                string message = "";
                MoodAnalyser moodAnalysis = new MoodAnalyser(message);
                string mood = moodAnalysis.AnalyseMood();
            }
            catch (CustomMoodAnException e)
            {
                Assert.AreEqual("Mood should not be Empty", e.Message);
            }
        }

        [TestMethod]
        //Test Case 4.1 given mood Analyse class name should return mood analyser object.

        public void GivenMoodAnalyseClassName_Should_return_MoodAnalyseObject()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser01_Core.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        [TestMethod]
        //Test Case 4.2 Given mood Analyse wrong class name should return exception stating no such class name exist 

        public void GivenMoodAnalyseWrongClassName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyser(message);
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser01_Core.MoodAnalyserWrong", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomMoodAnException e)
            {
                Assert.AreEqual("Class not found", e.Message);
            }
        }

        [TestMethod]
        //Test Case 4.3 Given wrong constructor name should return simproper message in exception  

        public void GivenMoodAnalyseWrongConstructor_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyser(message);
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser01_Core.MoodAnalyser", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch(CustomMoodAnException e)
            {
                Assert.AreEqual("Constructor not found", e.Message);
            }
        }

    }
}
