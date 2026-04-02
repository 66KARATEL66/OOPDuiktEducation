using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4
{
    public class JsonHandler // Start using after Task 6
    {
        private string _path;
        private JsonSerializerOptions _options;

        public JsonHandler(string path, JsonSerializerOptions options = null)
        {
            _path = Path.GetFullPath(path);
            _options = options ?? new JsonSerializerOptions
            {
                WriteIndented = true
            };
        }

        public void SerializeJson<T>(T obj)
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(_path), FileMode.Create))
                {
                    JsonSerializer.Serialize(fs, obj, _options);
                }  
        }

        public T? DeserializeJson<T>()
        {
            
            if (!File.Exists(_path)) return default;

            Console.WriteLine(_path);
            string content = File.ReadAllText(_path);

            if (string.IsNullOrWhiteSpace(content)) return default;

            try
            {
                return JsonSerializer.Deserialize<T>(content, _options);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Invalid JSON format!");
                Console.WriteLine($"Details: {ex.Message}");


                Console.WriteLine("Starting with empty object...");
                Console.ReadKey(true);
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine("File may be corrupted or invalid format.");
                Console.WriteLine($"Details: {ex.Message}");

                Console.WriteLine("Starting with empty object...");
                Console.ReadKey(true);
                return default;
            }
        }
    }
}
