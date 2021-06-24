using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class UIManager : MonoBehaviour
{
    //This class a static reference to itself to ensure that there will only be
    //one in exitence. This is often referred to as a singleton design pattern. Other
    //scripts access this one through its public static methods.

    static UIManager current;

    public Text scoreText; 
    private void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        current = this;
    }

    public static void UpdateScore(int score)
    {
        if (current == null)
            return;

        current.scoreText.text = score.ToString();
    }
}