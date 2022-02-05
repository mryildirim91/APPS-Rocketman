using Mryildirim.Utilities;

namespace Mryildirim.Core
{
    public class GameManager : Singleton<GameManager>
    {
        public bool IsGameOver { get; private set; }

        public void GameOver()
        {
            IsGameOver = true;
        }
    }
}

