using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject SettingsPanel;
    public void StartGame()
    {
        Debug.Log("Game started");
        SceneManager.LoadScene(2);
    }
    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
