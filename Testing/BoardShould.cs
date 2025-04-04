﻿
namespace Testing
{
    [TestFixture]
    internal partial class BoardShould : Specification
    {
        [Test]
        public void Allow_A_Player_To_Move_Up()
        {
            Given(A_Board);
            When(Moving_A_Player_Up);
            Then(The_Player_Moves_Up);
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
        public void Allow_A_Player_To_Move_Up_And_Then_Down()
        {
            Given(A_Board);
            When(Moving_A_Player_Up);
            And(Moving_A_Player_Down);
            Then(The_Player_Does_Not_Move);
        }

        [Test]
        public void Does_Not_Alow_User_To_Move_Off_The_Board()
        {
            Given(A_Board);
            When(Moving_A_Player_Down);
            Then(The_Player_Can_Not_Move);
        }
    }
}
