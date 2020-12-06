﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    class TicTacToeGame
    {
        public char player;
        public char computer;
        public string currentPlayer;
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
        /// <summary>
        /// Gets the user desired move.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns></returns>
        public int GetUserDesiredMove(char[] board)
        {
            int[] validCells = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            while (true)
            {
                Console.WriteLine("What is your desired next move?");
                int index = Convert.ToInt32(Console.ReadLine());
                if ((index >= 1 && index <= 9) && IsSpaceFree(board, index))
                {
                    return index;
                }
                else
                {
                    Console.WriteLine("Invalid entry please check the input and try again.");
                }
            }
        }
        /// <summary>
        /// Determines whether space is free in the specific position of board
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="index">The index.</param>
        /// <returns>
        ///   <c>true</c> if [is space free] [the specified board]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSpaceFree(char[] board, int index)
        {
            return board[index] == ' ';
        }
        /// <summary>
        /// Checks if desired cell is free then make a move to place the letter.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="index">The index.</param>
        /// <param name="letter">The letter.</param>
        public static void MakeMove(char[] board, int index, char letter)
        {
            bool isSpaceFree = IsSpaceFree(board, index);
            if (isSpaceFree) board[index] = letter;
        }
        /// <summary>
        /// Gets the who starts first.
        /// </summary>
        /// <returns></returns>
        public static string GetWhoStartsFirst()
        {
            Random random = new Random();
            int choice = random.Next(0, 2);
            Console.WriteLine(choice);
            return (choice == 0) ? "player" : "computer";
        }
        /// <summary>
        /// Gets the game status.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="symbol">The symbol.</param>
        public void GameStatus(char[] board, char symbol)
        {
            if (!this.IsWinner(board, symbol))
            {
                if (IsTie(board))
                {
                    Console.WriteLine("Game is tied");
                }
                else
                {
                    this.currentPlayer = (this.currentPlayer == "player") ? "computer" : "player";
                }
            }
            else
            {
                Console.WriteLine(this.currentPlayer + " is the winner");
            }
        }
        /// <summary>
        /// Determines whether the specified board is winner according to rules
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="symbol">The symbol.</param>
        /// <returns>
        ///   <c>true</c> if the specified board is winner; otherwise, <c>false</c>.
        /// </returns>
        public bool IsWinner(char[] board, char symbol)
        {
            return (board[1] == symbol && board[2] == symbol && board[3] == symbol) ||
                (board[4] == symbol && board[5] == symbol && board[6] == symbol) ||
                (board[7] == symbol && board[8] == symbol && board[9] == symbol) ||
                (board[1] == symbol && board[4] == symbol && board[7] == symbol) ||
                (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||
                (board[3] == symbol && board[6] == symbol && board[9] == symbol) ||
                (board[1] == symbol && board[5] == symbol && board[9] == symbol) ||
                (board[3] == symbol && board[5] == symbol && board[7] == symbol);
        }
        /// <summary>
        /// Determines whether the specified board is tie.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns>
        ///   <c>true</c> if the specified board is tie; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTie(char[] board)
        {
            bool tie = true;
            for (int index = 1; index < 10; index++)
            {
                if (board[index] == ' ')
                {
                    tie = false;
                    break;
                }
            }
            return tie;
        }
        /// <summary>
        /// Computer move by checking the winning position
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns></returns>
        public int ComputerMove(char[] board)
        {
            int winningMove = this.GetWinningMove(board);
            if (winningMove != 0) return winningMove;
            return 0;
        }
        /// <summary>
        /// Gets the winning move.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns></returns>
        public int GetWinningMove(char[] board)
        {
            for (int index = 1; index < 10; index++)
            {
                char[] boardCopy = new char[10];
                if (IsSpaceFree(boardCopy, index))
                {
                    boardCopy[index] = this.player;
                    if (IsWinner(boardCopy, this.computer))
                    {
                        return index;
                    }
                }
            }
            this.GameStatus(board, this.computer);
            return 0;
        }
    }
}
