using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button homeButton;
   

    void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        homeButton.onClick.AddListener(OnHomeButton);
       
    }
    public void PlayerDied()
    {
        SoundManager.Instance.Play(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }

    void ReloadLevel()
    {
        
        Scene scene =  SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);

    }
    public void OnHomeButton()
    {
 
        SceneManager.LoadScene("Lobby");
        
    }
    
}
