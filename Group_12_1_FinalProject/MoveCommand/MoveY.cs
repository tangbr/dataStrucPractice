/*
 * @author: Group 12-1
 * @description: This module contains the class definition for a command to move in the y direction
 */
using Group_12_1_FinalProject.ChessPieces;

namespace Group_12_1_FinalProject.MoveCommand
{
    /*
     * This command moves the specified piece
     * along the y axis by "magnitude" units
     */
    public class MoveY : MoveCommand
    {
        
        // this is the number of tiles the piece will move
        private int _magnitude;

        /*
         * The constructor allows the piece and the magnitude to be set
         */
        public MoveY(ChessPiece piece, int magnitude) : base(piece)
        {
            // the piece is saved by the base constructor
            // save the magnitude to this instance
            _magnitude = magnitude;
        }

        /*
         * When the command is executed, it will force the piece to move along the y axis
         */
        public override void Execute()
        {
            // execute the move of the piece
            _piece.ExecuteMove(0, _magnitude);
        }
    }
}