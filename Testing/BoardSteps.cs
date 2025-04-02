using Application;
using Shouldly;

namespace Testing
{
    internal partial class BoardShould 
    {
        private Board board;
        protected override void before_each()
        {
            base.before_each();
            board = null!;
        }

        public void A_Board()
        {
            board = new Board();
        }

        public void Moving_A_Player_Up()
        {
            board.MovePlayerUp();
        }

        public void The_Player_Moves_Up()
        {
            board.GetPlayerPosition().ShouldBe(1);
        }
    }
}
