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
            object obj = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser01_Core.MoodAnalyser", "MoodAnalyser");
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
                object obj = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser01_Core.MoodAnalyserWrong", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch (CustomMoodAnException e)
            {
                Assert.AreEqual("Class not found", e.Message);
            }
        }

        [TestMethod]
        //Test Case 4.3 Given wrong constructor name should return improper message in exception  

        public void GivenMoodAnalyseWrongConstructor_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyser(message);
                object obj = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser01_Core.MoodAnalyser", "MoodAnalyserWrong");
                expected.Equals(obj);
            }

            catch(CustomMoodAnException e)
            {
                Assert.AreEqual("Constructor not found", e.Message);
            }
        }


        [TestMethod]
        //Test Case 5.1 given mood Analyse class name should return mood analyser object with parameterised constructor

        public void Given_ParameterisedConstructor_MoodAnalyseClassName_Should_return_MoodAnalyseObject()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserReflector.CreateMoodAnalyserParameterisedConstructor("MoodAnalyser01_Core.MoodAnalyser", "MoodAnalyser", "Happy");
            expected.Equals(obj);
        }


        [TestMethod]
        //Test Case 5.2 Given mood Analyse wrong class name should return exception stating no such class name exist 

        public void Given_ParameterisedConstructor_WrongClassName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                object expected = new MoodAnalyser("HAPPY");
                object obj = MoodAnalyserReflector.CreateMoodAnalyserParameterisedConstructor("MoodAnalyser01_Core.MoodAnalyserWrong", "MoodAnalyser", "Happy");
                expected.Equals(obj);
            }

            catch (CustomMoodAnException e)
            {
                Assert.AreEqual("Class not found", e.Message);
            }
        }


        //Test Case 5.3 Given mood Analyse wrong constructor name should return exception stating no such consrtructor exist 
        [TestMethod]
        public void Given_ParameterisedConstructor_WrongConstrcutorName_Should_return_MoodAnalyseObjectException_Message()
        {
            try
            {
                object expected = new MoodAnalyser("HAPPY");
                object obj = MoodAnalyserReflector.CreateMoodAnalyserParameterisedConstructor("MoodAnalyser01_Core.MoodAnalyser", "MoodAnalyserWrong", "Happy");
                expected.Equals(obj);
            }

            catch (CustomMoodAnException e)
            {
                Assert.AreEqual("Constructor not found", e.Message);
            }
        }

        [TestMethod]
        //below is the test case of UC 6
        //test Case 6.1
        //in this test case we are passing the happy message and the method name- Analyse mood in the reflector class method = Invoke Analyse mood
        //this in turn invokes the custom parameterised constructor method from the reflector class.
        public void GivenHappy_ShouldReturn_Happy_ReflectorInvoke_method()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyserReflector.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }

        [TestMethod]
        //below is the test case of UC 6
        //test Case 6.2
        //passing the wrong method name should return the message that method does not exist. 
        //exceptoon should be triggered
        public void GivenHappy_ShouldReturnException_WithWrongMethodName()
        {
            try
            {
                string expected = "method not found";
                string mood = MoodAnalyserReflector.InvokeAnalyseMood("Happy", "AnalyseMoodWrong");
                Assert.AreEqual(expected, mood);
            }

            catch (CustomMoodAnException e)
            {
                Assert.AreEqual("method not found", e.Message);
            }
        }

        [TestMethod]
        ///Following is the test case 7.1
        ///in this scenario of testing we check that the field returns the message that we enter or specify during runtime - dynamically
 
        public void GivenHappy_ShouldReturnHappy_WithReflectorDynamically()
        {
            string result = MoodAnalyserReflector.Setfield("Happy", "message");
            Assert.AreEqual("Happy", result);
        }

        [TestMethod]
        //Following is for TC 7.2
        //for this test case we provide wrong field name to get an exception
        public void GivenWrongField_ShouldReturn_Exception()
        {
            try
            {
                string result = MoodAnalyserReflector.Setfield("Happy", "messageWrong");
                Assert.AreEqual("Happy", result);
            }
            catch (CustomMoodAnException e)
            {
                Assert.AreEqual("Field not found", e.Message);
            }
        }
        [TestMethod]
        //Following is for TC 7.3
        //here to pass this test case we pass empty message in the reflector and see what exception it throws
        public void GivenEmptyMessage_ShouldReturn_Exception()
        {
            try
            {
                string result = MoodAnalyserReflector.Setfield(null, "messageWrong");
                Assert.AreEqual("Happy", result);
            }
            catch (CustomMoodAnException e)
            {
                Assert.AreEqual("Message should not be null", e.Message);
            }
        }



    }
}
