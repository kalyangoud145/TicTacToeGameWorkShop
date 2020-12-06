using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToeGame
    {
        /// <summary>
        /// Creates the tic tac toe board.
        /// </summary>
        /// <returns></returns>
        public char[] CreateTicTacToeBoard()
        {
            char[] board = new char[10];
            for (int i = 1; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        /// <summary>
        /// Chooses the user choice.
        /// </summary>
        /// <returns></returns>
        public char ChooseUserChoice()
        {
            Console.WriteLine("Choose your letter: ");
            string userChoice = Console.ReadLine();
            return char.ToUpper(userChoice[0]);
        }
        /// <summary>
        /// Display the  current board.
        /// </summary>
        /// <param name="board">The board.</param>
        public void ShowBoard(char[] board)
        {
            Console.WriteLine(board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("----------");
            Console.WriteLine(board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("----------");
            Console.WriteLine(board[7] + " | " + board[8] + " | " + board[9]);
            Console.WriteLine("----------");
        }
    }
}
