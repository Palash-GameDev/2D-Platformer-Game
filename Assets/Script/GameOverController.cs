using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
     public Button goHomeButton;

    void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
         goHomeButton.onClick.AddListener(goHome);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

        void ReloadLevel()
    {
        SceneManager.LoadScene("Learn_GamePlay");

    }
        void goHome()
    {
         SceneManager.LoadScene("Lobby");
    }

}
