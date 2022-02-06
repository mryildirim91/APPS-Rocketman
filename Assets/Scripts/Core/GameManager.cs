using Mryildirim.UI;
using Mryildirim.Utilities;
using UnityEngine.SceneManagement;

namespace Mryildirim.Core
{
    public class GameManager : Singleton<GameManager>
    {
        public bool IsGameOver { get; private set; }

        public void GameOver()
        {
            IsGameOver = true;
            UIManager.Instance.OpenGameOverPanel();
        }

        public void RestartGame()
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}

