using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyser01_Core
{
    /// <summary>
    /// Mood analysis class for handling exceptions
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CustomMoodAnException: Exception
    {
        /// <summary>
        /// enum for exception type
        /// enums are like constant values which are numeric integer numbers which either the user assigns or default starting fro  0,1,2...
        /// </summary>

        public ExceptionType type;
        public enum ExceptionType
        {
            NULL_VALUE, EMPTY_MESSAGE, NO_SUCH_FIELD, NO_SUCH_METHOD,
            NO_SUCH_CLASS, OBJECT_CREATION_ISSUE

        }

        public CustomMoodAnException(ExceptionType type, string message): base(message)
        {
            this.type = type;
        }

    }
}
