using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{ 
    public float triggerRange;
    public float timeToShoot = 0.3f;
    public Transform rotationPart;
    public Transform shootPosition;
    public Enemy currentTarget;
    public Bullet bullet;
    public List<Enemy> currentTargets = new List<Enemy>();

    private void Start()
    {
        StartCoroutine(ShootTimer());
    }
    private void Update()
    {
        EnemyDetection();
        LookRotation();
    }

    private void EnemyDetection()
    {
        //Debug.Log("Entro al EnemyDetection");
        //Lista de enemigos que traspasaron el rango de disparo
        currentTargets = Physics.OverlapSphere(transform.position, triggerRange).Where(currentEnemy => currentEnemy.GetComponent<Enemy>()).Select(currentEnemy => currentEnemy.GetComponent<Enemy>()).ToList();

        if (currentTargets.Count > 0)
        {
            currentTarget = currentTargets[0];
            //Debug.Log("Enemigo detectado");
        }
            
        else if (currentTargets.Count == 0)
        {
            currentTarget = null;
        }
    }
    private void LookRotation()
    {
        if(currentTarget)
        {
           rotationPart.LookAt(currentTarget.transform);
        }
    }

    private void Shoot()
    {
        var bulletGo = Instantiate(bullet, shootPosition.position, shootPosition.rotation);
        bulletGo.setBullet(currentTarget);
        UIManager.UpdateScore(1);
    }

    private IEnumerator ShootTimer()
    {
        while(true)
        {
            if(currentTarget)
            {
                Shoot();
                yield return new WaitForSeconds(timeToShoot);
            }

            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, triggerRange);
    }
}
