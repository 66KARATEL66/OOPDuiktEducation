using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4.Task4
{
    public class JsonHandler
    {
        private static string path = "..\\..\\..\\Task4\\Resources\\saveFile.json";

        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        public static void SerializeJson(Order order)
        {
            /*options.Converters.Add(new JsonStringEnumConverter());*/

            using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Create))
                {
                    JsonSerializer.Serialize(fs, order, options);
                }  
        }

        public static Order DeserializeJson()
        {
            if(File.Exists(Path.GetFullPath(path)))
            {
                using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Open))
                {
                    return JsonSerializer.Deserialize<Order>(fs, options);
                }
            }
            else
            {
                return new Order();
            }
        }
    }
}
