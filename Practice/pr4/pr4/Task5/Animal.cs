using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4.Task5
{
    [JsonDerivedType(typeof(Dog), typeDiscriminator: "Dog")]
    [JsonDerivedType(typeof(Cat), typeDiscriminator: "Cat")]
    public abstract class Animal
    {
        public string Name { get; set; }
    }
}
