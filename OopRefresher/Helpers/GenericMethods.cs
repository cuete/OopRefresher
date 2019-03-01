using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OopRefresher
{
    class GenericMethods
    {
        /// <summary>
        /// Writes text to a file using streamwriter
        /// </summary>
        /// <param name="text"></param>
        /// <param name="filename"></param>
        public static void UpdateFile(string text, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.Write(text);
            }
        }

        /// <summary>
        /// Reads text file into string using streamreader
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ReadFile(string filename)
        {
            string text;
            using (StreamReader r = new StreamReader(filename))
            {
                text = r.ReadToEnd();
            }
            return text;
        }

        /// <summary>
        /// Generic method, passing a generic T type parameter
        /// Serialize an object collection to a JSON string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="myobject"></param>
        /// <returns></returns>
        public static string SerializeToJson<T>(List<T> myobject)
        {
            return JsonConvert.SerializeObject(myobject);
        }

        /// <summary>
        /// Generic method, using generic T type parameters
        /// JSON deserialization into an object collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> DeserializeToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
