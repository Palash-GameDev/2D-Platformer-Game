using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
   

    void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
       
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    void ReloadLevel()
    {
        
        Scene scene =  SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);

    }
    
}
