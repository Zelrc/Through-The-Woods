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

    [SerializeField] Image volumeBar;
    [SerializeField] Button volumeDown;
    [SerializeField] Button volumeUp;

    public static int levelCleared;

    public static float volumeLevel;

    private void Awake()
    {
        newGame.onClick.RemoveListener(NewGame);
        newGame.onClick.AddListener(NewGame);
        loadGame.onClick.RemoveListener(LoadGame);
        loadGame.onClick.AddListener(LoadGame);
        exitGame.onClick.RemoveListener(ExitGame);
        exitGame.onClick.AddListener(ExitGame);

        volumeDown.onClick.RemoveListener(reduceVol);
        volumeDown.onClick.AddListener(reduceVol);
        volumeUp.onClick.RemoveListener(increaseVol);
        volumeUp.onClick.AddListener(increaseVol);
    }
    // Start is called before the first frame update
    public void Start()
    {
        LoadData();
        AudioManager.Instance.ChangeVolume();
        AudioManager.Instance.Play("MainMenuBGM");
        Debug.Log(volumeLevel);
    }

    private void Update()
    {
        volumeBar.fillAmount = volumeLevel;
    }

    void reduceVol()
    {
        AudioManager.Instance.Play("UISelectSound");
        if (volumeLevel >= 0.05f)
        {
            volumeLevel -= 0.05f;
            Debug.Log(volumeLevel);
        }
        AudioManager.Instance.ChangeVolume();
    }

    void increaseVol()
    {
        AudioManager.Instance.Play("UISelectSound");
        if (volumeLevel < 1f)
        {
            volumeLevel += 0.05f;
            Debug.Log(volumeLevel);
        }
        AudioManager.Instance.ChangeVolume();
    }
    public void BackToMain()
    {
        AudioManager.Instance.Play("UISelectSound");
        SaveSystem.Save(levelCleared, volumeLevel);
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void SettingsMenu()
    {
        AudioManager.Instance.Play("UISelectSound");
        
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void NewGame()
    {
        AudioManager.Instance.Play("UISelectSound");
        levelCleared = 0;

        SaveSystem.Save(levelCleared, volumeLevel);
        AudioManager.Instance.StopPlaying("MainMenuBGM");
        VideoSystem.videoName = "Map_StageSelect";
        SceneManager.LoadScene("VideoTesting");
    }

    public void LoadGame()
    {
        AudioManager.Instance.Play("UISelectSound");
        AudioManager.Instance.StopPlaying("MainMenuBGM");
        SceneManager.LoadScene("Map_StageSelect");

        
    }

    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();

        levelCleared = data.levelCleared;
        volumeLevel = data.volumeLevel;
        Debug.Log(data.volumeLevel);
    }

    public void ExitGame()
    {
        AudioManager.Instance.Play("UISelectSound");
        Application.Quit();
    }
}
