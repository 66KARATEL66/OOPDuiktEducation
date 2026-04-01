using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4.Task3
{
    public class JsonHandler
    {
        private static string path = "..\\..\\..\\Task3\\Resources\\saveFile.json";

        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public static void SerializeJson(Author author)
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Create))
                {
                    JsonSerializer.Serialize(fs, author, options);
                }  
        }

        public static Author DeserializeJson()
        {
            if(File.Exists(Path.GetFullPath(path)))
            {
                using (FileStream fs = new FileStream(Path.GetFullPath(path), FileMode.Open))
                {
                    return JsonSerializer.Deserialize<Author>(fs, options);
                }
            }
            else
            {
                return new Author();
            }
        }
    }
}
