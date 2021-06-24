using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [Header("Shoot")]
    public float triggerRange;
    public float timeToShoot = 0.3f;
    public Transform rotationPart;
    public Transform shootPosition;
    public Enemy currentTarget;
    public Bullet bullet;
    public List<Enemy> currentTargets = new List<Enemy>();

    [Header("Life")]
    public Image fillLifeImage;
    private float maxLife = 50;
    private float currentLife = 0;
    private bool isDead;


    private void Start()
    {
        currentLife = maxLife;
        StartCoroutine(ShootTimer());
    }
    private void Update()
    {
        EnemyDetection();
        LookRotation();

        if (Input.GetKeyDown("f"))
            TakeDamage(1.0f);
    }

    private void EnemyDetection()
    {
        
        //Lista de enemigos que traspasaron el rango de disparo
        currentTargets = Physics.OverlapSphere(transform.position, triggerRange).Where(currentEnemy => currentEnemy.GetComponent<Enemy>()).Select(currentEnemy => currentEnemy.GetComponent<Enemy>()).ToList();

        if (currentTargets.Count > 0)
        {
            currentTarget = currentTargets[0];
            
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

    public void TakeDamage(float damage)
    {
        var newLife = currentLife - damage;
        if (isDead)
            return;

        if(newLife <= 0)
        {
            OnDead();
        }
        currentLife = newLife;

        var fillvalue = currentLife * 1 / 50;
        fillLifeImage.fillAmount = fillvalue;
    }

    private void OnDead()
    {
        isDead = true;
        currentLife = 0;
        fillLifeImage.fillAmount = 0;
        GameManager.GM.GameOver();

    }
}
