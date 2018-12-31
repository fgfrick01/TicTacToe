using System;
using System.Collections.Generic;
using System.Text;

namespace SARSATicTacToe
{
    internal class SARSAAgent: ITicTacToeAgent
    {
        Dictionary<BoardSpaceState[,], int> PolicyDictionary { get; set; }
        Random rng { get; set; }

        internal SARSAAgent()
        {
            PolicyDictionary = new Dictionary<BoardSpaceState[,], int>(new MyEqualityComparer());
            rng = new Random();
        }

        internal int PlayGame(RandomMoveAgent randomagent)
        {
            var game = new TicTacToe();
            var playerOneMoves = new List<BoardSpaceState[,]>();
            //var playerTwoMoves = new List<BoardSpaceState[,]>();

            int alternator = 1;
            while (game.Player1Win() == null && !game.IsDraw())
            {
                if (alternator == 1)
                {
                    playerOneMoves.Add((BoardSpaceState[,])game.BoardState.Clone());
                    DoMove(game);
                    alternator = 2;
                }
                else if (alternator == 2)
                {
                    randomagent.DoMove(game);
                    alternator = 1;
                }
               
            }
            if(!game.IsDraw())
            {
                bool winner = (bool)game.Player1Win();
                if (winner)
                {
                    //foreach (var move in playerTwoMoves)
                    //{
                    //    PolicyDictionary.Remove(move);
                    //}
                    return 1;
                }
                else
                {
                    foreach (var move in playerOneMoves)
                    {
                        if(PolicyDictionary.Remove(move))
                        {

                        }
                    }
                    return 2;
                }
            }
            return 0;
        }

        public void DoMove(TicTacToe game)
        {
            if (!PolicyDictionary.ContainsKey(game.BoardState))
            {
                
                int val = 0;
                do
                {
                    val = rng.Next(9);
                }
                while ((BoardSpaceState)(game.BoardState[val/3, val%3]) != BoardSpaceState.None);
                PolicyDictionary.Add((BoardSpaceState[,])game.BoardState.Clone(), val);
            }

            game.Place(PolicyDictionary[game.BoardState] / 3, PolicyDictionary[game.BoardState] % 3);
        }

        
    }

    internal class MyEqualityComparer : IEqualityComparer<BoardSpaceState[,]>
    {
        public bool Equals(BoardSpaceState[,] x, BoardSpaceState[,] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i / 3, i % 3] != y[i / 3, i % 3])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(BoardSpaceState[,] obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Length; i++)
            {
                unchecked
                {
                    result = result * 23 + (int)obj[i / 3, i % 3];
                }
            }
            return result;
        }
    }
}
