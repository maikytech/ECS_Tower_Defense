using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;

    public GameObject gameOver;
    public GameObject restart;
    public GameObject menu;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (uiManager != null && uiManager != this)
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);

        uiManager = this;
    }

    public static void UpdateScore(int score)
    {
        if (uiManager == null)
            return;

        uiManager.scoreText.text = score.ToString();
    }


}