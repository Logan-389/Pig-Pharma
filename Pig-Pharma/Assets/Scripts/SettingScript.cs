using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingScript : MonoBehaviour
{
    bool isPaused = false;
    public GameObject settingsUI;
    public GameObject inventoryUI;

    void OnMouseDown()
    {
      
        if(!isPaused)                 //pause the game
        {
            Debug.Log("pause");
            Time.timeScale = 0f;
            inventoryUI.SetActive(false);
            settingsUI.SetActive(true);

            isPaused = true;
        } else if(isPaused)           //unpause the game
        {
            CloseSettings();
        }

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void CloseSettings()
    {
        Debug.Log("play");
        settingsUI.SetActive(false);
        inventoryUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
