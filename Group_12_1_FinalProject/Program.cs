/*
 * @author: Group 12-1
 * @description: This module contains the driver code which runs the project
 */
using Group_12_1_FinalProject.ChessPieces;
using Group_12_1_FinalProject.TestCases;
using Group_12_1_FinalProject.MoveCommand;

using System;
using System.Data;
using System.Reflection;
using System.Security;

namespace Group_12_1_FinalProject
{
    public class Program
    {
        /*
         * This is the driver method which runs the game of chess
         */
        public static void Main(string[] args)
        {
            // instantiate the chess board
            // because it is a singleton, this will cause all the setup to occur
            ChessBoard chessBoard = ChessBoard.GetChessBoard();

            // loop endlessly while there exist pieces on the board         
            while (chessBoard.GetTurn().ChessPieces.Count > 0 && chessBoard.GetOpponent().ChessPieces.Count > 0)
            {    
                // print the ChessBoard
                PrintBoard(chessBoard);
                
                // an endless loop which is broken when the user enters a valid command
                while (true)
                {
                    try
                    {
                        // play a turn and break out of the loop
                        GamePlay(chessBoard);
                        break;
                    }
                    catch (InvalidOperationException e)
                    {
                        // if an invalid move is attempted, print the message and ask for the info again
                        Console.WriteLine(e.Message);
                    }
                    catch (FormatException)
                    {
                        // if the user entered a non-numeric input, inform them their input is invalid
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                }
                
                // clear the console before redrawing for the next turn
                Console.Clear();
            }
        }

        /*
         * This method prints the provided chess board to the console
         */
        public static void PrintBoard(ChessBoard board)
        {
            // create an empty character array for each piece to be displayed to the console 
            char[,] emptyBoard = new char[8, 8];

            // set each item in the character array to a spcae
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    emptyBoard[i, j] = ' ';

            // iterate over each cell in the board
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    // create an int array representing the current location on the grid
                    int[] grid = { i+1, j+1 };
                    
                    // iterate over each player in the board
                    for (int k = 0; k < 2; k++)
                    {
                        // iterate though the ArrayList of ChessPieces associated to Player object
                        for (int l = 0; l < board.Players[k].ChessPieces.Count; l++)
                        {
                            // instantiate ChessPiece object to store current object being analyzed
                            ChessPiece current = (ChessPiece)board.Players[k].ChessPieces[l];
                            
                            // compare current coordinates to the loaction of the current ChessPiece object
                            if (grid[0]== current.GetPosition()[0]&& grid[1] == current.GetPosition()[1])
                            {
                                // if a match, print the piece's display letter  
                                emptyBoard[i, j] = current.GetDisplayLetter();
                                
                                // if the matched piece is owned by the player whose turn it is
                                // convert the character to capital
                                if (board.Players[k] == board.GetTurn())
                                    emptyBoard[i, j] = char.ToUpper(emptyBoard[i, j]);
                            }
                        }
                    }
                }   
            
            // draw the first line of the board with the x coordinates
            // delimited by a space to represent an ASCII table
            // Extended ASCII characters are used to create the table
            Console.Write(" ");
            for (int j = 0; j < 8; j++)
            {
                Console.Write(" " + (j + 1));
            }
            
            // terminate the line
            Console.WriteLine();
            
            // iterate over each row in the table
            for (int i = 0; i < 8; i++)
            {
                // write the row delimiter and the row number
                Console.WriteLine(" ┼─┼─┼─┼─┼─┼─┼─┼─┼");
                Console.Write(i + 1);
                
                // iterate over each column in the grid
                for (int j = 0; j < 8; j++)
                {
                    // for each column in the row, print the col delimiter
                    // and the character at that column
                    Console.Write("│");
                    Console.Write(emptyBoard[j, i]);
                }
                
                // write the final row delimiter and the row index
                Console.Write("│");
                Console.Write(i + 1);

                // terminate the line
                Console.WriteLine();
            }
            
            // draw the last line of the table
            Console.WriteLine(" ┼─┼─┼─┼─┼─┼─┼─┼─┼");
            
            // re-draw the column indices
            Console.Write(" ");
            for (int j = 0; j < 8; j++)
            {
                Console.Write(" " + (j + 1));
            }
            
            // terminate the line
            Console.WriteLine();
        }

        /*
         * This method facilitates the user input for the game given a chess board
         */
        public static void GamePlay(ChessBoard board)
        {
            // temporary vars to store the selected chess piece
            ChessPiece temp, current;
            
            // ask the user for the x position of the piece to move
            Console.WriteLine("Please enter the row of the piece you would like to play");
            int x1 = Convert.ToInt32(Console.ReadLine());
            
            // ask the user for the y position of the piece to move
            Console.WriteLine("Please enter the Column of the piece you would like to play");
            int y1 = Convert.ToInt32(Console.ReadLine());
            
            // convert the position to an integer array
            int[] pos = { x1, y1 };
            
            // get the first chess piece of the selected player
            temp = (ChessPiece)board.GetTurn().ChessPieces[0];
            
            // a variable to check if the requested piece can be located
            bool found = false;

            for (int i = 0; i < board.GetTurn().ChessPieces.Count; i++)
            {
                // instantiate ChessPiece object to store object being analyzed
                temp = (ChessPiece)board.GetTurn().ChessPieces[i];
                
                // compare current coordinates to the loaction of the current ChessPiece object
                if (pos[0] == temp.GetPosition()[0] && pos[1] == temp.GetPosition()[1])
                {
                    // indicate the requested piece has been located
                    found = true;
                    
                    // piece that will be moved
                    break;
                }
            }

            // if the requested piece could not be located, raise a TargetException
            if (!found)
            {
                throw new InvalidOperationException("The requested piece at (" + pos[0] + ", " + pos[1] + ") could not be found");
            }
            
            // save the found piece as "current"
            current = temp;
            
            // ask the user for the x position of the move destination
            Console.WriteLine("Please enter the row of the piece you would like to move");
            int x2 = Convert.ToInt32(Console.ReadLine());
            
            // ask the user for the y position of the move destination
            Console.WriteLine("Please enter the column of the piece you would like to move");
            int y2 = Convert.ToInt32(Console.ReadLine());

            // check if any of the inputs are out of bounds
            if (x2 < 1 || x2 > 8 || y2 < 1 || y2 > 8)
            {
                // if it is, raise an exception informing the user the destination is invalid
                // this causes the player to be prompted again
                throw new InvalidOperationException("The requested destination is outside of the board");
            }

            // iterate over each of the player's pieces to check
            // if the movement will cause 2 of the same players pieces to overlap
            foreach (ChessPiece chessPiece in board.GetTurn().ChessPieces)
            {
                // check if they share coordinates 
                if (chessPiece.GetPosition()[0] == x2 && chessPiece.GetPosition()[1] == y2)
                {
                    // if they do, raise an exception informing the user the destination is invalid
                    // this causes the player to be prompted again
                    throw new InvalidOperationException("The requested location (" + x2 + ", " + y2 +") is occupied by your own piece");
                }
            }

            // if all the validations pass, execute the move
            current.Move(x2 - x1, y2 - y1);
        }
    }
}
