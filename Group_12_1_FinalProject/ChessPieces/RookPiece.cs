/*
 * @author: Group 12-1
 * @description: This module contains the class definition for the Rook piece
 */
namespace Group_12_1_FinalProject.ChessPieces
{
    /*
     * The RookPiece represents a Rook chess piece
     * The rook is permitted to move orthogonally 
     */
    public class RookPiece : ChessPiece
    {
        /*
         * This method determines if dx and dy create an orthogonal vector
         * This can be done by ensuring either dx or dy is zero
         * forcing orthogonal movement
         */
        public override bool IsLegalMove(int dx, int dy)
        {
            // return if either dx or dy is non-zero, but not both
            return (dx == 0 && dy != 0) || (dx != 0 && dy == 0);
        }

        /*
         * This method returns the lowercase character this object
         * will be drawn as when the board is written to the console
         */
        public override char GetDisplayLetter()
        {
            return 'r';
        }

        /*
         * Overloaded constructor
         */
        public RookPiece(int x, int y) : base(x, y)
        {
            
        }
    }
}