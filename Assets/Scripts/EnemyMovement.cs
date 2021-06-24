using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameManager.GM.tower.position, GameManager.GM.speedEnemy * Time.deltaTime);
    }

    private void LookAt()
    {
        var dir = GameManager.GM.tower.position - transform.position;
        var rootTarget = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rootTarget, GameManager.GM.rotationSpeed * Time.deltaTime);   

    }

    private void Update()
    {
        Movement();
        LookAt();
    }
}
