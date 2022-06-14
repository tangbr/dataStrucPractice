/*
 * @author: Group 12-1
 * @description: This module contains the class definition for the Bishop piece
 */
using System;

namespace Group_12_1_FinalProject.ChessPieces
{
    /*
     * The BishopPiece represents a Bishop chess piece
     * The bishop is permitted to move diagonally 
    */
    public class BishopPiece : ChessPiece
    {
        /*
         * This method determines if dx and dy create a diagonal vector
         * This can be done by ensuring the magnitude of dx is the same as the magnitude of dy
         * forcing diagonal movement
         */
        public override bool IsLegalMove(int dx, int dy)
        {
            // return if the magnitude of dx is the same as the magnitude of dy
            return Math.Abs(dx) == Math.Abs(dy);
        }

        /*
         * This method returns the lowercase character this object
         * will be drawn as when the board is written to the console
         */
        public override char GetDisplayLetter()
        {
            return 'b';
        }
        
        /*
         * Overloaded constructor
         */
        public BishopPiece(int x, int y) : base(x, y)
        {
            
        }
    }
}