using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Enemy target;

    public void setBullet(Enemy target)
    {
        this.target = target;
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
}
