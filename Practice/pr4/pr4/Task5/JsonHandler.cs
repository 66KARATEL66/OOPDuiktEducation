using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4.Task5
{
    public class JsonHandler
    {
        private static string path = "..\\..\\..\\Task5\\Resources\\saveFile.json";

        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        public static void SerializeJson(List<Animal> animals)
        {
            /*options.Converters.Add(new JsonStringEnumConverter());*/

            using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Create))
                {
                    JsonSerializer.Serialize(fs, animals, options);
                }  
        }

        public static List<Animal> DeserializeJson()
        {
            if(File.Exists(Path.GetFullPath(path)))
            {
                using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Open))
                {
                    return JsonSerializer.Deserialize<List<Animal>>(fs, options);
                }
            }
            else
            {
                return new List<Animal>();
            }
        }
    }
}
