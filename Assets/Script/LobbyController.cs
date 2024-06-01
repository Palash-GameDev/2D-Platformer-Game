using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;


public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public GameObject LevelSelection;
   
    // Start is called before the first frame update
    void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
       
    }
    void PlayGame()
    {
       
        LevelSelection.SetActive(true);
    }
    void QuitGame()
    {
        Application.Quit();
    }


}
