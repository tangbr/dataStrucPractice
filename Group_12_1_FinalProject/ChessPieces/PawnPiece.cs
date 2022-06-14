/*
 * @author: Group 12-1
 * @description: This module contains the class definition for the Pawn piece
 */
using System;
using System.Linq;

namespace Group_12_1_FinalProject.ChessPieces
{
    public class PawnPiece : ChessPiece
    {
        /*
         * The PawnPiece represents a Pawn chess piece
         * The pawn is permitted to move exactly one space forwards
         * If it is the first time being moved, the pawn may move two spaces
         * Finally, the pawn may move diagonally to capture an opponent's piece
         *
         * This is done by ensuring dx is 0, and dy is 1
         * unless the pawn has never been moved
         * In that case, dy may be either 1 or 2
        */
        public override bool IsLegalMove(int dx, int dy)
        {
            // if dx is 0, indicate the move is illegal
            // this will be done until the diagonal detection can be implemented
            if (dx == 0) return Math.Abs(dy) == 1 || (Math.Abs(dy) == 2 && !_hasMadeFirstMove);
            if (Math.Abs(dy) != 1 || Math.Abs(dx) != 1) return false;
            return _board.GetOpponent().ChessPieces.Cast<ChessPiece>().Any(chessPiece => chessPiece.GetPosition()[0] == GetPosition()[0] + dx && chessPiece.GetPosition()[1] == GetPosition()[1] + dy);


            // return if dy is 1 or if it is both 2 and this piece has never been moved
        }

        /*
         * This method returns the lowercase character this object
         * will be drawn as when the board is written to the console
         */
        public override char GetDisplayLetter()
        {
            return 'p';
        }

        /*
         * Overloaded constructor
         */
        public PawnPiece(int x, int y) : base(x, y)
        {
            
        }
    }
}