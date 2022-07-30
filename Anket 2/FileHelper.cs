using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anket_2
{
    public  class FileHelper
    {
        public static void WriteToFile(List <User>  user,string filename1)
        {
            var serializer = new JsonSerializer();
            string filename =filename1 + ".json";
            using (var sw = new StreamWriter(filename))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, user);
                }
            }
        }

        public static List<User> ReadFromJson(string filename)
        {
            List<User> resultDatabase = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader($"{filename}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    resultDatabase = serializer.Deserialize<List<User>>(jr);
                }
            }
            return resultDatabase;
        }
    }
}
