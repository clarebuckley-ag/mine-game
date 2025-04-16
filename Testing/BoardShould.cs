
using Application;
using Domain;

namespace Testing
{
    [TestFixture]
    internal partial class BoardShould : Specification
    {
        [TestCase(Board.Direction.Down, 1,0)]
        [TestCase(Board.Direction.Up, 1, 2)]
        [TestCase(Board.Direction.Left, 0, 1)]
        [TestCase(Board.Direction.Right, 2, 1)]
        public void Allow_A_Player_To_Move_In_Any_Direction(Board.Direction direction, int horizontalPosition, int verticalPosition)
        {
            A_Board_With_Starting_Position(new Position(1, 1));
            When(() => Moving_A_Player(direction));
            Then(() => The_Player_Moves_To(new Position(horizontalPosition,verticalPosition)));
        }

        [Test]
        public void Allow_A_Player_To_Move_Up_Twice()
        {
            Given(A_Board);
            When(Moving_A_Player_Up);
            And(Moving_A_Player_Up);
            Then(The_Player_Moves_Up_Twice);
        }

        [TestCase(Board.Direction.Down, 0, 0)]
        [TestCase(Board.Direction.Left, 0, 0)]
        [TestCase(Board.Direction.Right, 7, 0)]
        [TestCase(Board.Direction.Up, 0, 7)]
        public void Does_Not_Alow_A_Player_To_Move_Off_The_Board(Board.Direction direction, int horizontalPosition, int verticalPosition)
        {
            Given(() => A_Board_With_Starting_Position(new Position(horizontalPosition, verticalPosition)));
            When(() => Moving_A_Player(direction));
            Then(The_Player_Does_Not_Move);
        }
    }
}
