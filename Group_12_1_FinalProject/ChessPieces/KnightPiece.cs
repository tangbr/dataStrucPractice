/*
 * @author: Group 12-1
 * @description: This module contains the class definition for the Knight piece
 */
using System;

namespace Group_12_1_FinalProject.ChessPieces
{
    public class KnightPiece : ChessPiece
    {
        /*
         * The KnightPiece represents a Knight chess piece
         * The knight is permitted to move exactly 3 spaces in one direction
         * and 1 space in the other direction to create an "L" shape
         *
         * This is done by checking if the magnitude of the x direction is 3 and y is 1
         * OR if x is 1 and y is 3
        */
        public override bool IsLegalMove(int dx, int dy)
        {
            // take the magnitude of the x and y deltas
            dx = Math.Abs(dx);
            dy = Math.Abs(dy);
            
            // execute the check and return the result
            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }

        /*
         * This method returns the lowercase character this object
         * will be drawn as when the board is written to the console
         *
         * Note that an "n" is used for the knight to avoid ambiguity with the king
         */
        public override char GetDisplayLetter()
        {
            return 'n';
        }

        /*
         * Overloaded constructor
         */
        public KnightPiece(int x, int y) : base(x, y)
        {
            
        }
    }
}