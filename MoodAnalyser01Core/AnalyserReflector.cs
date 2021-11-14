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
    /// Mood analyser reflector class
    /// this conatains data about all the reflection methods,exceptions and other things that we are handling
    /// </summary>
    public class MoodAnalyserReflector
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
        ///following is for parameterised constrctor as per UC-5        
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
        public static object CreateMoodAnalyserParameterisedConstructor(string className, string constrcutorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if(type.Name.Equals(constrcutorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
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
        /// <summary>
        /// Invokes the analyse mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyser01_Core.CustomMoodAnException">method not found</exception>
        /// this is as per UC6
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyser);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodAnalyserObject = MoodAnalyserReflector.CreateMoodAnalyserParameterisedConstructor("MoodAnalyser01_Core.MoodAnalyser", "MoodAnalyser", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }

            catch (NullReferenceException)
            {
                throw new CustomMoodAnException(CustomMoodAnException.ExceptionType.NULL_VALUE, "method not found");
            }
        }
        /// <summary>
        /// Setfields the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyser01_Core.CustomMoodAnException">
        /// Message should not be null
        /// or
        /// Field not found
        /// </exception>
        /// This is UC 7 of Dynamically changing mood
        public static string Setfield(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyse = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomMoodAnException(CustomMoodAnException.ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                }
                field.SetValue(moodAnalyse, message);
                return moodAnalyse.message;
            }

            catch (NullReferenceException)
            {
                throw new CustomMoodAnException(CustomMoodAnException.ExceptionType.NO_SUCH_FIELD, "Field not found");
            }
        }
    }
}
