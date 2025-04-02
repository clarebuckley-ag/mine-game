
namespace Application
{
    public class Board
    {
        private int playerPosition = 0;

        public void MovePlayerUp()
        {
            playerPosition++;
        }

        public void MovePlayerDown()
        {
            playerPosition--;
        }

        public int GetPlayerPosition()
        {
            return playerPosition;
        }
    }
}
