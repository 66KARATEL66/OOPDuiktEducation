using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task5
{
    public class Task5
    {
        List<Animal> animals = new List<Animal>();

        public void Example()
        {
            animals.Add(new Dog { Name = "Dog1", BarkVolume = 5 });
            animals.Add(new Dog { Name = "Dog2", BarkVolume = 1 });
            animals.Add(new Cat { Name = "Cat1", Lives = 3 });
            animals.Add(new Cat { Name = "Cat2", Lives = 9 });

            JsonHandler.SerializeJson(animals);

            animals = JsonHandler.DeserializeJson();

            ShowAnimals(animals);
        }

        public void ShowAnimals(List<Animal> animals)
        {
            for(int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"Animal {i + 1} name is {animals[i].Name} and it has {animals[i].GetType()} type");
            }
        }
    }
}
