using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task7
{
    public class Task7
    {
        List<Player> players = new List<Player>();
        JsonHandler jsonHandler;

        public void Example()
        {

            players.Add(new Player { Name = "Devid" });
            players.Add(new Player { Name = "Darta" });

            jsonHandler = new JsonHandler("..\\..\\..\\Task7\\Resources\\saveFile.json");
            jsonHandler.SerializeJson(players);

            foreach(var e in players)
            {
                Console.WriteLine($"Player name is {e.Name}");
            }

            players = Deserialization();

            foreach (var e in players)
            {
                Console.WriteLine($"Player name is {e.Name} and his level {e.Level}");
            }
        }

        public List<Player> Deserialization()
        {
            jsonHandler = new JsonHandler("..\\..\\..\\Task7\\Resources\\saveFileOld.json");
            var content = jsonHandler.DeserializeJson<List<Player>>() ?? new List<Player>();
            foreach(var e in content)
            {
                e.InitilizeDefaults();
            }
            return content;
        }
    }
}
