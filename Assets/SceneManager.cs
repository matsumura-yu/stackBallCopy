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

    private void Update()
    {
        if(currentGameState == GameState.Failed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // シーンの再ロード
                UnityEngine.SceneManagement.Scene loadScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
                // Sceneの読み直し
                UnityEngine.SceneManagement.SceneManager.LoadScene(loadScene.name);

                currentGameState = GameState.Waiting;
            }
        }

        if(currentGameState == GameState.Waiting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentGameState = GameState.Playing;
            }
        }

        if(currentGameState == GameState.Success)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // シーンの再ロード
                UnityEngine.SceneManagement.Scene loadScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
                // Sceneの読み直し
                UnityEngine.SceneManagement.SceneManager.LoadScene(loadScene.name);
                // レベルを上げる
                level++;
                currentGameState = GameState.Waiting;
            }
        }
    }

}
