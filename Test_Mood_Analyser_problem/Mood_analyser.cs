using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestMoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        //instance variable
        public string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyzer"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        //creating constructor for mood analyzer
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        //This method analyzes mood
        public string AnalyseMood()
        {
            //if condition for to check happy word is present is or not
            if (message.ToLower().Contains("sad"))
            {
                return "SAD";
            }
            else
                return "HAPPY";
        }
    }
}
