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
    }
}
