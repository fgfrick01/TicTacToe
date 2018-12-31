using System;
using System.Collections.Generic;
using System.Text;

namespace SARSATicTacToe
{
    class RandomMoveAgent : ITicTacToeAgent
    {
        Random rng { get; set; } = new Random();
        public void DoMove(TicTacToe game)
        {
            int val = 0;
            do
            {
                val = rng.Next(9);
            }
            while ((BoardSpaceState)(game.BoardState[val / 3, val % 3]) != BoardSpaceState.None);           
            game.Place(val / 3, val % 3);
        }
    }
}
