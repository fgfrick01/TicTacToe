using System;
using System.Collections.Generic;
using System.Text;

namespace SARSATicTacToe
{
   

    internal class TicTacToe
    {
        internal BoardSpaceState[,] BoardState { get; set; }

        internal TicTacToe()
        {
            BoardState = new BoardSpaceState[3, 3];
        }

        internal void Place(int r, int c)
        {
            if(BoardState[r,c] != BoardSpaceState.None)
            {
                throw new Exception("Space Occupied");
            }
            else if(Player1Turn())
            {
                BoardState[r, c] = BoardSpaceState.Player1;
            }
            else
            {
                BoardState[r, c] = BoardSpaceState.Player2;
            }
        }

        public override string ToString()
        {
            String boardStr = "";
            for (int r = 0; r < BoardState.GetLength(0); r++)
            {
                for(int c = 0; c < BoardState.GetLength(1); c++)
                {
                    if (BoardState[r, c] == BoardSpaceState.Player1)
                    {
                        boardStr += " | X | ";
                    }
                    else if(BoardState[r,c] == BoardSpaceState.Player2)
                    {
                        boardStr += " | O | ";
                    }
                    else
                    {
                        boardStr += " |   | ";
                    }
                }
                boardStr += "\n";
            }
            return boardStr;
        }

        internal bool IsDraw()
        {
            if(Player1Win() != null)
            {
                return false;
            }
            bool draw = true;
            foreach(var i in BoardState)
            {
                if(i == BoardSpaceState.None)
                {
                    draw = false;
                }
            }
            return draw;
        }

        internal bool Player1Turn()
        {
            int onesMinusTwos = 0;
            foreach (var i in BoardState)
            {
                if (i != BoardSpaceState.None)
                {
                    onesMinusTwos += i == BoardSpaceState.Player1 ? 1 : -1;
                }
            }
            if(onesMinusTwos == 0)
            {
                return true;
            }
            else if (onesMinusTwos == 1)
            {
                return false;
            }
            else
            {
                throw new Exception("Invalid Board State");
            }
        }

        internal bool? Player1Win()
        {
            bool playerOneWin = PlayerHasWon(BoardSpaceState.Player1);
            bool playerTwoWin = PlayerHasWon(BoardSpaceState.Player2);

            if (playerOneWin && playerTwoWin)
            {
                throw new Exception("Invalid: Two players have won.");
            }
            else if (playerOneWin)
            {
                return true;
            }
            else if (playerTwoWin)
            {
                return false;
            }
            else
            {
                return null;
            }
        }

        bool PlayerHasWon(BoardSpaceState playerMarker)
        {
            if(playerMarker == BoardSpaceState.None)
            {
                throw new Exception("This is not a player");
            }

            for(int r = 0; r < BoardState.GetLength(0); r++)
            {
                bool victoryOnRow = true;
                for(int c = 0; c < BoardState.GetLength(1); c++)
                {
                    if(BoardState[r,c] != playerMarker)
                    {
                        victoryOnRow = false;
                    }
                }
                if(victoryOnRow)
                {
                    return true;
                }
            }

            for (int c = 0; c < BoardState.GetLength(0); c++)
            {
                bool victoryOnColumn = true;
                for (int r = 0; r < BoardState.GetLength(1); r++)
                {
                    if (BoardState[r, c] != playerMarker)
                    {
                        victoryOnColumn = false;
                    }
                }
                if (victoryOnColumn)
                {
                    return true;
                }
            }

            bool victoryOnDiagonalLR = true;
            for (int r = 0; r < BoardState.GetLength(0); r++)
            {
                if (BoardState[r, r] != playerMarker)
                {
                    victoryOnDiagonalLR = false;
                }
            }
            if (victoryOnDiagonalLR)
            {
                return true;
            }

            bool victoryOnDiagonalRL = true;
            for (int r = BoardState.GetLength(0)-1; r >= 0; r--)
            {
                if (BoardState[r, BoardState.GetLength(0)-r-1] != playerMarker)
                {
                    victoryOnDiagonalRL = false;
                }
            }
            if (victoryOnDiagonalRL)
            {
                return true;
            }

            return false;
        }
    }

    internal enum BoardSpaceState
    {
        None, Player1, Player2
    }
}
