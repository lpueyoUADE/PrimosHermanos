using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public string sceneToOpen = "Office";
    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneToOpen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
