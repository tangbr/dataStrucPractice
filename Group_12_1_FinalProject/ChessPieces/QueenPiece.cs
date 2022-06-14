/*
 * @author: Group 12-1
 * @description: This module contains the class definition for the Queen piece
 */
using System;

namespace Group_12_1_FinalProject.ChessPieces
{
    /*
     * The QueenPiece represents a Queen chess piece
     * The queen is permitted to move any number of spaces
     * either diagonally, or orthogonally
    */
    public class QueenPiece : ChessPiece
    {
        /*
         * This method determines if dx and dy create a vector
         * which is either diagonal or orthogonal
         *
         * This is done by taking the magnitude of the x and y deltas
         * and ensuring either dx = dy (diagonal)
         * OR dx is 0 and dy is non zero
         * OR dx is non zero and dy is 0
         */
        public override bool IsLegalMove(int dx, int dy)
        {
            // take the magnitude of the deltas
            dx = Math.Abs(dx);
            dy = Math.Abs(dy);

            // determine if the move is either diagonal or orthogonal 
            return (dx == dy) || (dx == 0 && dy != 0) || (dx != 0 && dy == 0);
        }

        /*
         * This method returns the lowercase character this object
         * will be drawn as when the board is written to the console
         */
        public override char GetDisplayLetter()
        {
            return 'q';
        }

        /*
         * Overloaded constructor
         */
        public QueenPiece(int x, int y) : base(x, y)
        {
            
        }
    }
}