using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyser01_Core
{
    /// <summary>
    /// Mood analyser factory class
    /// this conatains data about all the reflection methods,exceptions and other things that we are handling
    /// </summary>
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// Creates the mood analyse.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyser01_Core.CustomMoodAnException">
        /// Class not found
        /// or
        /// Constructor not found
        /// </exception>
        /// 
        //following is for default constructor
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = "." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);

                }

                catch (Exception e)
                {
                    throw new CustomMoodAnException(CustomMoodAnException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }

            }
            else
            {
                throw new CustomMoodAnException(CustomMoodAnException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }
        ///following is for parameterised constrctor as per uc-5        
        /// <summary>
        /// Creates the mood analyser parameterised constructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constrcutorName">Name of the constrcutor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyser01_Core.CustomMoodAnException">
        /// Constructor not found
        /// or
        /// Class not found
        /// </exception>
        public static object CreateMoodAnalyserParameterisedConstructor(string className, string constrcutorName)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if(type.Name.Equals(constrcutorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { "HAPPY" });
                    return instance;
                }
                else
                {
                    throw new CustomMoodAnException(CustomMoodAnException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                }
            }

            else
            {
                throw new CustomMoodAnException(CustomMoodAnException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
    }
}
