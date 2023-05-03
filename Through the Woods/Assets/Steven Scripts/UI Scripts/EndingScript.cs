using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public Button goBackMainMenu;

    private void Awake()
    {
        goBackMainMenu.onClick.RemoveListener(MainMenu);
        goBackMainMenu.onClick.AddListener(MainMenu);
    }
    
    void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
