using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool IsGameOver { get; private set; }

    public void GameOver()
    {
        IsGameOver = true;
    }
}
