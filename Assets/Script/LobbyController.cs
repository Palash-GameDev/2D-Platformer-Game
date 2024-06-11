using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;


public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Button instruction;
    public Button backToLobby;
    public GameObject LevelSelection;
    public GameObject instructionPanel;

    // Start is called before the first frame update
    void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        instruction.onClick.AddListener(ShowInstruction);
        backToLobby.onClick.AddListener(BackToLobby);

    }
    void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }
    void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();

    }

    void ShowInstruction()
    {
        instructionPanel.SetActive(true);
    }

    void BackToLobby()
    {
        instructionPanel.SetActive(false);
    }


}
