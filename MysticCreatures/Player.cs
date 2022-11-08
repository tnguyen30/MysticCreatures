using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysticCreatures
{
    class Player
    {
        public string Name { get; set; }
        public int Point { get; set; }

        public List<Item> Items { get; set; }

        public void Pouch()
        {
            Items = new List<Item>();

            Item spicyBomb = new Item()
            {
                Name = "Spicy Bomb"
            };
            Items.Add(spicyBomb);

            Item arrow = new Item()
            {
                Name = "Arrow"
            };
            Items.Add(arrow);

            Item sword = new Item()
            {
                Name = "Sword"
            };
            Items.Add(sword);

            Item seashell = new Item()
            {
                Name = "Seashell"
            };
            Items.Add(seashell);
        }
    }
}
