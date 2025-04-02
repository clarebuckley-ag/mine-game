
namespace Application
{
    public class Board
    {
        private int playerPosition = 0;

        public void MovePlayerUp()
        {
            playerPosition++;
        }

        public int GetPlayerPosition()
        {
            return playerPosition;
        }
    }
}
