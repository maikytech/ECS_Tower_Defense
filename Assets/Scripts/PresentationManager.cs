using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PresentationManager : MonoBehaviour
{
    public void GoToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
