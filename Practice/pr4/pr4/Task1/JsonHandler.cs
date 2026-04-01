using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4.Task1
{
    public class JsonHandler
    {
        private static string path = "..\\..\\..\\Task1\\Resources\\saveFile.json";

        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public static void SerializeJson(List<TaskItem> taskItems)
        {
            if(taskItems.Count != 0)
            {
                using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Create))
                {
                    JsonSerializer.Serialize(fs, taskItems, options);
                }
            }    
        }

        public static List<TaskItem> DeserializeJson()
        {
            if(File.Exists(Path.GetFullPath(path)))
            {
                using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Open))
                {
                    return JsonSerializer.Deserialize<List<TaskItem>>(fs, options);
                }
            }
            else
            {
                return new List<TaskItem>();
            }
        }
    }
}
