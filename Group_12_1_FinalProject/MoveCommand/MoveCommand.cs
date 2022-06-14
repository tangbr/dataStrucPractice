/*
 * @author: Group 12-1
 * @description: This module contains the base MoveCommand class which all movement commands extend
 */
using Group_12_1_FinalProject.ChessPieces;

namespace Group_12_1_FinalProject.MoveCommand
{
    /*
     * This class is the parent class for all movement commands
     */
    public abstract class MoveCommand
    {
        // this is the piece that will be moved
        internal ChessPiece _piece;

        //constructor
        internal MoveCommand(ChessPiece piece) { _piece = piece; }

        //Property to return the piece being moved
        public ChessPiece Piece { get { return _piece; } }

        /*
         * This is the abstract method which all commands must implement
         * This method is run when the command is executed
         */
        public abstract void Execute();
    }
}