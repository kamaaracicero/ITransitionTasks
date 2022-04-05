using System;
using System.Linq;
using System.Security.Cryptography;

namespace Task_3
{
    class Program
    {
        private static bool CheckArgs(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Wronf number of arguments.");
                return false;
            }
            else if (args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("All moves should be unique.");
                return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            args = new[] { "Rock", "Scissors", "Paper" };
            if (!CheckArgs(args))
            {
                return;
            }

            RulesTable rulesTable = new RulesTable(args);
            GameJudge judge = new GameJudge(args.Length);

            bool isGameEnd = false;

            while (!isGameEnd)
            {
                Console.Clear();
                var key = Crypto.GenerateKey();
                var computerMove = RandomNumberGenerator.GetInt32(args.Length);
                var hmac = Crypto.GenerateHMAC(key, args[computerMove]);

                Console.WriteLine("HMAC: " + hmac);
                Console.WriteLine("Actions:");
                for (int index = 0; index < args.Length; index++)
                {
                    Console.WriteLine(index + 1 + " - " + args[index]);
                }

                Console.WriteLine("0 - Exit");
                Console.WriteLine("? - Help");

                Console.Write("Your move - ");
                var answer = Console.ReadLine();

                if (answer == "?")
                {
                    Console.Clear();
                    rulesTable.Print();
                    Console.WriteLine("Press any button");
                    Console.ReadKey();
                    continue;
                }

                if (answer == "0")
                {
                    isGameEnd = true;
                    continue;
                }

                int playerMove = 0;
                if (!int.TryParse(answer, out playerMove)
                    || playerMove <= 0
                    || playerMove > args.Length)
                {
                    continue;
                }

                Console.WriteLine("Your move: " + args[playerMove - 1]);
                Console.WriteLine("Computer move: " + args[computerMove]);

                switch (judge.CheckMove(playerMove - 1, computerMove))
                {
                    case GameResults.WIN:
                        Console.WriteLine("You won!");
                        break;

                    case GameResults.LOSE:
                        Console.WriteLine("You lost!");
                        break;

                    default:
                        Console.WriteLine("Draw!");
                        break;
                }

                Console.WriteLine("HMAC key: " + key);
                Console.WriteLine("\nPress any button");
                Console.ReadKey();
            }
        }
    }
}
