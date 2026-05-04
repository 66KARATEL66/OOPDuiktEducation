using AsyncDataLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Infrastructure
{
    public class JsonDataSerializer : IDataSerializer
    {
        //private string _path;
        private JsonSerializerOptions _options;

        public JsonDataSerializer(JsonSerializerOptions options = null)
        {
            //_path = Path.GetFullPath(path);
            _options = options ?? new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
        }

        public async Task Serialize<T>(T obj, string path)
        {
            string _path = Path.GetFullPath(path);
            await using FileStream fs = new FileStream(
                _path,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 4096,
                useAsync: true);

            await JsonSerializer.SerializeAsync(fs, obj, _options);
        }

        public async Task<T?> Deserialize<T>(string path)
        {
            string _path = Path.GetFullPath(path);
            if (!File.Exists(_path))
                return default;

            FileInfo fileInfo = new FileInfo(_path);

            if (fileInfo.Length == 0)
                return default;

            try
            {
                await using FileStream fs = new FileStream(
                    _path,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read,
                    bufferSize: 4096,
                    useAsync: true);

                return await JsonSerializer.DeserializeAsync<T>(fs, _options);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Invalid JSON format!");
                Console.WriteLine($"Details: {ex.Message}");

                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine("File may be corrupted or invalid format.");
                Console.WriteLine($"Details: {ex.Message}");

                return default;
            }
        }
    }
}