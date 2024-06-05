using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    public Image gameover;
    public Sprite youWin;
    public GameObject gameOverPanel;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Completd!");
            gameOverPanel.SetActive(true); 
            gameover.sprite = youWin;
            LevelManager.Instace.MarkCurrentLevelComplete();           
        }

    }
}
