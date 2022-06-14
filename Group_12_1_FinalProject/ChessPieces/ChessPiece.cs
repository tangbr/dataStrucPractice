/*
 * @author: Group 12-1
 * @description: This module contains the class definition for the parent class of all chess pieces
 */
using System;
using Group_12_1_FinalProject.MoveCommand;

namespace Group_12_1_FinalProject.ChessPieces
{
    /*
     * This is the class which all chess pieces extend
     */
    public abstract class ChessPiece
    {
        // this tracks if the piece has ever been successfully moved
        // this is used to determine if the pawn is permitted to move 
        // the additional space on its first move
        internal bool _hasMadeFirstMove = false;
        
        // create an instance of the chess board
        // the chess board is a Singleton so all pieces will reference the same object
        // this makes distributing the chess board reference very clean and easy
        internal ChessBoard _board = ChessBoard.GetChessBoard();
        
        // these two variables store the x and y position of the piece on the board
        internal int _x;
        internal int _y;

        /*
         * The constructor takes the x and y position the piece should start at
         */
        protected ChessPiece(int x, int y)
        {
            // save the x and y values passed in to the object's x and y position
            _x = x;
            _y = y;
        }

        /*
         * This abstract method is used to determine if a proposed move is legal
         * If the move is illegal, an InvalidOperationException will be thrown
         */
        public abstract bool IsLegalMove(int dx, int dy);

        /*
         * This abstract method returns the lowercase character this object
         * will be drawn as when the board is written to the console
         */
        public abstract char GetDisplayLetter();

        /*
         * This method returns the x and y position of this object as an integer array
         */
        public int[] GetPosition()
        {
            return new[] {_x, _y};
        }
        
        /*
         * This lambda returns the current x position of the piece
         * This allows for information hiding so no external objects
         * may directly modify the position of the piece
         */
        public int X => _x;

        /*
         * This lambda returns the current x position of the piece
         * This allows for information hiding so no external objects
         * may directly modify the position of the piece
         */
        public int Y => _y;

        /*
         * This method queues the move commands in the board,
         * if the requested move is legal
         *
         * If the request move is illegal an InvalidOperationException will be thrown
         */
        public void Move(int dx, int dy)
        {
            // check if the change in position is a legal move
            if (IsLegalMove(dx, dy))
            {
                // if there is change in the x direction, enqueue the x direction movement
                if (dx != 0)
                    _board.EnqueueMove(new MoveX(this, dx));
                    
                // if there is change in the y direction, enqueue the y direction movement
                if (dy != 0)
                    _board.EnqueueMove(new MoveY(this, dy));
                
                // dequeue and execute all of the moves in the ChessBoard class' queue
                _board.ExecuteMoves();
                    
                // update the _hasMadeFirstMove attribute to indicate this piece has made at least one move 
                _hasMadeFirstMove = true;
            }
            else
            {
                // if the move was not legal, throw an InvalidOperationException
                throw new InvalidOperationException($"The piece {this} is unable to move ({dx}, {dy})");
            }
        }

        /*
         * This overloaded Move method allows the piece to me moved only along the y axis
         * simplifying the API further
         */
        public void Move(int dy)
        {
            // call the other Move method, using 0 for the change in the x direction
            Move(0, dy);
        }

        /*
         * This method is only to be called by a MoveCommand
         * It executes the movement without any checks or validations
         */
        public void ExecuteMove(int dx, int dy)
        {
            // increment the x and y position by the provided deltas
            _x += dx;
            _y += dy;
        }
    }
}