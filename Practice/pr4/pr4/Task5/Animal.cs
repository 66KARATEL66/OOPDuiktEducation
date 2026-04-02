using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4.Task5
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")] // визначає як буде називатись рядок в Json файлі котрий відповідає за тип об'єкта, по дефолту "$type"
    [JsonDerivedType(typeof(Dog), typeDiscriminator: "Dog")]
    [JsonDerivedType(typeof(Cat), typeDiscriminator: "Cat")]
    public abstract class Animal
    {
        public string Name { get; set; }
    }
}
