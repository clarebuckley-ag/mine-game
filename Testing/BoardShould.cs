
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
            Given(A_Board_With_Starting_Position_1_1);
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

        [Test]
        public void Does_Not_Alow_A_Player_To_Move_Off_The_Board()
        {
            Given(A_Board);
            When(Moving_A_Player_Down);
            Then(The_Player_Does_Not_Move);
        }
    }
}
