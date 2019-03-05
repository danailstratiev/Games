using System;
using System.Linq;
using System.Collections.Generic;


namespace My_TicTacToe_Version_1._0
{
    class GamePlay
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In order to start the game you must choose position from 1 to 9 like shown below!");

            var demo = new char[3][];
            FillDemo(demo);
            PrintBoard(demo);

            var board = new char[3][];

            FillBoard(board);

            Console.WriteLine();
            Console.WriteLine("Get ready !");
            PrintBoard(board);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("PlayerX, choose free position!");

                var playerX = int.Parse(Console.ReadLine());
                PlayerXMoves(board, playerX);
                PrintBoard(board);
                CheckForWinner(board);
                CheckForDraw(board);

                Console.WriteLine();
                Console.WriteLine("PlayerO, choose free position!");

                var playerO = int.Parse(Console.ReadLine());
                PlayerOMoves(board, playerO);
                PrintBoard(board);

                CheckForWinner(board);
                CheckForDraw(board);
            }
        }

        private static void FillDemo(char[][] demo)
        {
            var counter = '0';

            for (int i = 0; i < demo.Length; i++)
            {
                demo[i] = new char[3];

                for (int j = 0; j < demo[i].Length; j++)
                {
                    counter++;

                    demo[i][j] = counter;
                }
            }
        }

        private static void CheckForDraw(char[][] board)
        {
            var counter = 0;

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == ' ')
                    {
                        counter++;
                    }
                }
            }

            if (counter == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Game over!");
                Console.WriteLine("There is no winner!");
                Environment.Exit(0);
            }
        }

        private static void CheckForWinner(char[][] board)
        {
            CheckRows(board);
            CheckCols(board);
            CheckDiagonals(board);
        }

        private static void CheckDiagonals(char[][] board)
        {
            CheckFirstDiagonal(board);
            CheckSecondDiagonal(board);
        }

        private static void CheckSecondDiagonal(char[][] board)
        {
            var counterX = 0;
            var counterO = 0;
            var j = 2;

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][j] == 'x')
                {
                    counterX++;
                }
                else if (board[i][j] == 'o')
                {
                    counterO++;
                }

                j--;
            }

            if (counterX == 3)
            {
                VictoryForPlayerX();
            }
            else if (counterO == 3)
            {
                VictoryForPlayerO();
            }
        }

        private static void CheckFirstDiagonal(char[][] board)
        {
            var counterX = 0;
            var counterO = 0;
            var j = 0;

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][j] == 'x')
                {
                    counterX++;
                }
                else if (board[i][j] == 'o')
                {
                    counterO++;
                }

                j++;
            }

            if (counterX == 3)
            {
                VictoryForPlayerX();
            }
            else if (counterO == 3)
            {
                VictoryForPlayerO();
            }
        }

        private static void CheckCols(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                var counterX = 0;
                var counterO = 0;

                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[j][i] == 'x')
                    {
                        counterX++;
                    }
                    else if (board[j][i] == 'o')
                    {
                        counterO++;
                    }
                }

                if (counterX == 3)
                {
                    VictoryForPlayerX();
                }
                else if (counterO == 3)
                {
                    VictoryForPlayerO();
                }
            }
        }

        private static void CheckRows(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                var currentRow = string.Join("", board[i]);

                if (currentRow == "xxx")
                {
                    VictoryForPlayerX();
                }
                else if (currentRow == "ooo")
                {
                    VictoryForPlayerO();
                }
            }
        }

        private static void VictoryForPlayerO()
        {
            Console.WriteLine();
            Console.WriteLine("Game over!");
            Console.WriteLine("PlayerO is winner!");
            Environment.Exit(0);
        }

        private static void VictoryForPlayerX()
        {
            Console.WriteLine();
            Console.WriteLine("Game over!");
            Console.WriteLine("PlayerX is winner!");
            Environment.Exit(0);
        }

        private static void PlayerOMoves(char[][] board, int playerO)
        {
            playerO = ValidatePosition(playerO);

            bool isFree = false;

            while (isFree == false)
            {
                var counter = 0;

                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        counter++;

                        if (counter == playerO)
                        {
                            if (board[i][j] == ' ')
                            {
                                board[i][j] = 'o';
                                isFree = true;
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Choose free position");
                                playerO = int.Parse(Console.ReadLine());
                                playerO = ValidatePosition(playerO);
                            }
                        }
                    }
                }
            }            
        }

        private static int ValidatePosition(int playerPosition)
        {
            if (playerPosition > 9 || playerPosition < 1)
            {
                while (playerPosition > 9 || playerPosition < 1)
                {
                    Console.WriteLine("The position must be from 1 to 9");
                    playerPosition = int.Parse(Console.ReadLine());
                }
            }

            return playerPosition;
        }

        private static void PlayerXMoves(char[][] board, int playerX)
        {
            playerX = ValidatePosition(playerX);
            
            bool isFree = false;

            while (isFree == false)
            {
                var counter = 0;

                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        counter++;

                        if (counter == playerX)
                        {
                            if (board[i][j] == ' ')
                            {
                                board[i][j] = 'x';
                                isFree = true;
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Choose free position");
                                playerX = int.Parse(Console.ReadLine());
                                playerX = ValidatePosition(playerX);                                
                            }
                        }
                    }
                }
            }
        }

        private static void FillBoard(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new char[3];

                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j] = ' ';
                }
            }
        }

        private static void PrintBoard(char[][] board)
        {
            var drawLine = new string('-', 9);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{board[i][0]} | {board[i][1]} | {board[i][2]}");
                if (i < 2)
                {
                    Console.WriteLine(drawLine);
                }
            }
        }
    }
}
