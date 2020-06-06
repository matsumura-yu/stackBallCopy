using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text levelText;
    public Text underText;
    public Text messageText;

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.Instance.currentGameState == GameState.Waiting)
        {
            levelText.gameObject.SetActive(false);
            messageText.gameObject.SetActive(false);
            underText.gameObject.SetActive(true);
            underText.text = "TAP TO PLAY";
            return;
        }

        if(SceneManager.Instance.currentGameState == GameState.Playing)
        {
            levelText.gameObject.SetActive(false);
            messageText.gameObject.SetActive(false);
            underText.gameObject.SetActive(false);
            return;
        }

        if (SceneManager.Instance.currentGameState == GameState.Failed)
        {
            levelText.gameObject.SetActive(true);
            levelText.text = "SCORE:" + SceneManager.Instance.level;
            messageText.gameObject.SetActive(true);
            messageText.text = "GAME OVER";
            underText.gameObject.SetActive(true);
            underText.text = "TOUCH TO RESTART";
            return;
        }

        if (SceneManager.Instance.currentGameState == GameState.Success)
        {
            levelText.gameObject.SetActive(true);
            levelText.text = "Level " + SceneManager.Instance.level;
            messageText.gameObject.SetActive(true);
            messageText.text = "COMPLETED!";
            underText.gameObject.SetActive(true);
            underText.text = "TOUCH TO NEXT";
            return;
        }
    }
}
