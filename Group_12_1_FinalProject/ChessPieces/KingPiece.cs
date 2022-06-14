/*
 * @author: Group 12-1
 * @description: This module contains the class definition for the King piece
 */
using System;

namespace Group_12_1_FinalProject.ChessPieces
{
    /*
     * The KingPiece represents a King chess piece
     * The king is permitted to move exactly one space in any direction
    */
    public class KingPiece : ChessPiece
    {
        /*
         * This method determines if dx and dy create a vector within 1 square of the king
         * This can be done by ensuring the magnitude of dx and dy are 1 or 0
         */
        public override bool IsLegalMove(int dx, int dy)
        {
            // ensure the magnitude of dx and dy are 1 or 0
            return (Math.Abs(dx) <= 1) && (Math.Abs(dy) <= 1);
        }
        
        /*
         * This method returns the lowercase character this object
         * will be drawn as when the board is written to the console
         */
        public override char GetDisplayLetter()
        {
            return 'k';
        }

        /*
         * Overloaded constructor
         */
        public KingPiece(int x, int y) : base(x, y)
        {
            
        }
    }
}