using System;
using System.Collections.Generic;
using RatRace.Class;
using RatRace.Terrain;
using RatRace.Rats;
using RatRace.Items;

namespace RatRace
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the rat race!");
            Console.WriteLine("Bet on rats and earn rewards! If you dare");
            Console.WriteLine("But first, what is your name?");
            RaceManager raceManager = new RaceManager();
            string PlayerName = Console.ReadLine();
            while (PlayerName == "")
            {
                Console.WriteLine("You didn't enter your name, please try again");
                PlayerName = Console.ReadLine();

            }
            int money = RNG.Range(100, 1000);
            SpeedShoes speedshoes = new SpeedShoes();
            raceManager.CreatePlayer(PlayerName, money);
            raceManager.CreatePlayer();
            Console.WriteLine("Great! Welcome " + PlayerName);
            //Start over from here?
            while (raceManager.Players[0].Money > 0)
            {
                raceManager.Rats.Clear();
                raceManager.bookmaker.Bets.Clear();
                Console.WriteLine("Your balance: " + raceManager.Players[0].Money);
                Console.WriteLine("Here's the line up for the next race");
                Console.WriteLine("The runners are:");

                int NumberRats = RNG.Range(2, 11);
                string[] names = { "Lui", "Palle", "Humus", "Ost", "Paladin", "Bard", "Kartoffel", "Ratatouille", "Flæskesteg", "BrunSovs", "Bluey", "Rory" };
                for (int i = 0; i <= NumberRats; i++)
                {
                    string RatName = names[i];
                    raceManager.CreateRat(RatName);

                    Console.WriteLine(RatName + "\nWho is a " + raceManager.Rats[i].Type + " rat");
                }
                string TrackName = "";
                int NumberTrack = RNG.Range(20, 51);
                int tracklength = NumberTrack;
                int whichTrack = RNG.Range(1, 4);
                switch (whichTrack)
                {
                    case 1:
                        Console.WriteLine("The track for this race is a plain grass field! \nPlain rats will have an advantage");
                        TrackName = "Plain grass field";
                        break;
                    case 2:
                        Console.WriteLine("The track for this race is a forrest! \nForrets rats will have an advantage");
                        TrackName = "Forrest";
                        break;
                    case 3:
                        Console.WriteLine("The track for this race is a sand beach! \nBeach rats will have an advantage");
                        TrackName = "Beach";
                        break;
                }

                raceManager.CreateTrack(TrackName, tracklength);

                raceManager.CreateRace(raceManager.RaceID, raceManager.Rats, raceManager.Tracks[0]);
                Console.ReadLine();
                Console.Clear();
                string ratname = "";
                Rat rat = null;
                Console.WriteLine("Do you wish to bet on any rats today? \n 1: Yes \n 2: No");
                int ChooseBet = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (ChooseBet)
                {
                    case 1:
                        Console.WriteLine("Alright, which rat do you want to bet on?");
                        Console.WriteLine("As a reminder, the track is a " + TrackName);
                        for (int i = 0; i < raceManager.Rats.Count; i++)
                        {
                            Console.WriteLine(raceManager.Rats[i].Name + " The " + raceManager.Rats[i].Type + " rat");
                        }
                        bool ratFound = false;
                        while (!ratFound)
                        {

                            try
                            {
                                Console.WriteLine("Type the name of the rat you will bet on:");
                                ratname = Console.ReadLine();
                                for (int j = 0; j < raceManager.Rats.Count; j++)
                                {
                                    if (ratname == raceManager.Rats[j].Name)
                                    {
                                        rat = raceManager.Rats[j];
                                        Console.WriteLine("You've chosen " + ratname + " The " + raceManager.Rats[j].Type + " rat");
                                        ratFound = true;
                                    }

                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error yyou are of all the bad spellings!");
                            }

                        }


                        Console.WriteLine("Your balance: " + raceManager.Players[0].Money);
                        Console.WriteLine("And how much do you want to bet? Remember, you get 2x back if you win");
                        while (!int.TryParse(Console.ReadLine(), out money))
                        {
                            Console.WriteLine("Incorret format try again");
                        }

                        while (money > raceManager.Players[0].Money)
                        {
                            Console.WriteLine("That's more than you have! That won't do, try again");
                            money = int.Parse(Console.ReadLine());
                        }
                        raceManager.Players[0].Money -= money;
                        raceManager.bookmaker.PlaceBet(raceManager.Races[0], rat, raceManager.Players[0], money);
                        Console.Clear();
                        if (raceManager.Players[0].Money >= 200)
                        {
                            Console.WriteLine("Do you wish to purchance some speed shoes for your rat? Only 200? \n1: Yes \n2: No");
                            int ChooseItem = int.Parse(Console.ReadLine());

                            switch (ChooseItem)
                            {
                                case 1:
                                    Console.WriteLine("Wise choice! I'll make sure your rat equips the shoes");
                                    raceManager.Players[0].Money -= 200;
                                    speedshoes.Equip(rat);
                                    break;
                                case 2:
                                    Console.WriteLine("Your choice, good luck");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Alright, your choice");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
                raceManager.ConductRace(raceManager.Races[0]);
                Console.WriteLine("The race is now over and we have our winner! Ready to find out who it was?");
                Console.ReadLine();
                raceManager.Races[0].GetWinner();
                if (raceManager.bookmaker.Bets.Count != 0)
                {
                    raceManager.bookmaker.Bets[0].PayWinnings();
                    Console.WriteLine("your balance after the race: " + raceManager.Players[0].Money);
                }
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Do you whis to see the report of the race? \n 1: Yes \n 2: No");
                int chooseRapport = int.Parse(Console.ReadLine());
                switch (chooseRapport)
                {
                    case 1:
                        raceManager.ViewRaceRapport(raceManager.Races[0]);
                        break;
                    case 2:
                        Console.WriteLine("No problem");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
                rat.item.Unequip(rat);
            }
        }
    }
}
