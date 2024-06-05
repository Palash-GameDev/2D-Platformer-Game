using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    public string LevelName;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

    }

    void OnClick()
    {
        LevelStatus levelStatus = LevelManager.Instace.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play this level till you unlock");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;

        }

    }


}