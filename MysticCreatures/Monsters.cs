using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysticCreatures
{
    internal class Monsters
    {
        public string Name { get; set; }

        public List<Monsters> Monster { get; set; }

        public void MonsterAttack()
        {
            Monster = new List<Monsters>();

            Monsters electricEel = new Monsters()
            {
                Name = "Electric Eel" +
                @"
                            _____
                     _..--'`     `'-.
                   .'            _   '.
                                (@)    \
                                _.---:-'
                               _\'._ \\
                       _.--''`` `'-.`' |
                     .'             `""`
                    /"
            };
            Monster.Add(electricEel);

            Monsters hammerHead = new Monsters()
            {
                Name = "HammerHead" + @"
                                     __
                  o                 /' ) 
                                  /'   (                          ,
                              __/'     )                        .' `;
               o      _.-~~~~'          ``---..__             .'   ;
                 _.--'  b)                       ``--...____.'   .'
                (     _.      )).      `-._                     <
                 `\|\|\|\|)-.....___.-     `-.         __...--'-.'.
                   `---......_______,,,`.___.'----... .'         `.;
                                                     `-`           ` 
                         "
            };
            Monster.Add(hammerHead);

            Monsters swordFish = new Monsters()
            {
                Name = "Sword Fish" + 
                            @"              /|
                                           / |                                           /|
                                          /  |                                          / |
                                         /    \                                        /  /
                              ____---~~~~      ~~~~~-------_______                    /   |
            ___________----~~~ O \                                ~~~~~----_____----~~    |
                  ~~~~~~~--_____  )                                         _____         |
                         __--~~~ /                                _____----~~~~~~------   \
                           ~~~~~~----_\ \____________--------~~~~~                     \  |
                                       \ \                                              \ |
                                         \|                                              \|

               unknown"
            };
            Monster.Add(swordFish);
        }
    }
}
