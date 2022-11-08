using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Formats.Asn1.AsnWriter;

namespace MysticCreatures
{
    class Game
    {
        string gameTitle = "Mystic Creatures";
        public Player player;
        public Random random;
        public Monsters monsters;


        public Game(string title)
        {
            gameTitle = title;
            player = new Player();
            random = new Random();
            monsters = new Monsters();
            Start();
        }


        static void PromptToPressAnyKey()
        {
            WriteLine("Press any key to continue...");
            ReadKey(true);
        }

        public void Start()
        {
            Title = gameTitle;
            Welcome();
            player.Pouch();
            monsters.MonsterAttack();
            Story();
            ReadKey();
        }

        void Welcome()
        {
            Clear();
            WriteLine("You were wandering around under the deep blue sea and suddenly you saw a sign said...");
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine(
                @"
                  _| |____________________________________________| |__
                (__   ____________________________________________   __)
                   | |                                            | |
                   | |                                            | |
                   | |                 WELCOME TO                 | |
                   | |                                            | |
                   | |               OCEANO VILLAGE               | |
                   | |                                            | |
                 __| |____________________________________________| |__
                (__   ____________________________________________   __)
                   | |                                            | |");
            ResetColor();
            PromptToPressAnyKey();
        }

        void Story()
        {
            Clear();
            WriteLine("\nHello, you don't seem like you're from around here. You are lost, aren't you?");
            WriteLine("\nYou are at the Oceano Village, where human and sea animals live harmoniously~");
            WriteLine("\nYou will have to look for Turlie The Sorcerer in the SeaWeed Forest. He will be able to help you go back home. The journey can be tough and remember, helping other villagers is also important.");
            
            // Ask the user if they want to play the game
            WriteLine("\nWill you accept the challenge? \n1) Yes 2) No");

            // Read user input
            string UserChoice = ReadLine();
            if (UserChoice == "1")
            {
                Clear();
                WriteLine("Awesome! Good luck!");
                PromptToPressAnyKey();
                Act1();
            }
            else if (UserChoice == "2")
            {
                Clear();
                WriteLine("I guess you will live with us then.");
                PromptToPressAnyKey();
                End();
            }
            else
            {
                Clear();
                WriteLine("Command invalid. Please press 1 or 2.");
                PromptToPressAnyKey();
                Story();
            }
        }

        public void DisplayItem()
        {
            // Display items in the pouch
            int amountOfItem = player.Items.Count;

            for (int i = 0; i <= amountOfItem - 1; i++)
            {
                WriteLine($"{i + 1}) {player.Items[i].Name}");
            }

            WriteLine($"You have {amountOfItem} items");
        }


        public void Act1()
        {
            Clear();
            WriteLine("('3'): Hello! My name is Miss Octopy! What is your name?");
            // Read user's name
            player.Name = ReadLine();

            // 1st Round
            WriteLine(@$"\('3')/: Hi {player.Name}! You are standing on the way to the SeaWeed Forest. You can head straight or make a right turn. What do you want to do? ");

            WriteLine("1) Head straight \n2) Turn right ");
            // Read user input
            string UserChoice2 = ReadLine();

            // Two scenarios are given to the user
            //First scenario
            if (UserChoice2 == "1")
            {
                Clear();
                WriteLine("You decided to keep walking straight ahead and saw an old lady flounder was picking up her groceries. It seemed like she just dropped it. She saw you and asked for help. ('3')?: Do you want to help her? \n1) Help the old lady \n2) Ignore her and continue your journey");
                string quest1 = ReadLine();

                // Two outcomes are given in this first scenario
                switch (quest1)
                {
                    case "1":
                        Clear();
                        ForegroundColor = ConsoleColor.Yellow;
                        WriteLine("The old flounder lady: Thank you so much for helping this old one right here. Watch out for the monsters alright.");
                        ResetColor();
                        WriteLine("You waved at her and continued on your journey. You felt good about yourself. ");
                        PromptToPressAnyKey();
                        Act2();
                        break;
                    case "2":
                        Clear();
                        WriteLine("You totally ignored her. You kept walking and suddenly a rock flying from somewhere hit your head. You died instantly.");
                        PromptToPressAnyKey();
                        End();
                        break;

                    default:
                        WriteLine("Command invalid. Please enter a number.");
                        WriteLine("Press enter to restart...");
                        ReadKey();
                        Act1();
                        break;
                }
            }
            // Second scenario
            else if (UserChoice2 == "2")
            {
                Clear();
                WriteLine("You decided to turn right. As you walking, you kept hearing a crying noise faintly somewhere. You looked around and found a little mermaid. She lost her mom and didn't remember the way home. ('3')?: Do you want to stop and help her? \n1) Nope, minding your own business and continue with your journey \n2) Help her find her mom");
                string quest2 = ReadLine();

                // Two outcomes in this second scenario
                switch (quest2)
                {
                    case "1":
                        Clear();
                        WriteLine("You are too cruel! You got hit by a drunk-driver car and died.");
                        PromptToPressAnyKey();
                        End();
                        break;

                    case "2":
                        Clear();
                        WriteLine("You held her hand and walked around to see if her mom was looking for her. Luckily, you found her in a market. She thanked you continuously. The little girl turned to you and whispered something in your ear.");
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("The little mermaid: There are things out here. Scary things. You have to be careful, OK?");
                        ResetColor();
                        WriteLine("You nodded at her. You said goodbye to them and continued with your journey.");
                        PromptToPressAnyKey();
                        Act2();
                        break;

                    default:
                        WriteLine("Command invalid. Please enter a number.");
                        WriteLine("Press enter to restart...");
                        ReadKey();
                        Act1();
                        break;
                }
            }
            else
            {
                Clear();
                WriteLine("Please choose an option");
                PromptToPressAnyKey();
                Act1();
            }
        }

        public void Act2()
        {
            Clear();
            // 2nd Round
            WriteLine("You found a house. ('3')?: Do you want to go inside or keep going? \n1) Go inside the house \n2) Keep going");
            string UserChoice3 = ReadLine();

            // Two scenarios are also given to the user in this round
            //First scenario
            if (UserChoice3 == "1")
            {
                Clear();
                WriteLine("You opened the door and stepped inside. You looked around, it was quite dark to see anything clearly. For some reasons, this house gave you a weird feeling...");
                PromptToPressAnyKey();
                WriteLine(@"\(`O`)/: AHHHHH! There's something moving over there!");
                ReadKey();
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine(@"  
                         _,
                       _//}_
                      /.. ~~\/}
                      \-  ))/\}
                       `---`
                     ");
                ResetColor();
                WriteLine("('*'): Oh, it's just a fish. Seems like there's nothing in here. Let's get out of this house.");
                PromptToPressAnyKey();
                Clear();

                // Ask user if they want to check the items in the pouch
                WriteLine("On the way out, you accidentally stepped on a magic pouch. You picked it up and it seemed like it didn't belong to anyone. ('3')?: Do you want to check what's inside the pouch? \n1) Yes \n2) No");
                // Read user input
                string quest3 = ReadLine();

                // Choices for user
                switch (quest3)
                {
                    case "1":
                        DisplayItem();
                        WriteLine("These items could be useful, so you decided to keep it.");
                        PromptToPressAnyKey();
                        Act3();
                        break;

                    case "2":
                        WriteLine("You didn't check inside the pouch, but you brought it with you anyway.");
                        PromptToPressAnyKey();
                        Act3();
                        break;

                    default:
                        WriteLine("Command invalid. Please enter a number.");
                        WriteLine("Press enter to restart...");
                        ReadKey();
                        Act2();
                        break;
                }
               
            }
            // Second scenario
            else if (UserChoice3 == "2")
            {
                Clear();
                WriteLine("You were walking and suddenly you saw one of the villagers Mr. SeaHorse. You tried to ask him about the direction to the SeaWeed Forest, and it turned out Mr. SeaHorse and Turlie The Sorcerer were friends and he had been there before.");
                WriteLine("He told you to go straight from here and avoid the 'flying umbrellas'. You really didn't understand what he meant by that.");
                WriteLine("He also gave you a magic pouch and thought that this might be useful for you. You accepted it, thanked him, and headed straight.");
                
                // Ask user if they want to check the items in the pouch
                WriteLine("('3') ?: Do you want to check what's in the pouch? \n1) Yes \n2) No");
                // Read user's choice
                string quest4 = ReadLine();

                switch (quest4)
                {
                    case "1":
                        DisplayItem();
                        PromptToPressAnyKey();
                        Act3();
                        break;

                    case "2":
                        PromptToPressAnyKey();
                        Act3();
                        break;

                    default:
                        WriteLine("Command invalid. Please enter a number.");
                        WriteLine("Press enter to restart...");
                        ReadKey();
                        Act2();
                        break;
                }
            }
            else
            {
                Clear();
                WriteLine("Please choose an option");
                PromptToPressAnyKey();
                Act2();
            }
        }

        public void Act3()
        {
            Clear();
            // 3rd Round
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine(@"
                  .-; ':':'-.
                  {'.'.'.'.'.}
                   )        '`.
                  '-. ._ ,_.-='
                    `). ( `); (
                     ('. .)(,'.)
                      )( , ').(
                     ( .').'(').
                     .)(' ).('
                      '  ) (  ).
                       .'( .)'
                         .).'
                ");
            ResetColor();
            WriteLine("You had arrived at the sea trench where there were thousands of jellyfish. ('3'): You can go through here, which will take us to the SeaWeed Forest faster, or go around, which will take longer.");
            
            // Ask user if they want to go through or go around
            WriteLine("('3')?: What do you want to do? \n1) Take shortcut and pass through the jellyfish \n2) Go around them");
            // Read user input
            string UserChoice4 = ReadLine();

            // Choices
            if (UserChoice4 == "1")
            {
                Clear();
                WriteLine("Oops sorry! You got stung by the poinsonous jellyfish. You died.");
                PromptToPressAnyKey();
                End();
            }

            else if (UserChoice4 == "2")
            {
                Clear();
                WriteLine("Good choice! It did take you longer to get pass them, but you were safe!");
                PromptToPressAnyKey();
                Fight();
            }
            else
            {
                Clear();
                WriteLine("Please choose an option");
                PromptToPressAnyKey();
                Act3();
            }
        }

        public void Fight()
        {
            Clear();
            // Final Round: Fight monsters
            WriteLine("('3'): You have arrived at the SeaWeed Forest. You have to pass through this road full of monsters in order to see Turlie The Sorcerer.");
            PromptToPressAnyKey();
            ForegroundColor = ConsoleColor.Red;
            WriteLine("(`O`): Watch out! There's one coming!");
            ResetColor();

            // Randomize the list of monsters
            int index = random.Next(monsters.Monster.Count - 1);
            WriteLine($"\n{monsters.Monster[index].Name}");

            WriteLine("(`O`): Hurry! Check your pouch and use the weapon to fight it!");

            // Display weapon choice
            DisplayItem();

            //Read user input
            string pickWeapon = ReadLine();

            Clear();
            WriteLine(@"
            .---.
            (\|/)
            --0--
            (/|\) boom!
            ");
            PromptToPressAnyKey();


            int pointGain = 0;

            
            // User can only use the weapon once
            // There are 4 weapon choices in total

            if (pickWeapon == "1")
            {
                // Each weapon choice is giving random point at a certain range
                pointGain = random.Next(6, 10);
                WriteLine($"You got {pointGain} points!");

                // User's points adds up each time they retry the game
                player.Point = player.Point + pointGain;

                // Remove this weapon option after it being chosen
                player.Items.RemoveAt(0);

                // User has to get 10 points or more to win the fight
                if (player.Point >= 10)
                {
                    WriteLine($"Your total point is {player.Point} points. You won!");
                    PromptToPressAnyKey();
                    MeetTurlie();
                }
                // User can retry until they get 10 or more points
                else
                {
                    WriteLine("Try again.");
                    PromptToPressAnyKey();
                    Fight();
                }
            }
            else if (pickWeapon == "2")
            {
                pointGain = random.Next(1, 5);
                WriteLine($"You got {pointGain} points!");
                player.Point = player.Point + pointGain;
                player.Items.RemoveAt(1);

                if (player.Point >= 10)
                {
                    WriteLine($"Your total point is {player.Point} points. You won!");
                    PromptToPressAnyKey();
                    MeetTurlie();
                }
                else
                {
                    WriteLine("Try again.");
                    PromptToPressAnyKey();
                    Fight();
                }

            }
            else if (pickWeapon == "3")
            {
                pointGain = random.Next(3, 8);
                WriteLine($"You got {pointGain} points!");
                player.Point = player.Point + pointGain;
                player.Items.RemoveAt(2);

                if (player.Point >= 10)
                {
                    WriteLine($"Your total point is {player.Point} points. You won!");
                    PromptToPressAnyKey();
                    MeetTurlie();
                }
                else
                {
                    WriteLine("Try again.");
                    PromptToPressAnyKey();
                    Fight();
                }

            }
            else if (pickWeapon == "4")
            {
                pointGain = random.Next(1, 3);
                WriteLine($"You got {pointGain} points!");
                player.Point = player.Point + pointGain;
                player.Items.RemoveAt(3);

                if (player.Point >= 10)
                {
                    WriteLine($"Your total point is {player.Point} points. You won!");
                    PromptToPressAnyKey();
                    MeetTurlie();
                }
                else
                {
                    WriteLine("Try again.");
                    PromptToPressAnyKey();
                    Fight();
                }

            }
            else
            {
                WriteLine("Command invalid. Please choose your weapon.");
                PromptToPressAnyKey();
                Fight();
            }
        }

        public void MeetTurlie()
        {
            Clear();
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine(@"
                                                         .''.
                           .''.      .        * '' *    :_\/_:      . 
                          :_\/_:   _\(/_  .:. *_\/_ *   : /\ :   .'.:.'.
                      .''.: /\ :   ./)\   ':' * /\  * :  '..'.   -=:o:=-
                     :_\/_:'.:::.    '* '' *   *  '.\'/.'  _\(/_ '.':'.'
                     : /\ : :::::     *_\/_*      -= o = -  /)\     '  *
                      '..'  ':::'     * /\ *      .'/.\'.    '
                          *            *..*          :
                            *
                            *
                        ");

            ForegroundColor = ConsoleColor.Green;
            WriteLine("\nTurlie The Sorcerer: You have arrived here safely! Congratulations! Now, I can take you back home!");
            ResetColor();

            // Ask user if they want to play again or exit the game
            WriteLine("\n1) Play again 2) Exit");

            string UserChoice5 = ReadLine();
            if (UserChoice5 == "1")
            {
                Start();
            }

            else if (UserChoice5 == "2")
            {
                End();
            }

            else
            {
                WriteLine("Command invalid. Please choose an option.");
                PromptToPressAnyKey();
                MeetTurlie();
            }   
        }
          

        public void End()
        {
            Clear();
            WriteLine("Game Over!");
            // Credit for ASCII arts
            WriteLine("\n~~~~~Credits~~~~~");
            WriteLine("> Border by dc, https://www.asciiart.eu/art-and-design/borders");
            WriteLine("> Little fish by jgs, https://www.oocities.org/spunk1111/aquatic.htm");
            WriteLine("> Jelly fish by unknown, https://www.oocities.org/spunk1111/aquatic.htm");
            WriteLine("> Explosive by unknown, https://www.asciiart.eu/weapons/explosives");
            WriteLine("> Fireworks by jgs, https://www.asciiart.eu/holiday-and-events/fireworks");
            WriteLine("> Moray eel by jgs, https://www.oocities.org/spunk1111/aquatic.htm");
            WriteLine("> Shark by jgs, https://www.oocities.org/spunk1111/aquatic.htm");
            WriteLine("> Swordfish by unknown, https://ascii.co.uk/art/swordfish");
        }
    }
}
