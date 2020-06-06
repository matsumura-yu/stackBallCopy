using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲームのレベル
public enum GameState
{
    Waiting,
    Playing,
    Failed,
    Success
}

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance
    {
        get; private set;
    }

    // 今のゲームレベル
    public int level;

    public GameState currentGameState;   

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        level = 1;
        currentGameState = GameState.Waiting;
    }

}
