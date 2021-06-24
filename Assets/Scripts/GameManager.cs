using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    [Header("Enemy Setup")]
    public int score = 0;
    public float speedEnemy = 5;
    public float rotationSpeed = 5;
    public bool isDead = false;
    public Transform tower;

    private void Awake()
    {
        if(GM != null && GM != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        GM = this;
    }

    public void Score()
    {
        score++;
        UIManager.UpdateScore(score);
    }

    public void GameOver()
    {
        UIManager.current.gameOver.enabled = true;
    }
}
