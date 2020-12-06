﻿using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame ticTacToe = new TicTacToeGame();
            char[] board = ticTacToe.CreateTicTacToeBoard();
            char userChoice = ticTacToe.ChooseUserChoice();
            ticTacToe.ShowBoard(board);
            ticTacToe.GetUserDesiredMove(board);
            TicTacToeGame.MakeMove(board, 6, userChoice);
            ticTacToe.GameStatus(board, userChoice);
        }
    }
}
