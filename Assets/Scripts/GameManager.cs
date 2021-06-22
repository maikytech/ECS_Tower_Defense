using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    [Header("Enemy Setup")]
    public float enemySpeed;
    public GameObject enemyPrefab;

    [Header("Spawning Setup")]
    public int numberOfEnemies = 10;

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

        DontDestroyOnLoad(gameObject);
        GM = this;

        //entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        //settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        //enemyEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(enemyPrefab, settings);
    }

    void enemyIncrements()
    {
        if (Input.GetKeyDown("space"))
            AddEnemies(numberOfEnemies);
    }

    void AddEnemies(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
             float xInside = Random.Range(-40, 40);
             float zInside = Random.Range(10, 24);

            float xOutside = Random.Range(40, 10);
            float zOutside = Random.Range(0, 24);



            Vector3 spawnPositionInside = new Vector3(xInside, 0.44f, zInside);
            Vector3 spawnPositionLeft = new Vector3(-xOutside, 0.44f, zOutside);
            Vector3 spawnPositionRight = new Vector3(xOutside, 0.44f, zOutside);
            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);

            var obj = Instantiate(enemyPrefab, spawnPositionInside, spawnRotation) as GameObject;
            var obj2 = Instantiate(enemyPrefab, spawnPositionLeft, spawnRotation) as GameObject;
            var obj3 = Instantiate(enemyPrefab, spawnPositionRight, spawnRotation) as GameObject;
        }

    }

    private void Update()
    {
        enemyIncrements();
    }




}
