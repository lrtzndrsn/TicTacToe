namespace TicTacToe;

using System;
using TicTacToe.Interfaces;

/// <summary>
/// A basic board checker that will determine if for a given row, diagonal or column, if all of
/// the elements is equal to eachother and not equal to null. It will also determine if the board
/// is in a tied position.
/// </summary>
public class BoardChecker : IBoardChecker {

   /// <summary>
   /// Method that is used to check if all elements in a row is equal to eachother and is not
   /// equal to null.
   /// </summary>
   /// <param name="board">A given board.</param>
   /// <returns>
   /// True if there is a win where all identifiers in the row is equal else false.
   /// </returns>
   private bool IsRowWin(Board board) {
      // each col
      for (int y = 0; y < board.Size; y++) {
         // each row
         bool win = true;
         for (int x = 0; x < board.Size - 1; x++) {
            if (board.Get(x, y) == null || board.Get(x, y) != board.Get(x + 1, y)) {
               win = false;
               break;
            }
         }
         if (win) {
            return true;
         }
      }
      return false;
   }

   /// <summary>
   /// Method that is used to check if all elements in a column is equal to eachother and is not
   /// equal to null.
   /// </summary>
   /// <param name="board">A given board.</param>
   /// <returns>
   /// True if there is a win where all identifiers in the column is equal else false.
   /// </returns>
   private bool IsColWin(Board board) {
      // each row
      for (int x = 0; x < board.Size; x++) {
         // each col
         bool win = true;
         for (int y = 0; y < board.Size - 1; y++) {
            if (board.Get(x, y) == null || board.Get(x, y) != board.Get(x, y + 1)) {
               win = false;
               break;
            }
         }
         if (win) {
            return true;
         }
      }
      return false;
   }

   /// <summary>
   /// Method that is used to check if all elements in a diagonal is equal to eachother and is not
   /// equal to null. This diagonal will always be the two longest in a square.
   /// </summary>
   /// <param name="board">A given board.</param>
   /// <returns>
   /// True if there is a win where all identifiers in the diagonal is equal else false.
   /// </returns>
   private bool IsDiagWin(Board board) {
      // From top left to bottom right
      bool win = true;
      for (int i = 0; i < board.Size - 1; i++) {
         if (board.Get(i, i) == null || board.Get(i, i) != board.Get(i + 1, i + 1)) {
            win = false;
            break;
         }
      }
      if (win) {
         return true;
      }
      //From top right to bottom right
      win = true;
      for (int i = 0; i < board.Size - 1; i++) {
         int y = i;
         int x = board.Size - 1 - i;
         if (board.Get(x, y) == null || board.Get(x, y) != board.Get(x - 1, y + 1)) {
            win = false;
            break;
         }
      }
      if (win) {
         return true;
      }

      return false;
   }

   private bool isTied(Board board) {
      if (board.IsFull() && !this.IsRowWin(board) && !this.IsColWin(board) && !IsDiagWin(board)) {
         return true;
      }
      return false;

   }
   /// <summary>
   /// Method that will determine what the state of the board is. If there is a winner, a tied or
   /// the game is still inconclusive.
   /// </summary>
   /// <param name="board">A given board.</param>
   /// <returns> The state of the board.</returns>
   public BoardState CheckBoardState(Board board) {
      if (this.IsRowWin(board) || this.IsColWin(board) || this.IsDiagWin(board)) {
         return BoardState.Winner;
      } else if (this.isTied(board)) {
         return BoardState.Tied;
      } else {
         return BoardState.Inconclusive;
      }
   }
}



