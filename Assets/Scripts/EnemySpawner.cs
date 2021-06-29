using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float wavesTime = 10.0f;
    public int numberOfEnemies = 1;

    private EntityManager entityManager;
    private Entity enemyEntityPrefab;
    private GameObjectConversionSettings settings;

    private void Awake()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        enemyEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(enemyPrefab, settings);
    }

    private void Start()
    {
       // InvokeRepeating("EnemyIncrements", wavesTime, wavesTime);
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

            //var obj = Instantiate(enemyPrefab, spawnPosition, spawnRotation);

            Entity enemy = entityManager.Instantiate(enemyEntityPrefab);
            Translation translation2 = new Translation();
            translation2.Value = spawnPosition;
            entityManager.SetComponentData(enemy, translation2);

        }

        numberOfEnemies += 10;
    }
}
