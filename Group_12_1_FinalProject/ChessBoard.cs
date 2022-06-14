/*
 * @author: Group 12-1
 * @description: This module contains the class definition for the singleton
 * which represents the chess board
 * It is responsible for managing each of the players, and the pieces owned by the player
 */
using System;
using System.Collections.Generic;

namespace Group_12_1_FinalProject
{
    /*
     * The chess board class is the central class in the system
     * It is also a singleton so reference distribution is very easy
     */
    public sealed class ChessBoard
    {
        // save the instance of this class and the thread lock
        // this makes this singleton instance thread safe
        private static ChessBoard _instance;
        private static object _lockThis = new object();
        
        //array of Player objects
        private  Player[] _players;
        
        //flag for tracking which player's turn it is
        private bool _p1turn = true;

        // this is the queue where move commands will be stored
        // until they are ready to be executed
        private Queue<MoveCommand.MoveCommand> _commandQueue = new Queue<MoveCommand.MoveCommand>();
        
        /*
        * The constructor. WARNING: DO NOT CALL THIS DIRECTLY!
        */
        public ChessBoard()
        {
        }

        /*
        * Property to return array of Players
       */
        public Player[] Players { get { return _players; } }

        /*
         * This method either instantiates the chess board if it has not already been instantiated
         * and returns the reference to the object
         *
         * WARNING: CALL THIS METHOD INSTEAD OF THE CONSTRUCTOR
         */
        public static ChessBoard GetChessBoard()
        {
            // thread lock with the thread lock object to ensure thread memory safety
            lock (_lockThis)
            {
                // if this class has not yet been instantiated, create an instance of it
                // and save the reference
                if (_instance == null) { 
                    _instance = new ChessBoard();
                    _instance.SetUpChessBoard();
                }
            }

            // return the reference to this class
            return _instance;
        }
        
        /*
         * This method executes the setup of the chessboard
         */
        public void SetUpChessBoard() {
            _players = new Player[2];
            _players[0] = new Player(1);
            _players[1] = new Player(2);
        } 

        /*
         * This method enqueues the provided command to the central command queue
         */
        public void EnqueueMove(MoveCommand.MoveCommand command)
        {
            // enqueue the specified command
            _commandQueue.Enqueue(command);
        }

        /*
         * This method will dequeue and execute all of the commands in the command queue
         */
        public void ExecuteMoves()
        {
            // while there are more than one command in the queue
            while (_commandQueue.Count > 1)
                //dequeue commands and execute the moves
                _commandQueue.Dequeue().Execute();
            // executes the last move
            _commandQueue.Peek().Execute();
            // calls the Delete method for the Player whose turn it is and dequeues the command
            GetTurn().Delete(_commandQueue.Dequeue().Piece);
            // gives turn to the other Player
            Turn();
        }
        // Method that records player has taken a turn and shifts control to the other player
        public void Turn()
        {
            // flips the flag to indicate it's the other player's turn
            if (_p1turn)
                _p1turn = false;
            else
                _p1turn = true;

        }
        // Method that returns a reference to the Player that has the turn
        public Player GetTurn()
        {
            // if it's Player's 1 turn, return reference to Player 1
            if (_p1turn)
                return _players[0];

            // else return a reference to Player 2
            else
                return _players[1];

        }
        // Method that returns a reference to the Player that does not have the turn
        public Player GetOpponent()
        {
            // if it's Player's 1 turn, return reference to Player 2
            if (_p1turn)
                return _players[1];

            // else return a reference to Player 1
            else
                return _players[0];
        }
    }
}