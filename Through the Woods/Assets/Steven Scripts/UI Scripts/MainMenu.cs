using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;

    [SerializeField] Button newGame;
    [SerializeField] Button loadGame;
    [SerializeField] Button exitGame;

    public static int levelCleared;

    public static float volumeLevel = 1f;

    private void Awake()
    {
        newGame.onClick.RemoveListener(NewGame);
        newGame.onClick.AddListener(NewGame);
        loadGame.onClick.RemoveListener(LoadGame);
        loadGame.onClick.AddListener(LoadGame);
        exitGame.onClick.RemoveListener(ExitGame);
        exitGame.onClick.AddListener(ExitGame);
    }
    // Start is called before the first frame update
    public void Start()
    {
        LoadData();
    }
    public void BackToMain()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void SettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void NewGame()
    {
        levelCleared = 0;

        SaveSystem.Save(levelCleared, volumeLevel);

        SceneManager.LoadScene("Map_StageSelect");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Map_StageSelect");
    }

    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();

        levelCleared = data.levelCleared;
        volumeLevel = data.volumeLevel;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
