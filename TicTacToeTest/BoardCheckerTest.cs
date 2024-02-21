namespace TicTacToeTest;

using NUnit.Framework;
using TicTacToe;

public class BoardCheckerTest {

   public Board board;
   public BoardChecker boardChecker;

   [SetUp]
   public void Setup() {
      board = new Board(3);
      boardChecker = new BoardChecker();
   }

   [Test]
   public void DiagonalWinTest() {
      //Bottom left to top right 
      board = new Board(3);
      board.TryInsert(0, 0, PlayerIdentifier.Cross);
      board.TryInsert(1, 1, PlayerIdentifier.Cross);
      board.TryInsert(2, 2, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Bottom right to bottom left
      board = new Board(3);
      board.TryInsert(2, 0, PlayerIdentifier.Cross);
      board.TryInsert(1, 1, PlayerIdentifier.Cross);
      board.TryInsert(0, 2, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);
   }

   [Test]
   public void RowWinTest() {
      //All possible row wins on 3x3 board. 

      //Row 0 - Cross
      board = new Board(3);
      board.TryInsert(0, 0, PlayerIdentifier.Cross);
      board.TryInsert(1, 0, PlayerIdentifier.Cross);
      board.TryInsert(2, 0, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Row 1 - Cross
      board = new Board(3);
      board.TryInsert(0, 1, PlayerIdentifier.Cross);
      board.TryInsert(1, 1, PlayerIdentifier.Cross);
      board.TryInsert(2, 1, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Row 2 - Cross
      board = new Board(3);
      board.TryInsert(0, 2, PlayerIdentifier.Cross);
      board.TryInsert(1, 2, PlayerIdentifier.Cross);
      board.TryInsert(2, 2, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Row 0 - Naught
      board = new Board(3);
      board.TryInsert(0, 0, PlayerIdentifier.Naught);
      board.TryInsert(1, 0, PlayerIdentifier.Naught);
      board.TryInsert(2, 0, PlayerIdentifier.Naught);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Row 1 - Naught
      board = new Board(3);
      board.TryInsert(0, 1, PlayerIdentifier.Naught);
      board.TryInsert(1, 1, PlayerIdentifier.Naught);
      board.TryInsert(2, 1, PlayerIdentifier.Naught);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Row 2 - Naught
      board = new Board(3);
      board.TryInsert(0, 2, PlayerIdentifier.Naught);
      board.TryInsert(1, 2, PlayerIdentifier.Naught);
      board.TryInsert(2, 2, PlayerIdentifier.Naught);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

   }

   [Test]
   public void ColumnWinTest() {
      //All possible col wins on 3x3 board. 

      //Col 0 - Cross
      board = new Board(3);
      board.TryInsert(0, 0, PlayerIdentifier.Cross);
      board.TryInsert(0, 1, PlayerIdentifier.Cross);
      board.TryInsert(0, 2, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Col 1 - Cross
      board = new Board(3);
      board.TryInsert(1, 0, PlayerIdentifier.Cross);
      board.TryInsert(1, 1, PlayerIdentifier.Cross);
      board.TryInsert(1, 2, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Col 2 - Cross
      board = new Board(3);
      board.TryInsert(2, 0, PlayerIdentifier.Cross);
      board.TryInsert(2, 1, PlayerIdentifier.Cross);
      board.TryInsert(2, 2, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Col 0 - Naught
      board = new Board(3);
      board.TryInsert(0, 0, PlayerIdentifier.Naught);
      board.TryInsert(0, 1, PlayerIdentifier.Naught);
      board.TryInsert(0, 2, PlayerIdentifier.Naught);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Col 1 - Naught
      board = new Board(3);
      board.TryInsert(1, 0, PlayerIdentifier.Naught);
      board.TryInsert(1, 1, PlayerIdentifier.Naught);
      board.TryInsert(1, 2, PlayerIdentifier.Naught);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);

      //Col 2 - Naught
      board = new Board(3);
      board.TryInsert(2, 0, PlayerIdentifier.Naught);
      board.TryInsert(2, 1, PlayerIdentifier.Naught);
      board.TryInsert(2, 2, PlayerIdentifier.Naught);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Winner);
   }

   [Test]
   public void InconclusiveTest() {
      // No pieces
      board = new Board(3);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Inconclusive);

      // Few pieces
      board = new Board(3);
      board.TryInsert(2, 0, PlayerIdentifier.Naught);
      board.TryInsert(2, 1, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Inconclusive);

      // One piece 
      board.TryInsert(2, 0, PlayerIdentifier.Naught);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Inconclusive);
   }

   [Test]
   public void TiedTest() {
      board = new Board(3);
      board.TryInsert(0, 0, PlayerIdentifier.Naught);
      board.TryInsert(1, 0, PlayerIdentifier.Cross);
      board.TryInsert(2, 0, PlayerIdentifier.Naught);
      board.TryInsert(0, 1, PlayerIdentifier.Cross);
      board.TryInsert(1, 1, PlayerIdentifier.Cross);
      board.TryInsert(2, 1, PlayerIdentifier.Naught);
      board.TryInsert(0, 2, PlayerIdentifier.Cross);
      board.TryInsert(1, 2, PlayerIdentifier.Naught);
      board.TryInsert(2, 2, PlayerIdentifier.Cross);
      Assert.True(boardChecker.CheckBoardState(board) == BoardState.Tied);
   }
}
