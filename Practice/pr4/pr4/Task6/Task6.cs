using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task6
{
    public class Task6
    {
        JsonHandler JsonHandler;
        Player Player;
        public void Example()
        {
            JsonHandler = new JsonHandler("..\\..\\..\\Task6\\Resources\\saveFile.json");
            /*Inventory Inventory = new Inventory();
            Inventory.Items.Add("Pistol");
            Inventory.Items.Add("Knife");

            Player Player = new Player { Name = "Kirito", Inventory = Inventory };
            
            JsonHandler.SerializeJson(Player);
             */

            this.Player = Deserializetion();

            Console.Write($"Player name is {Player.Name}. Items: ");
            foreach(var e in Player.Inventory.Items)
            {
                Console.Write($"{e}, ");
            }
        }

        public Player Deserializetion()
        {
            var player = JsonHandler.DeserializeJson<Player>() ?? new Player();
            player.InitilizeDefaults();
            return player;
        }
    }
}
