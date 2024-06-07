using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public string level1;
    public string [] levels;
    public static LevelManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        if (GetLevelStatus(levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(levels[0], LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;

    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting level : " + level + " statu" + levelStatus);
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // set level status to complete
        LevelManager.Instance.SetLevelStatus(currentScene.name, LevelStatus.Completed);

        /*  // unlock next level
        int nextSceneIndex = currentScene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        LevelManager.Instace.SetLevelStatus(nextScene.name, LevelStatus.Unlocked);*/

        int currentSceneIndex = Array.FindIndex(levels, level=> level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex < levels.Length  )
        {
            
            SetLevelStatus(levels[nextSceneIndex],LevelStatus.Unlocked);
        }
    }


}// class end