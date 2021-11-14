using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser01_Core
{
   public class MoodAnalyser
    {
        private string message;        //the private message field of the mood analyser class
        
        public MoodAnalyser(string message)        //initialising the parameterised constructor
        {
            this.message = message;
        }

        public MoodAnalyser()                //initialising the default constructor
        {
            this.message = null;
        }

        public string AnalyseMood()                  //declaring the analyse mood method
        {
            try                                      //the try and catch block is for exception handling
            {
                //this is the custom exception that we declared for checking empty messages. exception type is an enum followed by the message.
                if (this.message.Equals(string.Empty))
                {
                    throw new CustomMoodAnException(CustomMoodAnException.ExceptionType.EMPTY_MESSAGE, "Mood should not be Empty"); 
                }

                if (this.message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }

            catch (NullReferenceException)                  //this shows that it should not be null. NullREferenceException is a predefined exception class
            {
                throw new CustomMoodAnException(CustomMoodAnException.ExceptionType.NULL_VALUE, "Mood can not be null");
            }
        }
    }
}
