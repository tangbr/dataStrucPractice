/*
 * @author: Group 12-1
 * @description: This module contains the class definition for the Player class
 */
using System;
using System.Collections;


using Group_12_1_FinalProject.ChessPieces;

namespace Group_12_1_FinalProject
{
    public class Player
    {
        private string _colour;
        private ArrayList _chessPieces;

        /*
         * This lambda returns the color of the player as a string
         */
        public string Colour => _colour;

        //Player constructor takes the position of the player (first or second) and initializes the object and its playing pieces 
        public Player(int position)
        {

            // allocate memory for 16 ChessPiece objects
            _chessPieces = new ArrayList(16);
            // initialize ChessPieces for first player
            if (position == 1)
            {
                // 1st Player uses white playing pieces
                _colour = "White";
                // initialize 8 PawnPiece objects
                for (int i = 0; i < 8; i++)
                {
                    //position pawns along the 2nd row 
                    _chessPieces.Add(new PawnPiece(i + 1, 2)); 
                }
                //initialize and postion RookPiece objects
                _chessPieces.Add( new RookPiece(1, 1));
                
                //initialize and position KnightPiece objects
                _chessPieces.Add(new KnightPiece(2, 1));
                
                //initialize and position BishopPiece objects
                _chessPieces.Add(new BishopPiece(6, 1));
                
                //initialize and position QueenPiece object
                _chessPieces.Add(new QueenPiece(4, 1));
                //initialize and position KingPiece object
                _chessPieces.Add(new KingPiece(5, 1));
                _chessPieces.Add(new BishopPiece(3, 1));
                _chessPieces.Add(new KnightPiece(7, 1));
                _chessPieces.Add( new RookPiece(8, 1));

            }
            //initialize ChessPieces for 2nd player
            else
            {
                // 2nd Player uses black playing pieces
                _colour = "Black";
                // initialize 8 PawnPiece objects
                for (int i = 8; i > 0; i--)
                {
                    //position pawns along the 7th row 
                    _chessPieces.Add(new PawnPiece(i,7));
                }
                //initialize and postion RookPiece objects
                _chessPieces.Add(new RookPiece(8, 8));
               
                //initialize and position KnightPiece objects
                _chessPieces.Add(new KnightPiece(7, 8));
               
                //initialize and position BishopPiece objects
                _chessPieces.Add(new BishopPiece(6, 8));
              
                //initialize and position QueenPiece object
                _chessPieces.Add(new QueenPiece(5, 8));
                //initialize and position KingPiece object
                _chessPieces.Add(new KingPiece(4, 8));
                _chessPieces.Add(new BishopPiece(3, 8));
                _chessPieces.Add(new KnightPiece(2, 8));
                _chessPieces.Add(new RookPiece(1,8));

            }
        }
        /* 
        * Property to return ArrayList of ChessPieces
        */
        public ArrayList ChessPieces { get { return _chessPieces; } }

        // Method deletes a ChessPiece from an ArrayList if it has been taken out of play by an opponent
        public void Delete(ChessPiece chessPiece)
        {
            // iterates through the other player's chess pieces 
            for (int i = 0; i < ChessBoard.GetChessBoard().GetOpponent()._chessPieces.Count; i++) {

                //checks if the postion of any of their pieces matches the destination of the piece being moved
                int[] position = ((ChessPiece) ChessBoard.GetChessBoard().GetOpponent()._chessPieces[i]).GetPosition();
                if (chessPiece.GetPosition()[0] == position[0] && chessPiece.GetPosition()[1] == position[1]) {

                    // removes a ChessPiece from play if it is located at the destination of an opponent's piece
                    ChessBoard.GetChessBoard().GetOpponent()._chessPieces.RemoveAt(i);
                    // ends if there is a match
                    i = ChessBoard.GetChessBoard().GetOpponent()._chessPieces.Count;
                }
            }
        }
    }
}
