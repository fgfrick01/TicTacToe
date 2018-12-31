using System;

namespace SARSATicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            //var game = new TicTacToe();
            //while (game.Player1Win() == null)
            //{
            //    if (game.Player1Turn())
            //    {
            //        Console.WriteLine("Player One's Turn");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Player Two's Turn");
            //    }
            //    Console.WriteLine(game.ToString());
            //    var userInput = Console.ReadLine();
            //    var parsedInput = Convert.ToInt32(userInput);
            //    game.Place(parsedInput / 3, parsedInput % 3);
            //}


            var agent = new SARSAAgent();
            var randomagent = new RandomMoveAgent();


            int sarsaLosses= 0;
            int sarsaWins = 0;
            int draws = 0;


            for (int i = 0; i < 100_000; i++)
            {
                if (i % 1000 == 0)
                {
                    Console.WriteLine(i);
                    Console.WriteLine("sarsaWins: " + sarsaWins + " draws: " + draws + " sarsalosses: " + sarsaLosses);
                    sarsaWins = 0;
                    sarsaLosses = 0;
                    draws = 0;
                }

                var game = new TicTacToe();
                int result = agent.PlayGame(randomagent);
                if (result == 1)
                {
                    sarsaWins++;
                }
                else if (result == 2)
                {
                    sarsaLosses++;
                }
                else
                {
                    draws++;
                }
            }
            //Console.WriteLine("\n sarsaWins: " + totalSarsaWins + "\n draws: " + totalDraws + "\n sarsaLosses: " + totalSarsaLosses);
            Console.ReadLine();



            //for (int i = 0; i < 1000; i++)
            //{
            //    if (i % 100 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //
            //    var game = new TicTacToe();
            //    var randomagent = new RandomMoveAgent();
            //    int alternator = 1;
            //    while (game.Player1Win() == null && !game.IsDraw())
            //    {
            //        if (alternator == 1)
            //        {
            //            agent.DoMove(game);
            //            alternator = 2;
            //        }
            //        else if (alternator == 2)
            //        {
            //            randomagent.DoMove(game);
            //            alternator = 1;
            //        }
            //    }

            //    if (game.Player1Win() == true)
            //    {
            //        sarsaWins++;
            //    }
            //    else if (game.Player1Win() == false)
            //    {
            //        randomWins++;
            //    }
            //    else
            //    {
            //        draws++;
            //    }
            //}
            //Console.WriteLine("sarsaWins: " + sarsaWins + "\n draws: " + draws + "\n sarsaLosses: " + randomWins);
            //Console.ReadLine();

            //var game = new TicTacToe();
            //while (game.Player1Win() == null && !game.IsDraw())
            //{


            //    if (game.Player1Turn())
            //    {
            //        Console.WriteLine("Player One's Turn");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Player Two's Turn");
            //    }

            //    Console.WriteLine(game.ToString());
            //    agent.DoMove(game);
            //    randomagent.DoMove(game);
            //
            //var userInput = Console.ReadLine();
            //var parsedInput = Convert.ToInt32(userInput);
            //game.Place(parsedInput / 3, parsedInput % 3);
            //}





        }
    }
}
