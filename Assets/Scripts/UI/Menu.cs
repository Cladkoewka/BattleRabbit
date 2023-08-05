using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject MenuButton;
    public GameObject MenuWindow;

    public MonoBehaviour[] ScriptsToDisable;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void OpenMenu()
    {
        MenuButton.SetActive(false);
        MenuWindow.SetActive(true);
        for (int i = 0; i < ScriptsToDisable.Length; i++)
        {
            ScriptsToDisable[i].enabled = false;
        }
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void CloseMenu()
    {
        MenuButton.SetActive(true);
        MenuWindow.SetActive(false);
        for (int i = 0; i < ScriptsToDisable.Length; i++)
        {
            ScriptsToDisable[i].enabled = true;
        }
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.visible = false;
    }

}
