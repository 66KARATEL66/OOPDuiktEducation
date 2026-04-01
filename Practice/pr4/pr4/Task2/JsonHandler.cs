using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4.Task2
{
    public class JsonHandler
    {
        private static string path = "..\\..\\..\\Task2\\Resources\\saveFile.json";

        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public static void SerializeJson(List<StudentItem> StudentItems)
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Create))
                {
                    JsonSerializer.Serialize(fs, StudentItems, options);
                }  
        }

        public static List<StudentItem> DeserializeJson()
        {
            if(File.Exists(Path.GetFullPath(path)))
            {
                using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Open))
                {
                    return JsonSerializer.Deserialize<List<StudentItem>>(fs, options);
                }
            }
            else
            {
                return new List<StudentItem>();
            }
        }
    }
}
