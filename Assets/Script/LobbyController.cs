using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
   
    // Start is called before the first frame update
    void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
       
    }
    void PlayGame()
    {
        SceneManager.LoadScene("Learn_GamePlay");
    }
    void QuitGame()
    {
        Application.Quit();
    }


}
