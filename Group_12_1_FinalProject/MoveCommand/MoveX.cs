/*
 * @author: Group 12-1
 * @description: This module contains the class definition for a command to move in the x direction
 */
using Group_12_1_FinalProject.ChessPieces;

namespace Group_12_1_FinalProject.MoveCommand
{
    /*
     * This command moves the specified piece
     * along the x axis by "magnitude" units
     */
    public class MoveX : MoveCommand
    {
        
        // this is the number of tiles the piece will move
        private int _magnitude;

        /*
         * The constructor allows the piece and the magnitude to be set
         */
        public MoveX(ChessPiece piece, int magnitude):base(piece)
        {
            // the piece is saved by the base constructor
            // save the magnitude to this instance
            _magnitude = magnitude;
        }

        /*
         * When the command is executed, it will force the piece to move along the x axis
         */
        public override void Execute()
        {
            // execute the move of the piece
            _piece.ExecuteMove(_magnitude, 0);
        }
    }
}