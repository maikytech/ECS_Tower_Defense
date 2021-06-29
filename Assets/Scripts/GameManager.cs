using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    [Header("Enemy Setup")]
    public float speedEnemy = 10;
    public float rotationSpeedEnemy = 3;

    [SerializeField] private GameObject enemyPrefab;

    [Header("Enemy Wave Setup")]

    public Transform tower;
    public bool isGameOver = false;

    [SerializeField] private int numberOfEnemies = 10;
    [SerializeField] private int score = 0;
    [SerializeField] private float wavesTime = 2f;
    [SerializeField] private float startWavesTime = 1f;
    
    

    //DOTS Variables
    private EntityManager entityManager;
    private Entity enemyEntityPrefab;
    private GameObjectConversionSettings settings;

    private void Awake()
    {
        if(GM != null && GM != this)
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);
        GM = this;

        isGameOver = false;
        numberOfEnemies = 10;
        score = 0;

        /*
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        enemyEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(enemyPrefab, settings);

        */
    }

    private void Start()
    {
        InvokeRepeating("EnemyIncrements", startWavesTime, wavesTime);
    }

    void EnemyIncrements()
    {
        if (numberOfEnemies < 100)
        {
            AddEnemies(numberOfEnemies);
        }
    }

    void AddEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float xValue = Random.Range(-40, 40);
            float zValue = Random.Range(10, 24);

            Vector3 spawnPosition = new Vector3(xValue, 0.44f, zValue);
            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);

            var obj = Instantiate(enemyPrefab, spawnPosition, spawnRotation);

            if (isGameOver)
                return;

            /*
            Entity enemy = entityManager.Instantiate(enemyEntityPrefab);
            Translation translation2 = new Translation();
            translation2.Value = spawnPosition;
            entityManager.SetComponentData(enemy, translation2);
            */
        }

        numberOfEnemies += 10;
    }
    public void Score()
    {
        score++;
        UIManager.UpdateScore(score);
        
        if(score <= 0)
        {
            isGameOver = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
