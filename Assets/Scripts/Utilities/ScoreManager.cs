using UnityEngine;

namespace Mryildirim.Utilities
{
    public class ScoreManager
    {
        public static int GetScore()
        {
            return PlayerPrefs.GetInt("Score");
        }

        public static void SetScore(int score)
        {
            PlayerPrefs.SetInt("Score", score);
        }

        public static int GetHighScore()
        {
            return PlayerPrefs.GetInt("High Score");
        }

        public static void SetHighScore()
        {
            if (GetScore() > GetHighScore())
            {
                PlayerPrefs.SetInt("High Score", GetScore());
            }
        }
    }
}
