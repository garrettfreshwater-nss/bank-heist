using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main (string[] args)

        {
            Console.WriteLine ("PLAN YOUR HEIST!!");

            Console.WriteLine ("What is the bank's difficulty level? (1 - 100)");
            string bankDifficultyString = Console.ReadLine ();

            // LIST OF DICTIONARIES
            List<Dictionary<string, string>> team = new List<Dictionary<string, string>> ();

            int bankDifficulty = int.Parse (bankDifficultyString);
            int successCount = 0;
            int failCount = 0;

            while (true)
            {

                Console.Write ("What is the member's name? ");
                string name = Console.ReadLine ();

                if (name == "")
                {
                    break;
                }

                Dictionary<string, string> teamMember = new Dictionary<string, string> ();

                Console.Write ("What is the member's skill? ");
                string skill = Console.ReadLine ();

                Console.Write ("What is the member's courage? ");
                string courage = Console.ReadLine ();

                teamMember.Add ("Name", name);
                teamMember.Add ("Skill Level", skill);
                teamMember.Add ("Courage", courage);

                team.Add (teamMember);

                Console.Clear ();
                Console.WriteLine ($"Team has {team.Count} members");
            }
            // Sum of team member skill level
            int combinedSkillLevel = 0;
            foreach (Dictionary<string, string> teamMember in team)
            {
                int skillLevelInt = int.Parse (teamMember["Skill Level"]);
                combinedSkillLevel += skillLevelInt;
            }

            // Run simulation mutiple times
            Console.WriteLine ("How many times should we run the simulation? ");
            int timesToRepeat = int.Parse (Console.ReadLine ());

            for (int i = 0; i < timesToRepeat; i++)
            {
                Random randy = new Random ();
                int luckValue = randy.Next (-10, 11);

                int totalBankDifficulty = bankDifficulty + luckValue;

                Console.WriteLine ($"Combined skill level: {combinedSkillLevel}");
                Console.WriteLine ($"Bank Difficulty Level: {totalBankDifficulty}");
                Console.WriteLine ($"---------------------------------");

                if (combinedSkillLevel >= totalBankDifficulty)
                {
                    Console.WriteLine ("💰💰💰💰");
                    successCount++;
                }
                else
                {
                    Console.WriteLine ("🚨🚨🚨🚨");
                    failCount++;
                }

            }
            Console.WriteLine ($"🌟🌟Successful Heists: {successCount}🌟🌟");
            Console.WriteLine ($"🚓🚓Failed Heists: {failCount}🚓🚓");
            Console.WriteLine ("------------------------------");
        }
    }
}