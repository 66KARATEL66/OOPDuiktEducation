using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Interfaces
{
    public interface IDataSerializer
    {
        Task Serialize<T>(T obj, string path);
        Task<T?> Deserialize<T>(string path);
    }
}
