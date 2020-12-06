using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame ticTacToe = new TicTacToeGame();
            char[] board = ticTacToe.CreateTicTacToeBoard();
            char userChoice = ticTacToe.ChooseUserChoice();
        }
    }
}
