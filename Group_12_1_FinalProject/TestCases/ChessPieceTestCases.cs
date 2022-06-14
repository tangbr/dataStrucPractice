/*
 * @author: Group 12-1
 * @description: This module contains the test cases for the movement of each chess piece
 */
using System;
using System.Data;
using Group_12_1_FinalProject.ChessPieces;

namespace Group_12_1_FinalProject.TestCases
{
    public static class ChessPieceTestCases
    {
        private static int[] _startPos = {4, 4};
        
        /*
         * This test case tests the movement of the Bishop piece
         */
        public static void TestBishop()
        {
            // instantiate the piece
            BishopPiece bishopPiece = new BishopPiece(_startPos[0], _startPos[1]);
            
            // execute legal movements
            bishopPiece.Move(1, 1);
            bishopPiece.Move(1, -1);
            bishopPiece.Move(-1, 1);
            bishopPiece.Move(-1, -1);
            
            try
            {
                // attempt an illegal movement and ensure it raises an InvalidOperationException
                bishopPiece.Move(1, 2);
                
                // if no exception is raised, raise an EvaluateException
                throw new EvaluateException($"Invalid move on {bishopPiece} did not raise exception on invalid move");
            }
            catch (InvalidOperationException)
            {
                
            }
        }
        
        /*
         * This test case tests the movement of the King piece
         */
        public static void TestKing()
        {
            // instantiate the piece
            KingPiece kingPiece = new KingPiece(_startPos[0], _startPos[1]);
            
            // execute legal movements
            kingPiece.Move(1, 1);
            kingPiece.Move(1, 0);
            kingPiece.Move(1, -1);
            kingPiece.Move(0, 1);
            kingPiece.Move(0, 0);
            kingPiece.Move(0, -1);
            kingPiece.Move(-1, 1);
            kingPiece.Move(-1, 0);
            kingPiece.Move(-1, -1);

            try
            {
                // attempt an illegal movement and ensure it raises an InvalidOperationException
                kingPiece.Move(1, 2);
                
                // if no exception is raised, raise an EvaluateException
                throw new EvaluateException($"Invalid move on {kingPiece} did not raise exception on invalid move");
            }
            catch (InvalidOperationException)
            {
                
            }
        }
        
        /*
         * This test case tests the movement of the Bishop piece
         */
        public static void TestKnight()
        {
            // instantiate the piece
            KnightPiece knightPiece = new KnightPiece(_startPos[0], _startPos[1]);
            
            // execute legal movements
            knightPiece.Move(1, 3);
            knightPiece.Move(1, -3);
            knightPiece.Move(-1, 3);
            knightPiece.Move(-1, -3);
            
            knightPiece.Move(3, 1);
            knightPiece.Move(-3, 1);
            knightPiece.Move(3, -1);
            knightPiece.Move(-3, -1);
            
            try
            {
                // attempt an illegal movement and ensure it raises an InvalidOperationException
                knightPiece.Move(1, 1);
                
                // if no exception is raised, raise an EvaluateException
                throw new EvaluateException($"Invalid move on {knightPiece} did not raise exception on invalid move");
            }
            catch (InvalidOperationException)
            {
                
            }
        }
        
        /*
         * This test case tests the movement of the Bishop piece
         */
        public static void TestPawn()
        {
            // instantiate the piece
            PawnPiece pawnPiece = new PawnPiece(_startPos[0], _startPos[1]);
            
            // execute legal movements
            pawnPiece.Move(2);
            pawnPiece.Move(1);
            
            try
            {
                // attempt an illegal movement and ensure it raises an InvalidOperationException
                pawnPiece.Move(2);
                
                // if no exception is raised, raise an EvaluateException
                throw new EvaluateException($"Invalid move on {pawnPiece} did not raise exception on invalid move");
            }
            catch (InvalidOperationException)
            {
                
            }
            
            try
            {
                // attempt an illegal movement and ensure it raises an InvalidOperationException
                pawnPiece.Move(2, 2);
                
                // if no exception is raised, raise an EvaluateException
                throw new EvaluateException($"Invalid move on {pawnPiece} did not raise exception on invalid move");
            }
            catch (InvalidOperationException)
            {
                
            }
        }
        
        /*
         * This test case tests the movement of the Queen piece
         */
        public static void TestQueen()
        {
            // instantiate the piece
            QueenPiece queenPiece = new QueenPiece(_startPos[0], _startPos[1]);
            
            // execute legal movements
            queenPiece.Move(1, 1);
            queenPiece.Move(1, 0);
            queenPiece.Move(1, -1);
            queenPiece.Move(0, 1);
            queenPiece.Move(0, 0);
            queenPiece.Move(0, -1);
            queenPiece.Move(-1, 1);
            queenPiece.Move(-1, 0);
            queenPiece.Move(-1, -1);
            
            try
            {
                // attempt an illegal movement and ensure it raises an InvalidOperationException
                queenPiece.Move(2, 1);
                
                // if no exception is raised, raise an EvaluateException
                throw new EvaluateException($"Invalid move on {queenPiece} did not raise exception on invalid move");
            }
            catch (InvalidOperationException)
            {
                
            } 
        }
        
        /*
         * This test case tests the movement of the Rook piece
         */
        public static void TestRook()
        {
            // instantiate the piece
            RookPiece rookPiece = new RookPiece(_startPos[0], _startPos[1]);
            
            // execute legal movements
            rookPiece.Move(1, 0);
            rookPiece.Move(0, 1);
            rookPiece.Move(-1, 0);
            rookPiece.Move(0, -1);

            try
            {
                // attempt an illegal movement and ensure it raises an InvalidOperationException
                rookPiece.Move(1, 1);
                
                // if no exception is raised, raise an EvaluateException
                throw new EvaluateException($"Invalid move on {rookPiece} did not raise exception on invalid move");
            }
            catch (InvalidOperationException)
            {
                
            } 
        }

        /*
         * This method runs all piece movement test cases
         * This causes a total of 54 commands to be enqueued
         */
        public static void TestAll()
        {
            TestBishop();
            TestKing();
            TestKnight();
            TestPawn();
            TestQueen();
            TestRook();
        }
    }
}