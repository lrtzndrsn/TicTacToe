namespace TicTacToeTest;

using NUnit.Framework;
using TicTacToe;
using TicTacToe.IO;


public class CursorTest {
   private Cursor cursor;

   [SetUp]
   public void Setup() {
      var keyToMoveMap = new KeyToMoveMap('i', 'k', 'j', 'l', 'q', ' ');
      cursor = new Cursor(3, keyToMoveMap);
      cursor.MoveDown();
      cursor.MoveRight();
   }

   [Test]
   public void CursorCenterTest() {
      Assert.True(cursor.position.X == 1 && cursor.position.Y == 1);
   }

   [Test]
   public void MoveUpTest() {
      cursor.MoveUp();
      int x = cursor.position.X;
      int y = cursor.position.Y;
      cursor.MoveUp();
      Assert.True(cursor.position.X == x && cursor.position.Y == y);
   }

   [Test]
   public void MoveDownTest() {
      cursor.MoveDown();
      int x = cursor.position.X;
      int y = cursor.position.Y;
      cursor.MoveDown();
      Assert.True(cursor.position.X == x && cursor.position.Y == y);
   }

   [Test]
   public void MoveLeftTest() {
      cursor.MoveLeft();
      int x = cursor.position.X;
      int y = cursor.position.Y;
      cursor.MoveLeft();
      Assert.True(cursor.position.X == x && cursor.position.Y == y);
   }

   [Test]
   public void MoveRightTest() {
      cursor.MoveRight();
      int x = cursor.position.X;
      int y = cursor.position.Y;
      cursor.MoveRight();
      Assert.True(cursor.position.X == x && cursor.position.Y == y);
   }
}
