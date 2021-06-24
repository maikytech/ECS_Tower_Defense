using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoToExit()
    {
        Application.Quit();
    }
}
